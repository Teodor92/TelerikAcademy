using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.Model
{
    [DataContract]
    public class Student
    {
        public Student()
        {
            this.Marks = new HashSet<Grade>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public virtual ICollection<Grade> Marks { get; set; }
    }
}