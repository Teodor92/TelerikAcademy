namespace BloggingSystem.Test.Integration
{
    using System;
    using System.Collections.Generic;
    using System.Transactions;
    using System.Web.Http;
    using BloggingSystem.Api.Controllers;
    using BloggingSystem.Api.Models;
    using BloggingSystem.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;

    [TestClass]
    public class PostsGetByTagsServiceTests
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
        public void GetPosts_AllParamsArevalid_ShouldGetZeroPost()
        {
            this.ClearDatabase();

            var testPost = new PostModel()
            {
                Tags = new string[] { "test", "tag" },
                Text = "Smashing game!",
                Title = "Knights of the old republic"
            };

            string sessionKey = this.RegisterTestUser().SessionKey;

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            for (int i = 0; i < 3; i++)
            {
                this.httpServer.Post("api/posts", testPost, headers);
            }

            var response = this.httpServer.Get("api/posts?tags=mag,bag", headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            GetPostModel[] postModels = JsonConvert.DeserializeObject<GetPostModel[]>(contentString);

            Assert.AreEqual(0, postModels.Length);
        }

        [TestMethod]
        public void GetPosts_AllParamsArevalid_ShouldGetOnePost()
        {
            this.ClearDatabase();

            var testPost = new PostModel()
            {
                Tags = new string[] { "test", "tag" },
                Text = "Smashing game!",
                Title = "Knights of the old republic"
            };

            string sessionKey = this.RegisterTestUser().SessionKey;

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            for (int i = 0; i < 3; i++)
            {
                this.httpServer.Post("api/posts", testPost, headers);
            }

            var response = this.httpServer.Get("api/posts?tags=tag,test", headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            GetPostModel[] postModels = JsonConvert.DeserializeObject<GetPostModel[]>(contentString);

            Assert.AreEqual(3, postModels.Length);
        }

        private void ClearDatabase()
        {
            var context = new BloggingSystemContext();
            context.Database.ExecuteSqlCommand(@"
            EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'
            EXEC sp_MSForEachTable 'DELETE FROM ?'
            exec sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all'");
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
