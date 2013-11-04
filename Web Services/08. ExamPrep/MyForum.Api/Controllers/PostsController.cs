using MyForum.Api.Attributes;
using MyForum.Api.Models;
using MyForum.Data;
using MyForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace MyForum.Api.Controllers
{
    public class PostsController : BaseApiController
    {
        [HttpGet]
        public IQueryable<PostModel> GetAllPosts()
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new MyForumContext();

                var models =
                    context.Posts
                    .ToList()
                    .Select(post => new PostModel()
                    {
                        Contetn = post.Content,
                        PostDate = post.PostDate,
                        PostedBy = post.User.Nickname,
                        Rating = string.Format("{0:0.00}/5", post.Votes.Average(ps => ps.Value))
                    }).OrderByDescending(ps => ps.PostDate);

                //    (from post in context.Posts
                //    select new PostModel()
                //    {
                //        Contetn = post.Content,
                //        PostDate = post.PostDate,
                //        PostedBy = post.User.Nickname,
                //        Rating = (post.Votes.Average(ps => ps.Value).ToString())
                //    }).OrderByDescending(ps => ps.PostDate).ToList();

                return models.AsQueryable();

            });

            return responseMsg;
        }

        [HttpGet]
        public IQueryable<PostModel> GetPostsPages(int page, int count)
        {
            var models = this.GetAllPosts().Skip(page * count).Take(count);
            return models;
        }

        [HttpPost]
        [ActionName("create")]
        public HttpResponseMessage PostPost()
        {
            return null;
        }

        [HttpPost]
        [ActionName("vote")]
        public HttpResponseMessage PostVote(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey, int postId,
            [FromBody]VoteModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new MyForumContext();

                using (context)
                {
                    var user = context.Users.Where(ur => ur.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new ArgumentException("You are not logged in!");
                    }

                    var post = context.Posts.Where(ps => ps.Id == postId).FirstOrDefault();

                    if (post == null)
                    {
                        throw new InvalidOperationException("Invalid vote post");
                    }

                    var vote = new Vote()
                    {
                        Value = model.Value,
                        User = user,
                        Post = post
                    };

                    context.Votes.Add(vote);
                    context.SaveChanges();
                }

                return this.Request.CreateResponse(HttpStatusCode.Created);
            });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("comment")]
        public HttpResponseMessage PostComment([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey, int postId,
            [FromBody]CommentModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new MyForumContext();

                using (context)
                {
                    var user = context.Users.Where(ur => ur.SessionKey == sessionKey).FirstOrDefault();

                    if (user == null)
                    {
                        throw new ArgumentException("You are not logged in!");
                    }

                    var post = context.Posts.Where(ps => ps.Id == postId).FirstOrDefault();

                    if (post == null)
                    {
                        throw new InvalidOperationException("Invalid vote post");
                    }

                    var comment = new Comment()
                    {
                        Content = model.Content,
                        CommentDate = DateTime.Now,
                        Post = post,
                        User = user
                    };

                    context.Comments.Add(comment);
                    context.SaveChanges();
                }

                return this.Request.CreateResponse(HttpStatusCode.Created);
            });

            return responseMsg;
        }
    }
}
