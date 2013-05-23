namespace Proxy.Example
{
    using System;

    /// <summary>
    /// MainApp startup class
    /// Proxy Design Pattern.
    /// </summary>
    public class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        public static void Main()
        {
            // Create math proxy
            MathProxy proxy = new MathProxy();

            // Do the math
            Console.WriteLine("4 + 2 = {0}", proxy.Add(4, 2));

            Console.WriteLine("4 - 2 = {0}", proxy.Sub(4, 2));

            Console.WriteLine("4 * 2 = {0}", proxy.Mul(4, 2));

            Console.WriteLine("4 / 2 = {0}", proxy.Div(4, 2));
        }
    }
}
