namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class OffsiteCourse : Course
    {
        public string Town { get; set; }

        public OffsiteCourse(string courseName)
            : base(courseName, null, null)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName, null)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
            this.Town = null;
        }

        public override string ToString()
        {
            if (this.Town != null)
            {
                return string.Format("{0}{1}{2}{3}", base.ToString(), "; Town = ", this.Town, "}");
            }
            else
            {
                return string.Format("{0}{1}", base.ToString(), "}");
            }
        }
    }
}
