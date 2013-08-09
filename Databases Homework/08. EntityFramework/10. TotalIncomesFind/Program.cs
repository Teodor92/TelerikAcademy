namespace TotalIncomesFind
{
    /*
     * Use this SQL code to create the procedure in the Northwind DB.
     * 
     * CREATE PROC [dbo].[usp_FindIncome](
  @supplierName  nvarchar(50) = '',
  @startDate date,
  @endDate date) 
  AS

  SELECT s.CompanyName ,det.UnitPrice*det.Quantity*(1 - det.Discount) as TotalIncome
  FROM Suppliers s
  JOIN Products ord
	ON s.SupplierID = ord.SupplierID
  JOIN [Order Details] det
	ON ord.ProductID = det.ProductID
  JOIN Orders o
	ON det.OrderID = o.OrderID
   WHERE s.CompanyName = @supplierName AND o.OrderDate >= @startDate AND o.OrderDate <= @endDate
   ORDER BY TotalIncome
     */

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using _01.DataModel;

    public class Program
    {
        public static void Main(string[] args)
        {
            using (NorthwindEntities dbContext = new NorthwindEntities())
            {
                var result = dbContext.usp_FindIncome("Exotic Liquids", DateTime.Parse("02/02/1995"), DateTime.Parse("02/02/2000"));

                Console.WriteLine(dbContext.usp_FindIncome("Exotic Liquids", DateTime.Parse("02/02/1995"), DateTime.Parse("02/02/2000")));

                foreach (var item in result)
                {
                    Console.WriteLine("Company Name: {0}, Total Income: {1}", item.CompanyName, item.TotalIncome);
                }
            }
        }
    }
}
