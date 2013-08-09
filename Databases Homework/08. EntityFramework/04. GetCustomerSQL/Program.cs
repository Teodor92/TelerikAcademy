namespace GetCustomerSQL
{
    using System;
    using System.Linq;
    using _01.DataModel;

    public class Program
    {
        public static void FindAllClients(int orderDate, string shipDestination)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                string searchQuery = @"SELECT c.ContactName from Customers
                                    c INNER JOIN Orders o ON o.CustomerID = c.CustomerID 
                                    WHERE (YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1});";

                object[] queryParams = { orderDate, shipDestination };

                var searchResult = northwindEntities.Database.SqlQuery<string>(searchQuery, queryParams);

                foreach (var customer in searchResult)
                {
                    Console.WriteLine("Customer: {0}", customer);
                }
            }
        }

        public static void Main()
        {
            FindAllClients(1997, "Canada");
        }
    }
}
