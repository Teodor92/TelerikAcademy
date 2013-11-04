namespace BloggingSystem.Test.Integration
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Transactions;
    using System.Web.Http;
    using BloggingSystem.Api.Controllers;
    using BloggingSystem.Api.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class LogoutServiceTests
    {
        private static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(UsersController);
            tran = new TransactionScope();

            var routes = new List<Route>
            {
                new Route(
                    "TagsApi",
                    "api/tags/{tagId}/{action}",
                        new
                        {
                            controller = "tags",
                        }),
                new Route(
                    "PostsApi",
                    "api/posts/{postId}/{action}",
                        new
                        {
                            controller = "posts",
                        }),
                new Route(
                     "UsersApi",
                     "api/users/{action}",
                     new
                        {
                            controller = "users"
                        }),
                        
                new Route(
                    "DefaultApi",
                    "api/{controller}/{id}",
                    new { id = RouteParameter.Optional }),
            };

            this.httpServer = new InMemoryHttpServer("http://localhost/", routes);
        }

        [TestCleanup]
        public void TearDown()
        {
            tran.Dispose();
        }

        [TestMethod]
        public void Logout_WhenParamsAreValid_ShouldLogout()
        {
            var testUser = this.RegisterTestUser();
            string sessionKey = testUser.SessionKey;

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Put("api/users/logout", new object[] { }, headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void Logout_WhenParamsAreNOTValid_SessionKeyIsNull()
        {
            string sessionKey = null;

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Put("api/users/logout", new object[] { }, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Logout_WhenParamsAreNOTValid_SessionKeyIsEmpty()
        {
            string sessionKey = string.Empty;

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Put("api/users/logout", new object[] { }, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Logout_WhenParamsAreNOTValid_SessionKeyIsWhiteSpaces()
        {
            string sessionKey = "                  ";

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Put("api/users/logout", new object[] { }, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Logout_WhenParamsAreNOTValid_SessionKeyHasInvalidLength()
        {
            string sessionKey = "XXXXXXXXXXXXXXXXXX";

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Put("api/users/logout", new object[] { }, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private LoggedUserModel RegisterTestUser()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);

            return userModel;
        }
    }
}
