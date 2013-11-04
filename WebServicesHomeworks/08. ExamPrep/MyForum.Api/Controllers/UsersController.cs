using MyForum.Api.Attributes;
using MyForum.Api.Models;
using MyForum.Data;
using MyForum.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.ValueProviders;

namespace MyForum.Api.Controllers
{
    public class UsersController : BaseApiController
    {
        public IDbContextFactory<DbContext> contextFactory { get; set; }

        public UsersController()
        {
            this.contextFactory = new MyForumDbContextFactory();
        }

        public UsersController(IDbContextFactory<DbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        private string sessionKeyChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";

        private const int SessionKeyLength = 50;

        private static readonly Random randGen = new Random();

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new MyForumContext();
                using (context)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateNickname(model.Nickname);
                    this.ValidateAuthCode(model.AuthCode);

                    var usernameLower = model.Username.ToLower();
                    var nicknameLower = model.Nickname.ToLower();

                    var user = context.Users
                        .FirstOrDefault(usr => usr.Username == usernameLower ||
                            usr.Nickname == nicknameLower);

                    if (user != null)
                    {
                        throw new InvalidOperationException("User exists");
                    }

                    user = new User()
                    {
                        Username = usernameLower,
                        Nickname = model.Nickname,
                        AuthCode = model.AuthCode,
                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    user.SessionKey = this.GenerateSessionKey(user.Id);
                    context.SaveChanges();

                    var loggedModel = new LoggedUserModel()
                    {
                        Nickname = user.Nickname,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(
                        HttpStatusCode.Created, loggedModel);

                    return response;
                }
            });

            return responseMsg;
        }

        [HttpPost]
        [ActionName("login")]
        public HttpResponseMessage PostLoginUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new MyForumContext();
                using (context)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateAuthCode(model.AuthCode);

                    var usernameLower = model.Username.ToLower();
                    var nicknameLower = model.Nickname.ToLower();

                    var user = context.Users
                        .FirstOrDefault(
                        usr => usr.Username == usernameLower &&
                            usr.AuthCode == model.AuthCode);

                    if (user == null)
                    {
                        throw new InvalidOperationException("Invalid name or password");
                    }

                    if (string.IsNullOrWhiteSpace(user.SessionKey))
                    {
                        user.SessionKey = this.GenerateSessionKey(user.Id);
                        context.SaveChanges();
                    }

                    var loggedModel = new LoggedUserModel()
                    {
                        Nickname = user.Nickname,
                        SessionKey = user.SessionKey
                    };

                    var response = this.Request.CreateResponse(
                        HttpStatusCode.OK, loggedModel);

                    return response;
                }
            });

            return responseMsg;
        }

        [HttpPut]
        [ActionName("logout")]
        public HttpResponseMessage PutLogoutUser([ValueProvider(typeof(HeaderValueProviderFactory<string>))] string sessionKey)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
                {
                    var context = new MyForumContext();
                    using (context)
                    {
                        var user = context.Users.Where(ur => ur.SessionKey == sessionKey).FirstOrDefault();

                        if (user != null)
                        {
                            user.SessionKey = null;
                            context.SaveChanges();
                        }

                        return new HttpResponseMessage(HttpStatusCode.OK);
                    }
                });

            return responseMsg;
        }

        /* Validation and generation */
        private string GenerateSessionKey(int id)
        {
            StringBuilder sessionKeyBuilder = new StringBuilder(SessionKeyLength);
            sessionKeyBuilder.Append(id);

            while (sessionKeyBuilder.Length < SessionKeyLength)
            {
                var index = randGen.Next(sessionKeyBuilder.Length);
                sessionKeyBuilder.Append(this.sessionKeyChars[index]);
            }

            return sessionKeyBuilder.ToString();
        }

        private void ValidateNickname(string nickname)
        {
            if (string.IsNullOrWhiteSpace(nickname))
            {
                throw new ArgumentNullException("Username can not be null or emty.");
            }
        }

        private void ValidateUsername(string username)
        {

        }

        private void ValidateAuthCode(string authCode)
        {

        }
    }
}

/*
{  "username": "DonchoMinkov",
   "displayName": "Doncho Minkov",
   "authCode":   "bfff2dd4f1b310eb0dbf593bd83f94dd8d34077e" }
*/
