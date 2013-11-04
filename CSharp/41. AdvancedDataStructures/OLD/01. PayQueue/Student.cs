namespace PayQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Student : IComparable<Student>
    {
        // fileds
        private string name;
        private int age;
        private bool paidSemesterOnline;

        // constructors
        public Student(string name, int age, bool paidSemesterOnline)
        {
            this.Name = name;
            this.Age = age;
            this.PaidSemesterOnline = paidSemesterOnline;
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Name must not be epmty!");
                }

                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Age must not be negative!");
                }

                this.age = value;
            }
        }

        public bool PaidSemesterOnline
        {
            get
            {
                return this.paidSemesterOnline;
            }

            set
            {
                this.paidSemesterOnline = value;
            }
        }

        // methods
        public int CompareTo(Student other)
        {
            if (other == null)
            {
                return 1;
            }

            return this.PaidSemesterOnline.CompareTo(other.PaidSemesterOnline);
        }

        public override string ToString()
        {
            string output = string.Format("Name: {0}, Age: {1}, Paid Online: {2}", this.Name, this.Age, this.PaidSemesterOnline);
            return output;
        }
    }
}
