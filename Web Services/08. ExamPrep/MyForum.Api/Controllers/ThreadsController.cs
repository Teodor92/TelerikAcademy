using MyForum.Api.Models;
using MyForum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using MyForum.Api.Attributes;

namespace MyForum.Api.Controllers
{
    public class ThreadsController : BaseApiController
    {
        public IQueryable<ThreadModel> GetAll()
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var context = new MyForumContext();
                    var threadEtities = context.Threads;
                    var models = (
                        from thread in threadEtities
                        select new ThreadModel()
                        {
                            Id = thread.Id,
                            Title = thread.Title,
                            DateCreated = thread.DateCreated,
                            Content = thread.Text,
                            CreatedBy = thread.User.Nickname,
                            Posts = (
                            from post in thread.Posts
                            select new PostModel()
                            {
                                Contetn = post.Content,
                                PostDate = post.PostDate,
                                PostedBy = post.User.Nickname,
                                //Rating = string.Format("{0:0.0}/5", post.Votes.Average(vt => vt.Value).ToString())
                            }
                            ),

                            Categories = (
                                from category in thread.Categories
                                select category.Name)

                        })
                        .OrderByDescending(x => x.DateCreated);

                    return models;
                });

            return responseMsg;
        }

        public IQueryable<ThreadModel> GetPage(int page, int count)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var allThreads = this.GetAll();
                    return allThreads.Skip(page * count).Take(count);
                });

            return responseMsg;
        }
 
        public IQueryable<ThreadModel> GetCategory(string category)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var models = this.GetAll()
                    .Where(tr => tr.Categories
                    .Any(cat => cat == category));
                    return models;

                });

            return responseMsg;
        }

        [HttpPost]
        public HttpRequestMessage PostThread([FromBody]
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            return null;
        }

        [ActionName("posts")]
        public IQueryable<PostModel> GetPosts(int threadId)
        {
            var context = new MyForumContext();

            //var postsEntites = context.Threads.FirstOrDefault(x => x.Id == threadId).Posts;


            PostModel[] models = 
            {
                new PostModel() 
                {
                    Contetn = "First",
                    PostDate = DateTime.Now,
                    PostedBy = "John",
                    Rating = "5/5"
                },

                new PostModel() 
                {
                    Contetn = "Second",
                    PostDate = DateTime.Now,
                    PostedBy = "John",
                    Rating = "5/5"
                },
            };

            return models.AsQueryable();
        }
    }
}
