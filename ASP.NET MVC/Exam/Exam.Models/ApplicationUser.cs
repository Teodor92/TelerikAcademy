using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Models
{
    public class ApplicationUser : User
    {
        [DefaultValue(10)]
        public int Points { get; set; }

        public ApplicationUser() : base()
        {
            this.Points = 10;
        }
    }
}
