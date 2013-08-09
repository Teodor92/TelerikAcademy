namespace CustomerDAO
{
    using _01.DataModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class DAO
    {
        public static void DeleteCustomerRecored(string customerID)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Customer customer = GetCustomerByID(northwindEntities, customerID);
            northwindEntities.Customers.Remove(customer);
            northwindEntities.SaveChanges();
        }

        public static void UpdateCustomerRecord(string customerID, string companyName)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Customer customer = GetCustomerByID(northwindEntities, customerID);
            customer.CompanyName = companyName;
            northwindEntities.SaveChanges();
        }

        public static int AddCustomerRecord(string comapnyID, string companyName)
        {
            NorthwindEntities northwindEntities = new NorthwindEntities();
            Customer newCustomer = new Customer
            {
                CustomerID = comapnyID,
                CompanyName = companyName
            };

            northwindEntities.Customers.Add(newCustomer);
            northwindEntities.SaveChanges();
            return int.Parse(newCustomer.CustomerID);
        }

        private static Customer GetCustomerByID(NorthwindEntities northwindEntities, string customerID)
        {
            Customer customer = northwindEntities.Customers.FirstOrDefault(
                p => p.CustomerID == customerID);

            return customer;
        }
    }
}
