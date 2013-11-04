using Students.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Students.Api.Models
{
    public class MarksModel
    {
        public int Id { get; set; }

        public string Subject { get; set; }

        public int Value { get; set; }
    }
}