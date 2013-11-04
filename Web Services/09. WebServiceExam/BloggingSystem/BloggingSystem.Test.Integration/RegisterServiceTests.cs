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
    public class RegisterServiceTests
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
        public void Register_WhenUserModelValid_ShouldSaveToDatabase()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDUSER",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var model = this.RegisterTestUser(this.httpServer, testUser);
            Assert.AreEqual(testUser.DisplayName, model.DisplayName);
            Assert.IsNotNull(model.SessionKey);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_UsernameIsEmpty()
        {
            var testUser = new UserModel()
            {
                Username = string.Empty,
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_NicknameIsEmpty()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDNAME",
                DisplayName = string.Empty,
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_AuthCodeIsEmpty()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDNAME",
                DisplayName = "VALIDNICK",
                AuthCode = string.Empty
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_UsernameIsTooShort()
        {
            var testUser = new UserModel()
            {
                Username = "NOOOO",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_UsernameIsTooLong()
        {
            var testUser = new UserModel()
            {
                Username = "YOUSHALLNOTPASSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSSS",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_UsernameHasInvalidChars()
        {
            var testUser = new UserModel()
            {
                Username = "*/%%$$####*&",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_UsernameIsNull()
        {
            var testUser = new UserModel()
            {
                Username = null,
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_DisplayNameIsNull()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDNAME",
                DisplayName = null,
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_AuthCodeIsNull()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDNAME",
                DisplayName = "VALIDNICK",
                AuthCode = null
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_UsernameIsEmptySpaces()
        {
            var testUser = new UserModel()
            {
                Username = "                    ",
                DisplayName = "VALIDNICK",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_DisplayNameIsEmptySpaces()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDNAME",
                DisplayName = "                 ",
                AuthCode = new string('b', 40)
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_AuthCodeIsEmptySpaces()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDNAME",
                DisplayName = "VALIDNICK",
                AuthCode = "                  "
            };

            var response = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [TestMethod]
        public void Register_WhenUserModelIsInvalid_UserAlreadyExists()
        {
            var testUser = new UserModel()
            {
                Username = "VALIDNAME",
                DisplayName = "VALIDNICK",
                AuthCode = "                  "
            };

            this.httpServer.Post("api/users/register", testUser);
            var duplicatPost = this.httpServer.Post("api/users/register", testUser);
            Assert.AreEqual(HttpStatusCode.BadRequest, duplicatPost.StatusCode);
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
