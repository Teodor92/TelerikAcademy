namespace _08.LineOfNNumbers
{
    using System;

    /// <summary>
    /// Write a program that reads an integer number n 
    /// from the console and prints all the numbers in 
    /// the interval [1..n], each on a single line.
    /// </summary>
    public class LineOfNNumbers
    {
        internal static void Main()
        {
            Console.WriteLine("Please enter the last number:");
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i <= number; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
