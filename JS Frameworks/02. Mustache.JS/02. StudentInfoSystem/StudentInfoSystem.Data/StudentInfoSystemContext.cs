using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInfoSystem.Model;

namespace StudentInfoSystem.Data
{
    public class StudentInfoSystemContext : DbContext
    {
        public StudentInfoSystemContext() : base("StudentInfoDatabase")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Grade> Grades { get; set; }
    }
}
