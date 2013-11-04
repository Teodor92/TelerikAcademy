namespace School
{
    using System;
    using System.Collections.Generic;

    public class School
    {
        public School()
        {
            this.Courses = new List<Course>();
        }

        public List<Course> Courses { get; set; }

        public void AddCourse(Course course)
        {
            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            bool courseFound = CheckForCourse(course);

            if (courseFound)
            {
                this.Courses.Remove(course);
            }
            else
            {
                throw new ArgumentException("The course does not exist.");
            }
        }

        public bool CheckForCourse(Course course)
        {
            bool courseFound = false;

            for (int i = 0; i < this.Courses.Count; i++)
            {
                if (this.Courses[i].CourseName == course.CourseName)
                {
                    courseFound = true;
                    break;
                }
            }

            return courseFound;
        }
    }
}
