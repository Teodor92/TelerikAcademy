using StudentInfoSystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StudentInfoSystem.Data;
using StudentInfoSystem.Api.Models;

namespace StudentInfoSystem.Api.Controllers
{
    public class StudentsController : ApiController
    {
        [HttpGet]
        public IQueryable<StudentModel> GetAll()
        {
            var context = new StudentInfoSystemContext();

            var models = context.Students.Select(st =>
                new StudentModel()
                {
                    FirstName = st.FirstName,
                    LastName = st.LastName,
                    Age = st.Age,
                    Grade = st.Grade,
                    Marks = st.Marks.Select(mr =>
                    new GradeModel() 
                    { 
                        Subject = mr.Subject,
                        Value = mr.Value
                    })
                }
                );

            return models.AsQueryable();
        }
    }
}
