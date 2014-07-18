using SimpleAdvertisementSystem.Data;
using SimpleAdvertisementSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SimpleAdvertisementSystem.Api.Controllers
{
    public class BaseApiController : ApiController
    {
        protected static Random Rand = new Random();

        protected T ExecuteOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (InvalidOperationException ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, ex.Message);
                throw new HttpResponseException(errResponse);
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }

        protected User GetUserByAccessToken(string accessToken, AdvertisementSystemContext context)
        {
            var user = context.Users.FirstOrDefault(usr => usr.AccessToken == accessToken);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid user credentials");
            }
            return user;
        }
    }
}
