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
    public class CreatePostTests
    {
        private static TransactionScope tran;
        private InMemoryHttpServer httpServer;

        [TestInitialize]
        public void TestInit()
        {
            var type = typeof(PostsController);
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
        public void CreatePost_WhenPostModelIsValid_ShouldSaveToDatabase()
        {
            var testPost = new PostModel()
            {
                Tags = new string[] { "cool", "game" },
                Text = "Wow that was a great game!",
                Title = "Age of empires"
            };

            string sessionKey = this.RegisterTestUser();

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Post("api/posts", testPost, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            PostResponseModel postModel = JsonConvert.DeserializeObject<PostResponseModel>(contentString);

            Assert.AreEqual(testPost.Title, postModel.Title);
            Assert.IsNotNull(postModel.Id);
        }

        [TestMethod]
        public void CreatePost_WhenPostModelIsValid_NoTagsGiven()
        {
            var testPost = new PostModel()
            {
                Tags = new string[] { },
                Text = "Smashing game!",
                Title = "Knights of the old republic"
            };

            string sessionKey = this.RegisterTestUser();

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Post("api/posts", testPost, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            PostResponseModel postModel = JsonConvert.DeserializeObject<PostResponseModel>(contentString);

            Assert.AreEqual(testPost.Title, postModel.Title);
            Assert.IsNotNull(postModel.Id);
        }

        [TestMethod]
        public void CreatePost_WhenPostModelIsInvalid_NoTextGiven()
        {
            var testPost = new PostModel()
            {
                Tags = new string[] { },
                Text = string.Empty,
                Title = "Knights of the old republic"
            };

            string sessionKey = this.RegisterTestUser();

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Post("api/posts", testPost, headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void CreatePost_WhenPostModelIsInvalid_TextIsNull()
        {
            var testPost = new PostModel()
            {
                Tags = new string[] { },
                Text = null,
                Title = "Knights of the old republic"
            };

            string sessionKey = this.RegisterTestUser();

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Post("api/posts", testPost, headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void CreatePost_WhenPostModelIsInvalid_TextIsNEmptySpaces()
        {
            var testPost = new PostModel()
            {
                Tags = new string[] { },
                Text = "            ",
                Title = "Knights of the old republic"
            };

            string sessionKey = this.RegisterTestUser();

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Post("api/posts", testPost, headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void CreatePost_WhenPostModelIsInvalid_GivenTextIsTooShort()
        {
            var testPost = new PostModel()
            {
                Tags = new string[] { "gta" },
                Text = "Cool game.",
                Title = "Grand theft auto."
            };

            string sessionKey = this.RegisterTestUser();

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Post("api/posts", testPost, headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void CreatePost_WhenPostModelIsInvalid_TitleIsNull()
        {
            var testPost = new PostModel()
            {
                Tags = new string[] { },
                Text = "Super mega duper game!",
                Title = null
            };

            string sessionKey = this.RegisterTestUser();

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Post("api/posts", testPost, headers);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        private string RegisterTestUser()
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

            return userModel.SessionKey;
        }
    }
}
