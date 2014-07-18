using SimpleAdvertisementSystem.Api.Models;
using SimpleAdvertisementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using SimpleAdvertisementSystem.Model;
using TasksManager.App.AuthenticationHeaders;

namespace SimpleAdvertisementSystem.Api.Controllers
{
    public class AdvertisementsController : BaseApiController
    {
        [HttpPost]
        public HttpResponseMessage PostAdvertisement(
            [FromBody]AdvertisementModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var responseMsg = this.ExecuteOperationAndHandleExceptions(() =>
            {
                ValidateText(model.Text);
                ValidateTitle(model.Title);

                var context = new AdvertisementSystemContext();
                using (context)
                {
                    var user = this.GetUserByAccessToken(accessToken, context);

                    if (user == null)
                    {
                        throw new InvalidOperationException("You are not logged in!");
                    }

                    var category = context.Categories.FirstOrDefault(x => x.Id == model.CategoryId);

                    var advert = new Advertisement()
                    {
                        Title = model.Title,
                        Text = model.Text,
                        PostDate = DateTime.Now,
                        ExparationDate = DateTime.Now,
                        User = user,
                        Category = category
                    };

                    HashSet<string> allTags = new HashSet<string>();
                    foreach (var tag in model.Tags)
                    {
                        var lowerTag = tag.ToLower();
                        if (!allTags.Contains(lowerTag))
                        {
                            allTags.Add(lowerTag);
                        }
                    }

                    string[] splitedTitle = model.Title.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var tag in splitedTitle)
                    {
                        var lowerTag = tag.ToLower();
                        if (!allTags.Contains(lowerTag))
                        {
                            allTags.Add(lowerTag);
                        }
                    }

                    foreach (var tag in allTags)
                    {
                        var newTag = context.Tags.Where(t => t.Title == tag).FirstOrDefault();

                        if (newTag == null)
                        {
                            newTag = new Tag()
                            {
                                Title = tag
                            };
                        }

                        advert.Tags.Add(newTag);
                    }

                    context.Advertisements.Add(advert);
                    context.SaveChanges();

                    PostAdvertisementResponseModel responseModel = new PostAdvertisementResponseModel()
                    {
                        Id = advert.Id,
                        Title = advert.Title
                    };

                    return Request.CreateResponse(HttpStatusCode.Created, responseModel);
                }
            });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<GetAdvertisementModel> GetAllAdvertisements(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var responseMsg = this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new AdvertisementSystemContext();
                this.GetUserByAccessToken(accessToken, context);

                var models =
                    from postEnt in context.Advertisements.ToList()
                    select new GetAdvertisementModel()
                    {
                        Id = postEnt.Id,
                        Title = postEnt.Title,
                        Text = postEnt.Text,
                        PostedBy = postEnt.User.Username,
                        PostDate = postEnt.PostDate,
                        Tags = postEnt.Tags.Select(x => x.Title).ToArray(),
                        Comments =
                        from commentEnt in postEnt.Comments
                        select new CommentModel()
                        {
                            Text = commentEnt.Text,
                            PostDate = commentEnt.CommentDate,
                            CommentedBy = commentEnt.User.Username
                        }
                    };

                return models.OrderByDescending(ps => ps.PostDate);
            });

            return responseMsg.AsQueryable();
        }

        [HttpGet]
        public IQueryable<GetAdvertisementModel> GetPagedAdvertisements(
            int page,
            int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var responseMsg = this.ExecuteOperationAndHandleExceptions(() =>
            {
                var models = this.GetAllAdvertisements(accessToken);
                var filterModels = models.Skip(page * count).Take(count);

                return filterModels;
            });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<GetAdvertisementModel> GetAdvertisementByKeyWord(
            string keyword,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var responesMsg = this.ExecuteOperationAndHandleExceptions(() =>
            {
                var models = this.GetAllAdvertisements(accessToken);
                var filterModels = models.Where(ps => ps.Title.ToLower().Contains(keyword.ToLower()));

                return filterModels;
            });

            return responesMsg;
        }

        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage PutNewComment(
            int postId,
            [FromBody] CommentModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var responseMsg = this.ExecuteOperationAndHandleExceptions(() =>
            {
                ValidateCommentText(model.Text);

                var context = new AdvertisementSystemContext();

                var user = this.GetUserByAccessToken(accessToken, context);

                if (user == null)
                {
                    throw new InvalidOperationException("You are not logged in!");
                }

                var advert = context.Advertisements.FirstOrDefault(ps => ps.Id == postId);

                if (advert == null)
                {
                    throw new InvalidOperationException("No such post exists");
                }

                Comment newComment = new Comment()
                {
                    Text = model.Text,
                    CommentDate = DateTime.Now,
                    User = user,
                    Post = advert
                };

                context.Comments.Add(newComment);
                context.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Created);

            });

            return responseMsg;
        }

        private void ValidateCommentText(string text)
        {
            this.ValidateString(text, "Comment text");

            if (text.Length < 12)
            {
                throw new ArgumentException("Comment text is too short. 12 chars minimum.");
            }
        }

        private void ValidateTitle(string title)
        {
            this.ValidateString(title, "Title");
        }

        private void ValidateText(string text)
        {
            this.ValidateString(text, "Post text");

            if (text.Length < 12)
            {
                throw new ArgumentException("Post text is too short. 12 chars minimum.");
            }
        }

        private void ValidateString(string inputString, string type)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                throw new ArgumentException(string.Format("{0} cant br empty", type));
            }
        }
    }
}
