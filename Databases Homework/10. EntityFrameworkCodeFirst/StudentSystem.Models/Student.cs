namespace StudentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Student
    {
        private ICollection<Course> courses;
        private ICollection<Homework> homeworks;

        public Student()
        {
            this.courses = new HashSet<Course>();
        }

        public int StudentId { get; set; }

        public string Name { get; set; }

        public string Sex { get; set; }

        public int StudentNumber { get; set; }

        public ICollection<Course> Courses
        {
            get { return this.courses; }
            set { this.courses = value; }
        }

        public ICollection<Homework> Homeworks
        {
            get { return this.homeworks; }
            set { this.homeworks = value; }
        }
    }
}
