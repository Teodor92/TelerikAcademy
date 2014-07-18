namespace _01.SimpleSum
{
    using System;

    /// <summary>
    /// Write a program that reads 3 integer 
    /// numbers from the console and prints their sum.
    /// </summary>
    public class SimpleSum
    {
        internal static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 0; i < 3; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}