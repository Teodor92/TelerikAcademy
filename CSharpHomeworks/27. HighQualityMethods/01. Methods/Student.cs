namespace Methods
{
    using System;

    public class Student
    {
        private string firstName;
        private string lastName;
        private DateTime dateOfBirth;

        public string City { get; set; }

        public string Hobby { get; set; }

        public Student(string firstName, string lastName, string dateOfBirth, string city = null, string hobby = null)
        {
            DateTime parsedDayOfBirth;
            if (!DateTime.TryParse(dateOfBirth, out parsedDayOfBirth))
            {
                throw new FormatException("Incorrect Date format! Suggest to (15.04.1999)");
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = parsedDayOfBirth;
            this.City = city;
            this.Hobby = hobby;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value.Length == 0 || value == null)
                {
                    throw new ArgumentException("First name is not valid!");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                if (value.Length == 0 || value == null)
                {
                    throw new ArgumentException("Second name is not valid!");
                }

                this.lastName = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return this.dateOfBirth;
            }

            set
            {
                if (value.Year > DateTime.Now.Year || value.Year < 1900)
                {
                    throw new ArgumentException("Inavlid birthday");
                }

                this.dateOfBirth = value;
            }
        }

        public bool IsOlderThan(Student otherStudent)
        {
            bool isOlder = this.DateOfBirth > otherStudent.DateOfBirth;
            return isOlder;
        }
    }
}