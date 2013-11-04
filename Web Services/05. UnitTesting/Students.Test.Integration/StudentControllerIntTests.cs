using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Telerik.JustMock;
using Students.Models;
using System.Collections.Generic;
using Students.Repos;
using System.Net;

namespace Students.Test.Integration
{
    [TestClass]
    public class StudentControllerIntTests
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [Ignore]
        [TestMethod]
        public void GetAll_WhenOneCategory_ShouldReturnStatusCode200AndNotNullContent()
        {
            var mockRepository = Mock.Create<IRepository<Student>>();
            var models = new List<Student>();
            models.Add(new Student()
            {
                FirstName = "Test Cat"
            });

            //Mock.Arrange(() => mockRepository.All())
            //    .Returns(() => models.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/",
                mockRepository);

            var response = server.CreateGetRequest("api/categories");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }
    }
}
