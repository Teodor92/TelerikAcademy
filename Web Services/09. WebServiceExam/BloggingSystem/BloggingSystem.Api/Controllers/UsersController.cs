namespace BloggingSystem.Api.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Web.Http;
    using System.Web.Http.ValueProviders;
    using BloggingSystem.Api.Attributes;
    using BloggingSystem.Api.Models;
    using BloggingSystem.Data;
    using BloggingSystem.Models;

    public class UsersController : BaseApiController
    {
        private const string SessionKeyChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        private const int SessionKeyLength = 50;
        private const int Sha1CodeLength = 40;
        private const string ValidUsernameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890";
        private const string ValidDisplayNameChars = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM_1234567890 -";
        private const int MinUsernameLength = 6;
        private const int MaxUsernameLength = 30;
        private static readonly Random randGen = new Random();

        [HttpPost]
        [ActionName("register")]
        public HttpResponseMessage PostRegisterUser(UserModel model)
        {
            var responseMsg = this.PerformOperationAndHandleExceptions(() =>
            {
                var context = new BloggingSystemContext();
                using (context)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateNickname(model.DisplayName);
                    this.ValidateAuthCode(model.AuthCode);

                    var usernameLower = model.Username.ToLower();
                    var nicknameLower = model.DisplayName.ToLower();

                    var user = context.Users
                        .FirstOrDefault(usr => usr.Username == usernameLower ||
                            usr.DisplayName == nicknameLower);

                    if (user != null)
                    {
                        throw new InvalidOperationException("User exists");
                    }

                    user = new User()
                    {
                        Username = usernameLower,
                        DisplayName = model.DisplayName,
                        AuthCode = model.AuthCode,
                    };

                    context.Users.Add(user);
                    context.SaveChanges();

                    user.SessionKey = this.GenerateSessionKey(user.Id);
                    context.SaveChanges();

                    var loggedModel = new LoggedUserModel()
                    {
                        DisplayName = user.DisplayName,
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
                var context = new BloggingSystemContext();
                using (context)
                {
                    this.ValidateUsername(model.Username);
                    this.ValidateAuthCode(model.AuthCode);

                    var usernameLower = model.Username.ToLower();
                    var nicknameLower = model.DisplayName.ToLower();

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
                        var sesKey = this.GenerateSessionKey(user.Id);
                        ValidateSessionKey(sesKey);
                        user.SessionKey = sesKey;
                        context.SaveChanges();
                    }

                    var loggedModel = new LoggedUserModel()
                    {
                        DisplayName = user.DisplayName,
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
                ValidateSessionKey(sessionKey);

                var context = new BloggingSystemContext();
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
                sessionKeyBuilder.Append(SessionKeyChars[index]);
            }

            return sessionKeyBuilder.ToString();
        }

        private void ValidateNickname(string displayName)
        {
            if (string.IsNullOrWhiteSpace(displayName))
            {
                throw new ArgumentNullException("Username can not be null or emty.");
            }

            if (displayName.Any(ch => !ValidDisplayNameChars.Contains(ch)))
            {
                throw new ArgumentException("Invalid characters int he username.");
            }
        }

        private void ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username can not be null or empty.");
            }

            if (username.Length < MinUsernameLength || username.Length > MaxUsernameLength)
            {
                throw new ArgumentException("Username has invalid length.");
            }

            if (username.Any(ch => !ValidUsernameChars.Contains(ch)))
            {
                throw new ArgumentException("Invalid characters int he username.");
            }
        }

        private void ValidateAuthCode(string authCode)
        {
            if (string.IsNullOrWhiteSpace(authCode))
            {
                throw new ArgumentException("AuthCode can not be null or empty.");
            }

            if (authCode.Length != Sha1CodeLength)
            {
                throw new ArgumentException("Invalid authentication code length");
            }
        }

        private void ValidateSessionKey(string sessinKey)
        {
            if (string.IsNullOrWhiteSpace(sessinKey))
            {
                throw new ArgumentException("Session key can not be null or empty.");
            }

            if (sessinKey.Length != SessionKeyLength)
            {
                throw new ArgumentException("Invalid Session key length");
            }
        }
    }
}
