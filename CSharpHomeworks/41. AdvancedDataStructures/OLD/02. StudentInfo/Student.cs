namespace StudentInfo
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private string firstName;
        private string secondName;

        public Student(string firstName, string secondName)
        {
            this.FirstName = firstName;
            this.SecondName = secondName;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name is empty.");
                }

                this.firstName = value;
            }
        }

        public string SecondName
        {
            get
            {
                return this.secondName;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Second name is empty.");
                }

                this.secondName = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1}, ", this.FirstName, this.SecondName);
        }
    }
}
