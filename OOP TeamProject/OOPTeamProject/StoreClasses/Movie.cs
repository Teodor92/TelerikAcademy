namespace StoreClasses
{
    using System;
    using System.Linq;
    using System.Text;

    public class Movie : Product
    {
        // fields
        private int movieLength;
        private string actor;
        private int year;
        private AgeGroup ageGroup;

        // constructors
        public Movie(string name)
            : base(name)
        {
        }

        public Movie(string name, int id)
            : base(name, id)
        {
        }

        public Movie(string name, int id, decimal price)
            : base(name, id, price)
        {
        }

        public Movie(string name, int id, decimal price, int movieLength, string actor, int year)
            : this(name, id, price)
        {
            this.MovieLength = movieLength;
            this.Actor = actor;
            this.Year = year;
        }

        public Movie(string name, int id, decimal price, int movieLength, string actor, int year, AgeGroup ageGroup)
            : this(name, id, price, movieLength, actor, year)
        {
            this.AgeGroup = ageGroup;
        }

        // properties
        public int MovieLength
        {
            get
            {
                return this.movieLength;
            }

            set
            {
                if (value <= 1)
                {
                    throw new ArgumentException("Ivalid movie length!");
                }

                this.movieLength = value;
            }
        }

        public string Actor
        {
            get
            {
                return this.actor;
            }

            set
            {
                if (value.Length <= 1 || value == null)
                {
                    throw new ArgumentException("Invalid movie length!");
                }

                this.actor = value;
            }
        }

        public int Year
        {
            get
            {
                return this.year;
            }

            set
            {
                if (value < 1960 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException("Ivalid year");
                }

                this.year = value;
            }
        }

        public AgeGroup AgeGroup
        {
            get
            {
                return this.ageGroup;
            }

            set
            {
                this.ageGroup = value;
            }
        }

        public override string Show()
        {
            StringBuilder endText = new StringBuilder();

            if (this.Name != null)
            {
                endText.AppendFormat("Name: {0}, ", this.Name);
            }

            if (this.Id != 0)
            {
                endText.AppendFormat("Id: {0}, ", this.Id);
            }

            if (this.Actor != null)
            {
                endText.AppendFormat("Actor: {0}, ", this.actor);
            }

            if (this.Year != 0)
            {
                endText.AppendFormat("Year: {0}, ", this.year);
            }

            if (this.MovieLength != 0)
            {
                endText.AppendFormat("MovieLength: {0}, ", this.movieLength);
            }

            if (this.AgeGroup != 0)
            {
                endText.AppendFormat("AgeGroup: {0}, ", this.ageGroup);
            }

            return endText.ToString();
        }
    }
}
