namespace StoreClasses
{
    using System;
    using System.Linq;
    using System.Text;

    public class Game : Product
    {
        private string creator;
        private int year;
        private string platform;
        private AgeGroup ageGroup;

        // constructors
        public Game(string name)
            : base(name)
        {
        }

        public Game(string name, int id)
            : base(name, id)
        {
        }

        public Game(string name, int id, decimal price)
            : base(name, id, price)
        {
        }

        public Game(string name, int id, decimal price, string creator, int year, string platform)
            : this(name, id, price)
        {
            this.Creator = creator;
            this.Year = year;
            this.Platform = platform;
        }

        public Game(string name, int id, decimal price, string creator, int year, string platform, AgeGroup ageGroup)
            : this(name, id, price, creator, year, platform)
        {
            this.AgeGroup = ageGroup;
        }

        // properties
        public string Creator
        {
            get
            {
                return this.creator;
            }

            set
            {
                if (value.Length <= 1 || value == null)
                {
                    throw new ArgumentException("Craetor name is too short!");
                }

                this.creator = value;
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

        public string Platform
        {
            get
            {
                return this.platform;
            }

            set
            {
                if (value.Length <= 1 || value == null)
                {
                    throw new ArgumentException("Platform is invalid!");
                }

                this.platform = value;
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

            if (this.Creator != null)
            {
                endText.AppendFormat("Creator: {0}, ", this.creator);
            }

            if (this.Year != 0)
            {
                endText.AppendFormat("Year: {0}, ", this.year);
            }

            if (this.Platform != null)
            {
                endText.AppendFormat("Platform: {0}, ", this.platform);
            }

            if (this.AgeGroup != 0)
            {
                endText.AppendFormat("AgeGroup: {0}, ", this.ageGroup);
            }

            return endText.ToString();
        }
    }
}
