namespace MyAnimal
{
    using System;
    using System.Linq;

    public enum Sex
    { 
        Male,
        Female
    }

    public class Animal
    {
        private string name;
        private int age;
        private Sex sex;

        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public Animal(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
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
                this.age = value;
            }
        }

        public Sex Sex
        {
            get
            {
                return this.sex;
            }

            set
            {
                this.sex = value;
            }
        }

        public static void AgeAverage(Animal[] myZoo)
        {
            var grouped =  myZoo.GroupBy(x => x.GetType());

            foreach (var item in grouped)
            {
                Console.WriteLine("{0} - {1}", item.Key.Name, item.Average(x => x.Age));
            }
        }
    }
}