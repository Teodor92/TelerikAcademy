using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StudentInfoSystem.Api.Models
{
    [DataContract]
    public class StudentModel
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "firstname")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastname")]
        public string LastName { get; set; }

        [DataMember(Name = "age")]
        public int Age { get; set; }

        [DataMember(Name = "grade")]
        public int Grade { get; set; }

        [DataMember(Name = "marks")]
        public IEnumerable<GradeModel> Marks { get; set; }
    }
}