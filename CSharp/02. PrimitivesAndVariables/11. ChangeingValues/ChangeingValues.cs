namespace _11.ChangeingValues
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.
    /// </summary>
    public class ChangeingValues
    {
        public static void Main()
        {
            // Reset console encoding and current culture in order to prevent IO problems
            Console.OutputEncoding = Encoding.Unicode;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            int firstValue = 5;
            int secondValue = 10;

            int oldValue = firstValue;
            firstValue = secondValue;
            secondValue = oldValue;
            Console.WriteLine("The value of \" a \" is {0} and the value of \" b \" is {1}", firstValue, secondValue);
        }
    }
}
