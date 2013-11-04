namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class LocalCourse : Course
    {
        public string Lab { get; set; }

        public LocalCourse(string name)
            : base(name, null, null)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName, null)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Lab = null;
        }

        public override string ToString()
        {
            if (this.Lab != null)
            {
                return string.Format("{0}{1}{2}{3}", base.ToString(), "; Lab = ", this.Lab, "}");
            }
            else
            {
                return string.Format("{0}{1}", base.ToString(), "}");
            }
        }
    }
}
