using Students.Api.Models;
using Students.Models;
using Students.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Students.Api.Controllers
{
    public class SchoolsController : ApiController
    {
        private IRepository<School> schoolRepo;

        public SchoolsController(IRepository<School> markRepository)
        {
            this.schoolRepo = markRepository;
        }

        // GET api/school
        public IQueryable<SchoolsModelFull> Get()
        {
            var allSchools = this.schoolRepo.All();

            var schooldModels = (
                from school in allSchools
                select new SchoolsModelFull()
                {
                    Id = school.Id,
                    Name = school.Name,
                    Location = school.Location,
                    Students =
                    from student in school.Students
                    select new StudentsModel() 
                    { 
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Age = student.Age,
                        Grade = student.Grade
                    }
                }).ToList();

            return schooldModels.AsQueryable();
        }

        // GET api/school/5
        public SchoolsModelFull Get(int id)
        {
            var school = schoolRepo.Get(id);

            var model = new SchoolsModelFull()
                {
                    Id = school.Id,
                    Name = school.Name,
                    Location = school.Location,
                    Students =
                    from student in school.Students
                    select new StudentsModel()
                    {
                        Id = student.Id,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Age = student.Age,
                        Grade = student.Grade
                    }
                };

            return model;
        }

        // POST api/school
        public void Post([FromBody]SchoolsModel value)
        {
            this.schoolRepo.Add(new School()
            {
                Location = value.Location,
                Name = value.Name,
            });
        }

        // PUT api/school/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/school/5
        public void Delete(int id)
        {
        }
    }
}
