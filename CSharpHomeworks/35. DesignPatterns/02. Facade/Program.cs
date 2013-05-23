namespace Facade.Example
{
    using System;

    /// <summary>
    /// MainApp startup
    /// Facade Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Facade
            Mortgage mortgage = new Mortgage();

            // Evaluate mortgage eligibility for customer
            Customer customer = new Customer("Pesho");

            bool eligible = mortgage.IsEligible(customer, 125000);

            Console.WriteLine();
            Console.WriteLine("{0} has been {1}", customer.Name, eligible ? "Approved" : "Rejected");
        }
    }
}
