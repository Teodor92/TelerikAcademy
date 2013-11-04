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
    public class MarksController : ApiController
    {
        private IRepository<Mark> markRepo;
        private IRepository<Student> studentRepo;

        public MarksController(IRepository<Mark> markRepository,
            IRepository<Student> studentRepo)
        {
            this.markRepo = markRepository;
            this.studentRepo = studentRepo;
        }

        // GET api/marks
        public IQueryable<MarksModelFull> Get()
        {
            var allMarks = markRepo.All();
            var markModels =
                (from mark in allMarks
                 select new MarksModelFull()
                 {
                     Id = mark.Id,
                     Subject = mark.Subject,
                     Value = mark.Value,
                     Student =
                     new StudentsModel()
                     {
                         Id = mark.Student.Id,
                         FirstName = mark.Student.FirstName,
                         LastName = mark.Student.LastName,
                         Age = mark.Student.Age,
                         Grade = mark.Student.Grade
                     },
                 }).ToList();

            return markModels.AsQueryable();
        }

        // GET api/marks/5
        public MarksModelFull Get(int id)
        {
            var mark = markRepo.Get(id);
            var students = studentRepo.All().ToList();

            var markModel = new MarksModelFull()
            {
                Id = mark.Id,
                Subject = mark.Subject,
                Value = mark.Value,
                Student =
                (from student in students
                 where student.Marks.Contains(mark)
                select new StudentsModel 
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Age = student.Age,
                    Grade = student.Grade
                }).FirstOrDefault()

            };

            return markModel;
        }

        // POST api/marks
        public void Post([FromBody]string value)
        {
        }

        // PUT api/marks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/marks/5
        public void Delete(int id)
        {
        }
    }
}
