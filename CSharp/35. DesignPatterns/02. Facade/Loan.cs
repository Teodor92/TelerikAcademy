namespace Facade.Example
{
    using System;

    /// <summary>
    /// Subsystem A
    /// </summary>
    internal class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for {0}", c.Name);

            return true;
        }
    }
}