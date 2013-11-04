using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StudentInfoSystem.Api.Models
{
    [DataContract]
    public class GradeModel
    {
        [DataMember(Name = "value")]
        public int Value { get; set; }

        [DataMember(Name = "subject")]
        public string Subject { get; set; }
    }
}