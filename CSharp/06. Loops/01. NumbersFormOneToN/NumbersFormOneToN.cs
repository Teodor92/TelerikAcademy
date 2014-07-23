namespace _01.NumbersFormOneToN
{
    using System;

    /// <summary>
    /// Write a program that prints all the numbers from 1 to N.
    /// </summary>
    public class NumbersFormOneToN
    {
        internal static void Main()
        {
            Console.WriteLine("Enter the end number:");
            uint n = uint.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
