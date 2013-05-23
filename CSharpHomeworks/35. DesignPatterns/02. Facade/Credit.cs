namespace Facade.Example
{
    using System;

    /// <summary>
    /// Subsystem B
    /// </summary>
    internal class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for {0}", c.Name);

            return true;
        }
    }
}