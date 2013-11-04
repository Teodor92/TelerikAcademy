using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Api.Models
{
    public class StudentsModelFull : StudentsModel
    {
        public virtual IEnumerable<MarksModel> Marks { get; set; }

        public virtual SchoolsModel School { get; set; }
    }
}