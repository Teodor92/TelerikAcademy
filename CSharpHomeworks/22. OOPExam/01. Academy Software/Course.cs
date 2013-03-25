using System;
using System.Collections.Generic;
using System.Text;

namespace SoftwareAcademy
{
    public abstract class Course : ICourse
    {
        // fileds and autoprops
        private readonly List<string> topics;
        private string name;

        public ITeacher Teacher { get; set; }

        // constructor
        public Course(string name, ITeacher teacher)
        {
            this.Teacher = teacher;
            this.Name = name;
            this.topics = new List<string>();
        }

        // properties
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }

                this.name = value;
            }
        }

        // methods
        public void AddTopic(string topic)
        {
            this.topics.Add(topic);
        }

        public override string ToString()
        {
            StringBuilder outText = new StringBuilder();

            if (!string.IsNullOrEmpty(this.name))
            {
                outText.AppendFormat("{0}: ", this.GetType().Name);

                outText.AppendFormat("Name={0}", this.Name);

                if (this.Teacher != null)
                {
                    outText.AppendFormat("; Teacher={0}", this.Teacher.Name);
                }

                if (this.topics.Count > 0)
                {
                    outText.AppendFormat("; Topics=[");

                    for (int i = 0; i < this.topics.Count; i++)
                    {
                        outText.Append(this.topics[i]);
                        if (i != this.topics.Count - 1)
                        {
                            outText.Append(", ");
                        }
                    }

                    outText.Append("]");
                }
            }

            return outText.ToString();
        }
    }
}