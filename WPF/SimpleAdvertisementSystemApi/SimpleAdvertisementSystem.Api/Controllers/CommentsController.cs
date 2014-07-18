using SimpleAdvertisementSystem.Api.Models;
using SimpleAdvertisementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleAdvertisementSystem.Api.Controllers
{
    public class CommentsController : BaseApiController
    {
        [HttpGet]
        public IQueryable<CommentModel> GetAllComments()
        {
            var responseMsg = this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new AdvertisementSystemContext();
                var models = context.Comments.Select(comment => new CommentModel() 
                { 
                    Text = comment.Text,
                    CommentedBy = comment.User.Username,
                    PostDate = comment.CommentDate
                });

                return models;
            }).OrderByDescending(x => x.PostDate);

            return responseMsg;
        }
    }
}
