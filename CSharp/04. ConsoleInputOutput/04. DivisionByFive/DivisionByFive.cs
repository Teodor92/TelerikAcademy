namespace _04.DivisionByFive
{
    using System;

    /// <summary>
    /// Write a program that reads two positive integer 
    /// numbers and prints how many numbers p exist between 
    /// them such that the reminder of the division 
    /// by 5 is 0 (inclusive). Example: p(17,25) = 2.
    /// </summary>
    public class DivisionByFive
    {
        internal static void Main()
        {
            Console.WriteLine("Please enter the start number:");
            int bottomNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter the end number:");
            int topNumber = int.Parse(Console.ReadLine());
            int counter = 0;

            for (int i = bottomNumber; i <= topNumber; i++)
            {
                if (i % 5 == 0)
                {
                    counter++;
                }
            }

            Console.WriteLine("There are {0} numbers that are divideble by 5", counter);
        }
    }
}
