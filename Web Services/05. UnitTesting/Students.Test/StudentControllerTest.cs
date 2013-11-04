using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using System.Web.Http.Hosting;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using Students.Api.Controllers;
using Students.Data;
using Students.Models;
using Students.Repos;
using Telerik.JustMock;

namespace Students.Test
{
    [TestClass]
    public class StudentControllerTest
    {
        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/students");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "students");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [Ignore]
        [TestMethod]
        public void GetAll_WhenASingleCategoryInRepository_ShouldReturnSingleCategory()
        {

            var studentRepo = Mock.Create<IRepository<Student>>();
            var schoolRepo = Mock.Create<IRepository<School>>();
            var markRepo = Mock.Create<IRepository<Mark>>();

            var studentToAdd = new Student()
            {
                FirstName = "Test category",
                School = new School() { Name = "dafq" },
                Marks = new List<Mark>() { markRepo.All().First() }
            };

            IList<Student> studentEntities = new List<Student>();
            studentEntities.Add(studentToAdd);
            Mock.Arrange(() => studentRepo.All()).Returns(() => studentEntities.AsQueryable());

            var controller = new StudentsController(studentRepo, schoolRepo, markRepo);

            var categoryModels = controller.Get();
            Assert.IsTrue(categoryModels.Count() == 1);
            Assert.AreEqual(studentToAdd.FirstName, categoryModels.First().FirstName);
        }
    }
}
