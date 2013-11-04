using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Students.Models;
using Students.Repos;
using Students.Api.Controllers;
using Students.Data;

namespace Students.Test.Integration
{
    public class TestPlacesDependencyResolver<T> : IDependencyResolver
    {
        private StudentsContext studentsContext = new StudentsContext();
        private IRepository<Student> studentsRepo = new EfRepository<Student>(studentsContext);
        private IRepository<Mark> markRepo = new EfRepository<Mark>(studentsContext);
        private IRepository<School> schoolRepo = new EfRepository<School>(studentsContext);

        public IRepository<Student> StudentsRepo
        {
            get
            {
                return studentsRepo;
            }
            set
            {
                studentsRepo = value;
            }
        }

        public IRepository<Mark> MarkRepo
        {
            get
            {
                return markRepo;
            }
            set
            {
                markRepo = value;
            }
        }

        public IRepository<School> SchoolRepo
        {
            get
            {
                return schoolRepo;
            }
            set
            {
                schoolRepo = value;
            }
        }

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
