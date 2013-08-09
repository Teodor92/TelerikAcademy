namespace OrderAdd
{
    using System;
    using System.Linq;
    using _01.DataModel;

    public class Program
    {
        public static void Main(string[] args)
        {
            Employee extended = new Employee();

            NorthwindEntities dbContext = new NorthwindEntities();

            extended = dbContext.Employees.Find(1);

            foreach (var item in extended.Territories)
            {
                Console.WriteLine("Teritory description - {0}", item.TerritoryDescription);
            }
        }
    }
}
