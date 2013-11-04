using Exam.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Data
{
    public class ApplicationDbContext : IdentityDbContextWithCustomUser<ApplicationUser>
    {
        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Ticket> Tickets { get; set; }

        public IDbSet<Comment> Comments { get; set; }
    }
}
