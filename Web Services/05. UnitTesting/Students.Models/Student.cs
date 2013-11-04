using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Students.Models
{
    public class Student
    {
        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public int SchoolId { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }

        [ForeignKey("SchoolId")]
        public virtual School School { get; set; }
    }
}
