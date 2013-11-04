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
    public class StudentsController : BaseApiController
    {
        private IRepository<Student> studentRepo;
        private IRepository<School> schoolRepo;
        private IRepository<Mark> markRepo;

        public StudentsController(IRepository<Student> studentRepostiry,
            IRepository<School> schoolRepo, IRepository<Mark> markRepository)
        {
            this.studentRepo = studentRepostiry;
            this.schoolRepo = schoolRepo;
            this.markRepo = markRepository;
        }


        public IQueryable<Student> GetBySubjectAndMark(string subject, double mark)
        {
              var marks =  this.markRepo.All()
                .Where(st => st.Subject == subject && st.Value == mark)
                .AsQueryable<Mark>();

            var students = this.studentRepo.All().Where(st => marks.Any(x=> x.StudentId == st.Id));

            return students.AsQueryable<Student>();
        }

        [HttpGet]
        // GET api/students
        public IQueryable<StudentsModelFull> Get()
        {
            var allStudents = studentRepo.All();

            var studentModels =
                (from student in allStudents
                 select new StudentsModelFull()
                 {
                     FirstName = student.FirstName,
                     LastName = student.LastName,
                     Age = student.Age,
                     Grade = student.Grade,
                     Id = student.Id,
                     School = new SchoolsModel()
                     {
                         Id = student.School.Id,
                         Location = student.School.Location,
                         Name = student.School.Name
                     },
                     Marks =
                     from mark in student.Marks
                     select new MarksModel()
                     {
                         Id = mark.Id,
                         Subject = mark.Subject,
                         Value = mark.Value
                     }
                 }).ToList();

            return studentModels.AsQueryable();
        }

        [HttpGet]
        public IQueryable<StudentsModel> Get(string subject, double value)
        {
            var httpResponse = this.PerformOperationAndHandleExceptions(() =>
                {
                    var studentEntities = this
                        .GetBySubjectAndMark(subject, value).ToList();
                    var studentModels = new HashSet<StudentsModel>();
                    foreach (var studentEntity in studentEntities)
                    {
                        studentModels.Add(
                            new StudentsModel() 
                            { 
                                FirstName = studentEntity.FirstName,
                                LastName = studentEntity.LastName,
                                Age = studentEntity.Age,
                                Grade = studentEntity.Grade
                            });
                    }

                    return studentModels.AsQueryable<StudentsModel>();
                });

            return httpResponse;
        }

        // GET api/students/5
        public StudentsModelFull Get(int id)
        {
            var student = studentRepo.Get(id);
            var schools = schoolRepo.All().ToList();

            var studentModel = new StudentsModelFull()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Age = student.Age,
                Grade = student.Grade,
                Id = student.Id,
                School =
                (from school in schools
                 where school.Students.Contains(student)
                 select new SchoolsModel()
             {
                 Id = school.Id,
                 Location = school.Location,
                 Name = school.Name
             }).FirstOrDefault(),
                Marks =
                from mark in student.Marks
                select new MarksModel()
                {
                    Id = mark.Id,
                    Subject = mark.Subject,
                    Value = mark.Value
                }
            };

            return studentModel;
        }

        //public IQueryable<StudentsModelFull> Get(string subject, int value)
        //{
        //    var allStudents = studentRepo.All();

        //    var studentModels =
        //        (from student in allStudents
        //         select new StudentsModelFull()
        //         {
        //             FirstName = student.FirstName,
        //             LastName = student.LastName,
        //             Age = student.Age,
        //             Grade = student.Grade,
        //             Id = student.Id,
        //             School = new SchoolsModel()
        //             {
        //                 Id = student.School.Id,
        //                 Location = student.School.Location,
        //                 Name = student.School.Name
        //             },
        //             Marks =
        //             from mark in student.Marks
        //             select new MarksModel()
        //             {
        //                 Id = mark.Id,
        //                 Subject = mark.Subject,
        //                 Value = mark.Value
        //             }
        //         }).ToList();

        //    return studentModels.AsQueryable();
        //}

        // POST api/students
        public void Post([FromBody]StudentsModel value)
        {
            this.studentRepo.Add(new Student() 
            { 
                FirstName = value.FirstName,
                LastName = value.LastName,
                Age = value.Age,
                Grade = value.Grade,
            });
        }

        // PUT api/students/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/students/5
        public void Delete(int id)
        {
        }
    }
}
