namespace BloggingSystem.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using BloggingSystem.Api.Attributes;
    using BloggingSystem.Api.Models;
    using BloggingSystem.Data;
    using BloggingSystem.Models;

    public class TagsController : BaseApiController
    {
        [HttpGet]
        public IQueryable<TagModel> GetAllTags(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.GetValidUser(sessionKey);

                var context = new BloggingSystemContext();

                var models =
                    (from tagEnt in context.Tags
                     select new TagModel()
                     {
                         Id = tagEnt.Id,
                         Name = tagEnt.Title,
                         Posts = tagEnt.Posts.Count
                     }).OrderBy(tg => tg.Name);

                return models;
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("posts")]
        public IQueryable<GetPostModel> GetPostByTag(
            int tagId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                this.GetValidUser(sessionKey);

                var context = new BloggingSystemContext();
                
                    var tag = context.Tags.Where(tg => tg.Id == tagId).FirstOrDefault();
                    var allModels = context.Posts.Where(ps => ps.Tags.Any(tg => tg.Id == tag.Id));

                    var filteredModels =
                        (from postEnt in allModels.ToList()
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
                        }).OrderByDescending(ps => ps.PostDate);

                    return filteredModels.AsQueryable();
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
    }
}
