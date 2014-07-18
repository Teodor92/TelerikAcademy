namespace _11.ChangeingValues
{
    using System;

    /// <summary>
    /// Declare  two integer variables and assign them with 5 and 10 and after that exchange their values.
    /// </summary>
    public class ChangeingValues
    {
        internal static void Main()
        {
            int firstValue = 5;
            int secondValue = 10;

            int oldValue = firstValue;
            firstValue = secondValue;
            secondValue = oldValue;
            Console.WriteLine("The value of \" a \" is {0} and the value of \" b \" is {1}", firstValue, secondValue);
        }
    }
}
