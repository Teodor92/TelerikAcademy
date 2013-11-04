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
    public class PostComment
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
        public void PostComment_WhenModelValid_ShouldSaveToDatabase()
        {
            var testUser = this.RegisterTestUser();

            var testComment = new CommentModel()
            {
                Text = "Wow cool story bro!",
            };

            string sessionKey = testUser.SessionKey;

            int testPostId = this.PostATestPost(sessionKey);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Put(string.Format("api/posts/{0}/comment", testPostId), testComment, headers);

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
        }

        [TestMethod]
        public void PostComment_WhenModelInvalid_CommentTextIsTooShort()
        {
            var testUser = this.RegisterTestUser();

            var testComment = new CommentModel()
            {
                Text = "Cool.",
            };

            string sessionKey = testUser.SessionKey;

            int testPostId = this.PostATestPost(sessionKey);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Put(string.Format("api/posts/{0}/comment", testPostId), testComment, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostComment_WhenModelInvalid_CommentTextIsNull()
        {
            var testUser = this.RegisterTestUser();

            var testComment = new CommentModel()
            {
                Text = null,
            };

            string sessionKey = testUser.SessionKey;

            int testPostId = this.PostATestPost(sessionKey);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Put(string.Format("api/posts/{0}/comment", testPostId), testComment, headers);
 
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostComment_WhenModelInvalid_CommentTextIsWhiteSpaces()
        {
            var testUser = this.RegisterTestUser();

            var testComment = new CommentModel()
            {
                Text = "                                                                      ",
            };

            string sessionKey = testUser.SessionKey;

            int testPostId = this.PostATestPost(sessionKey);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Put(string.Format("api/posts/{0}/comment", testPostId), testComment, headers);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void PostComment_WhenModelInvalid_CommentTextIsEmpty()
        {
            var testUser = this.RegisterTestUser();

            var testComment = new CommentModel()
            {
                Text = string.Empty,
            };

            string sessionKey = testUser.SessionKey;

            int testPostId = this.PostATestPost(sessionKey);

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Put(string.Format("api/posts/{0}/comment", testPostId), testComment, headers);

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

        private int PostATestPost(string sessionKey)
        {
            var testPost = new PostModel()
            {
                Tags = new string[] { "cool", "game" },
                Text = "Wow that was a great game!",
                Title = "Age of empires"
            };

            var headers = new Dictionary<string, string>();
            headers["X-sessionKey"] = sessionKey;

            var response = this.httpServer.Post("api/posts", testPost, headers);
            var contentString = response.Content.ReadAsStringAsync().Result;
            PostResponseModel postModel = JsonConvert.DeserializeObject<PostResponseModel>(contentString);

            return postModel.Id;
        }
    }
}