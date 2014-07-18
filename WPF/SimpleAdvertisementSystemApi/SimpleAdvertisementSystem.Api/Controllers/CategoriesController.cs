using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using SimpleAdvertisementSystem.Api.Models;
using SimpleAdvertisementSystem.Data;
using SimpleAdvertisementSystem.Model;
using TasksManager.App.AuthenticationHeaders;

namespace SimpleAdvertisementSystem.Api.Controllers
{
    public class CategoriesController : BaseApiController
    {
        [HttpGet]
        public IQueryable<CategoryModel> GetAllCategories(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var responseMsg = this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new AdvertisementSystemContext();
                var models = context.Categories.Select(cat => new CategoryModel()
                {
                    Name = cat.Name,
                    Id=cat.Id,
                    Advertisements = cat.Advertisements.Select(ad => new AdvertisementModel()
                    {
                        Id = ad.Id,
                        Text = ad.Text,
                        Title = ad.Title
                    })
                });

                return models;
            });

            return responseMsg;
        }

        [HttpGet]
        [ActionName("posts")]
        public IQueryable<GetAdvertisementModel> GetAdvertisementsByTag(
            int categoryId,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var responseMsg = this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new AdvertisementSystemContext();
                this.GetUserByAccessToken(accessToken, context);

                var allModels = context.Advertisements.Where(ps => ps.Category.Id == categoryId);

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
        public HttpResponseMessage PostNewCategory(
            [FromBody] CategoryModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))] string accessToken)
        {
            var responseMsg = this.ExecuteOperationAndHandleExceptions(() => 
            {
                var context = new AdvertisementSystemContext();
                var hasCat = context.Categories.FirstOrDefault(x => x.Name == model.Name);

                if (hasCat != null)
                {
                    throw new ArgumentException("Category exists!");
                }

                Category newCat = new Category()
                {
                    Name = model.Name
                };

                context.Categories.Add(newCat);
                context.SaveChanges();

                return this.Request.CreateResponse(HttpStatusCode.Created, newCat);
            });

            return responseMsg;
        }
    }
}
