namespace _07.DifferentDataContexts
{
    using System;
    using _01.DataModel;

    public class Program
    {
        public static void Main()
        {
            using (NorthwindEntities ent = new NorthwindEntities())
            {
                using (NorthwindEntities entitty = new NorthwindEntities())
                {
                    ent.Customers.Add(new Customer() { CustomerID = "xswde", CompanyName = "CONFLICTTEST" });
                    entitty.Customers.Add(new Customer() { CustomerID = "xldde", CompanyName = "CONFLICTTEST2" }); 
                    entitty.SaveChanges();
                    ent.SaveChanges();
                    entitty.SaveChanges();
                }
            }
        }
    }
}
