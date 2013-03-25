using System.Collections.Generic;
using System.Text;

namespace SoftwareAcademy
{
    public class Teacher : ITeacher
    {
        // fields and autoprops
        private List<ICourse> courses;

        public string Name { get; set; }

        // constructors
        public Teacher(string name)
        {
            courses = new List<ICourse>();
            this.Name = name;
        }

        // methods
        public void AddCourse(ICourse course)
        {
            this.courses.Add(course);
        }

        public override string ToString()
        {
            StringBuilder outText = new StringBuilder();

            outText.Append("Teacher: ");
            outText.AppendFormat("Name={0}", this.Name);
            if (this.courses.Count > 0)
            {
                outText.Append("; Courses=[");
                for (int i = 0; i < this.courses.Count; i++)
                {
                    outText.Append(this.courses[i].Name);
                    if (i != this.courses.Count - 1)
                    {
                        outText.Append(", ");
                    }
                }

                outText.Append("]");
            }

            return outText.ToString();
        }
    }
}