using SimpleAdvertisementSystem.Api.Models;
using SimpleAdvertisementSystem.Data;
using SimpleAdvertisementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using TasksManager.App.AuthenticationHeaders;

namespace SimpleAdvertisementSystem.Api.Controllers
{
    public class TagsController : BaseApiController
    {
        [HttpGet]
        public IQueryable<TagModel> GetAllTags(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var responseMsg = this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new AdvertisementSystemContext();
                this.GetUserByAccessToken(accessToken, context);

                var models =
                    (from tagEnt in context.Tags
                     select new TagModel()
                     {
                         Id = tagEnt.Id,
                         Name = tagEnt.Title,
                         Posts = tagEnt.Advertisements.Count
                     }).OrderBy(tg => tg.Name);

                return models;
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("posts")]
        public IQueryable<GetAdvertisementModel> GetAdvertisementsByTag(
            int tagId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var responseMsg = this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new AdvertisementSystemContext();
                this.GetUserByAccessToken(accessToken, context);

                var tag = context.Tags.Where(tg => tg.Id == tagId).FirstOrDefault();
                var allModels = context.Advertisements.Where(ps => ps.Tags.Any(tg => tg.Id == tag.Id));

                var filteredModels =
                    (from postEnt in allModels.ToList()
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
                     }).OrderByDescending(ps => ps.PostDate);

                return filteredModels.AsQueryable();
            });

            return responseMsg;
        }

        [HttpPost]
        public HttpResponseMessage PostNewTag(
            [FromBody] TagModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var responseMsg = this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new AdvertisementSystemContext();
                context.Tags.Add(new Tag()
                {
                    Title = model.Name
                });

                context.SaveChanges();

                return this.Request.CreateResponse(HttpStatusCode.Created);
            });

            return responseMsg;
        }
    }
}
