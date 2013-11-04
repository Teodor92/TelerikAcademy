using Students.Api.Controllers;
using Students.Data;
using Students.Models;
using Students.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace Students.Api.Resolvers
{
    public class DbDependencyResolver : IDependencyResolver
    {
        private static StudentsContext studentsContext = new StudentsContext();
        private static IRepository<Student> studentsRepo = new EfRepository<Student>(studentsContext);
        private static IRepository<Mark> markRepo = new EfRepository<Mark>(studentsContext);
        private static IRepository<School> schoolRepo = new EfRepository<School>(studentsContext);

        public IDependencyScope BeginScope()
        {
            return this;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == typeof(MarksController))
            {
                return new MarksController(markRepo, studentsRepo);
            }
            else if (serviceType == typeof(StudentsController))
            {
                return new StudentsController(studentsRepo, schoolRepo, markRepo);
            }
            else if (serviceType == typeof(SchoolsController))
            {
                return new SchoolsController(schoolRepo);
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return new List<object>();
        }

        public void Dispose()
        {
        }
    }
}