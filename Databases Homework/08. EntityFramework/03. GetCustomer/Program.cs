namespace GetCustomer
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
                var searchResult = from order in northwindEntities.Orders
                              where order.OrderDate.Value.Year == orderDate && order.ShipCountry == shipDestination
                              select order;

                foreach (var customer in searchResult)
                {
                    Console.WriteLine("Customer: {0}", customer.Customer.ContactName);
                }
            }
        }

        public static void Main()
        {
            FindAllClients(1997, "Canada");
        }
    }
}
