using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyForum.Api.Controllers;
using System.Transactions;
using MyForum.Api.Models;
using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using System.Net;

namespace MyForum.Test.Integration
{
    [TestClass]
    public class ThreadsControllerIntegrationTests
    {
        static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {

            var type = typeof(UsersController);
            tran = new TransactionScope(
            TransactionScopeOption.Required,
                new TransactionOptions()
                {
                    IsolationLevel = IsolationLevel.ReadUncommitted
                });

            var routes = new List<Route>
            {
                new Route(
                    "PostApi",
                    "api/posts/{postId}/{action}",
                    new
                    {
                        controller = "posts",
                    }),
                new Route(
                    "ThreadsApi",
                    "api/threads/{threadId}/posts",
                    new
                    {
                        controller = "threads",
                        action ="posts"
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
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                Nickname = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            //var httpServer = new InMemoryHttpServer("http://localhost/");
            var model = this.RegisterTestUser(httpServer, testUser);
            Assert.AreEqual(testUser.Nickname, model.Nickname);
            Assert.IsNotNull(model.SessionKey);
        }

        [TestMethod]
        public void GetAll_WhenDataInDatabase_ShouldReturnData()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                Nickname = "VALIDNICK",
                AuthCode = new string('b', 40)
            };
            LoggedUserModel userModel = RegisterTestUser(httpServer, testUser);
            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = userModel.SessionKey;
            var response = httpServer.Get("api/threads", headers);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        private LoggedUserModel RegisterTestUser(InMemoryHttpServer httpServer, UserModel testUser)
        {
            var response = httpServer.Post("api/users/register", testUser);
            var contentString = response.Content.ReadAsStringAsync().Result;
            var userModel = JsonConvert.DeserializeObject<LoggedUserModel>(contentString);
            return userModel;
        }
    }
}
