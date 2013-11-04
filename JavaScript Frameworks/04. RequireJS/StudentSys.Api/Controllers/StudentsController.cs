using StudentInfoSystem.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentSys.Api.Controllers
{
    public class StudentsController : ApiController
    {
        private new List<StudentModel> students = new List<StudentModel>()
        {
            new StudentModel() {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Iliev",
                 Age = 11,
                 Marks = new List<GradeModel>()
                 {
                    new GradeModel() 
                    {
                        Subject ="Math",
                        Value = 3
                    },
                    new GradeModel()
                    {
                        Subject = "Bio",
                        Value = 4
                    }
                 }
            },

            new StudentModel() {
                Id = 2,
                FirstName = "Stoian",
                LastName = "Stoinev",
                 Age = 11,
                 Marks = new List<GradeModel>()
                 {
                    new GradeModel() 
                    {
                        Subject ="Math",
                        Value = 2
                    },
                    new GradeModel()
                    {
                        Subject = "Bio",
                        Value = 5
                    }
                 }
            },
        };

        [HttpGet]
        public IQueryable<StudentModel> GetAll()
        {
            return this.students.AsQueryable();
        }

        [HttpGet]
        [ActionName("marks")]
        public IQueryable<GradeModel> GetMarksById(int studentId)
        {
            var student = this.students.FirstOrDefault(st => st.Id == studentId);
            return student.Marks.AsQueryable();
        }
    }
}
