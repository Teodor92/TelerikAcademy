using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Api.Models
{
    public class SchoolsModelFull : SchoolsModel
    {
        public virtual IEnumerable<StudentsModel> Students { get; set; }
    }
}