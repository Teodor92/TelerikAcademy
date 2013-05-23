namespace School
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Course
    {
        // fileds
        public const byte MaxSutentsInCourse = 29;

        private string courseName;

        public List<Student> Students { get; protected set; }

        // constructors
        public Course(string courseName)
        {
            this.CourseName = courseName;
            this.Students = new List<Student>();
        }

        // properties
        public string CourseName
        {
            get
            {
                return this.courseName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Course name can not be empty!");
                }

                this.courseName = value;
            }
        }

        // methods
        public void AddStudent(Student newStudent)
        {
            bool studentExists = this.CheckIfStudentExists(newStudent);

            if (studentExists)
            {
                throw new ArgumentException("The student is already enrolled for this course.");
            }

            if (this.Students.Count <= MaxSutentsInCourse)
            {
                this.Students.Add(newStudent);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Class is full!");
            }
        }

        public void RemoveStudent(Student student)
        {
            bool studentFound = this.CheckIfStudentExists(student);

            if (!studentFound)
            {
                throw new ArgumentException("There is no such student in the course.");
            }

            this.Students.Remove(student);
        }

        public bool CheckIfStudentExists(Student student)
        {
            bool studentFound = false;

            for (int i = 0; i < this.Students.Count; i++)
            {
                if (this.Students[i].UniqeNumber == student.UniqeNumber)
                {
                    studentFound = true;
                    break;
                }
            }

            return studentFound;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(string.Format("Course name {0}; ", this.CourseName));

            for (int i = 0; i < this.Students.Count; i++)
            {
                output.Append(this.Students[i]);
            }

            return output.ToString();
        }
    }
}
