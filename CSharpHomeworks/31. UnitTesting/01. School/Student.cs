namespace School
{
    using System;

    public class Student
    {
        // fileds
        private string name;
        private int uniqeNumber;

        // constructors
        public Student(string name, int uniqeNumber)
        {
            this.Name = name;
            this.UniqeNumber = uniqeNumber;
        }

        // fileds
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name can not be empty!");
                }

                this.name = value;
            }
        }

        public int UniqeNumber
        {
            get
            {
                return this.uniqeNumber;
            }
            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("Id number is ot of range!");
                }

                this.uniqeNumber = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Student {0}, ID {1}; ", this.Name, this.UniqeNumber);
        }
    }
}
