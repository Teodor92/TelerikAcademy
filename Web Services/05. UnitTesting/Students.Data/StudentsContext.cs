using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Students.Models;


namespace Students.Data
{
    public class StudentsContext : DbContext
    {
        public StudentsContext() 
            : base("StudentsDb")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<School> Schools { get; set; }
    }
}
