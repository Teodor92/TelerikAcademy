namespace FindSales
{
    using System;
    using System.Linq;
    using _01.DataModel;

    public class Program
    {
        public static void FindAllSales(int startDate, int endDate, string region)
        {
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                var searchResult = from order in northwindEntities.Orders
                                   join ordeDetails in northwindEntities.Order_Details
                                   on order.OrderID equals ordeDetails.OrderID
                                   where order.ShipRegion == region
                                   && order.OrderDate.Value.Year == startDate
                                   && order.ShippedDate.Value.Year == endDate
                                   select new 
                                   { 
                                        Amount = ordeDetails.Quantity,
                                        Region = order.ShipRegion,
                                   };

                foreach (var customer in searchResult)
                {
                    Console.WriteLine("Amount: {0}, Region: {1}", customer.Amount, customer.Region);
                }
            }
        }

        public static void Main()
        {
            FindAllSales(1996, 1996, "AK");
        }
    }
}
