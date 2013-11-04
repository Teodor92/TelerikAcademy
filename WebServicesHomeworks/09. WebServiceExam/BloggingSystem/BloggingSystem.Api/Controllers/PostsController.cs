namespace BloggingSystem.Api.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using BloggingSystem.Api.Attributes;
    using BloggingSystem.Api.Models;
    using BloggingSystem.Data;
    using BloggingSystem.Models;

    public class PostsController : BaseApiController
    {
        [HttpPost]
        public HttpResponseMessage PostAPost(
            [FromBody]PostModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    ValidateText(model.Text);
                    ValidateTitle(model.Title);

                    var context = new BloggingSystemContext();
                    using (context)
                    {
                        var user = GetValidUser(sessionKey);

                        if (user == null)
                        {
                            throw new InvalidOperationException("You are not logged in!");
                        }

                        var post = new Post()
                        {
                            Title = model.Title,
                            Text = model.Text,
                            PostDate = DateTime.Now,
                            User = user
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

                            post.Tags.Add(newTag);
                        }

                        context.Posts.Add(post);
                        context.SaveChanges();

                        PostResponseModel responseModel = new PostResponseModel()
                        {
                            Id = post.Id,
                            Title = post.Title
                        };

                        return Request.CreateResponse(HttpStatusCode.Created, responseModel);
                    }
                });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<GetPostModel> GetAllPosts(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            this.GetValidUser(sessionKey);

            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();

                var models =
                    from postEnt in context.Posts.ToList()
                    select new GetPostModel()
                    {
                        Id = postEnt.Id,
                        Title = postEnt.Title,
                        Text = postEnt.Text,
                        PostedBy = postEnt.User.DisplayName,
                        PostDate = postEnt.PostDate,
                        Tags = postEnt.Tags.Select(x => x.Title).ToArray(),
                        Comments =
                        from commentEnt in postEnt.Comments
                        select new CommentModel()
                        {
                            Text = commentEnt.Text,
                            PostDate = commentEnt.CommentDate,
                            CommentedBy = commentEnt.User.DisplayName
                        }
                    };

                return models.OrderByDescending(ps => ps.PostDate);
            });

            return responseMsg.AsQueryable();
        }

        [HttpGet]
        public IQueryable<GetPostModel> GetPagePosts(
            int page, 
            int count,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() => 
            {
                this.GetValidUser(sessionKey);

                var models = this.GetAllPosts(sessionKey);
                var filterModels = models.Skip(page * count).Take(count);

                return filterModels;
            });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<GetPostModel> GetPostsByKeyWord(
            string keyword,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responesMsg = this.PerformOperationAndHandleExceptions(() => 
            {
                this.GetValidUser(sessionKey);

                var models = this.GetAllPosts(sessionKey);
                var filterModels = models.Where(ps => ps.Title.ToLower().Contains(keyword.ToLower()));

                return filterModels;
            });

            return responesMsg;
        }

        [HttpGet]
        public IQueryable<GetPostModel> GetPostsByTag(
            string tags,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() => 
            {
                this.GetValidUser(sessionKey);

                string[] allTags = tags.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                var models = this.GetAllPosts(sessionKey);
                var filterModels = models.Where(ps => ps.Tags.Intersect(allTags).Count() == allTags.Length);

                return filterModels;
            });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("comment")]
        public HttpResponseMessage PutNewComment(
            int postId, 
            [FromBody] CommentModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                ValidateCommentText(model.Text);

                var context = new BloggingSystemContext();
                using (context)
                {
                    var user = GetValidUser(sessionKey);

                    if (user == null)
                    {
                        throw new InvalidOperationException("You are not logged in!");
                    }

                    var post = context.Posts.Where(ps => ps.Id == postId).FirstOrDefault();

                    if (post == null)
                    {
                        throw new InvalidOperationException("No such post exists");
                    }

                    Comment newComment = new Comment()
                    {
                        Text = model.Text,
                        CommentDate = DateTime.Now,
                        User = user,
                        Post = post
                    };

                    context.Comments.Add(newComment);
                    context.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            });

            return responseMsg;
        }

        private User GetValidUser(string sessionKey)
        {
            var context = new BloggingSystemContext();

            using (context)
            {
                var user = context.Users.FirstOrDefault(ur => ur.SessionKey == sessionKey);

                if (user == null)
                {
                    throw new InvalidOperationException("You are not logged in.");
                }

                return user;
            }
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
