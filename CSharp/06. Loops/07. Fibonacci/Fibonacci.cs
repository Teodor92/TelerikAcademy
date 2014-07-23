namespace _07.Fibonacci
{
    using System;

    /// <summary>
    /// Write a program that reads a number N and calculates 
    /// the sum of the first N members of the sequence of 
    /// Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
    /// Each member of the Fibonacci sequence (except the first two) 
    /// is a sum of the previous two members.
    /// </summary>
    public class Fibonacci
    {
        internal static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            decimal firstNumber = 0;
            decimal secondNumber = 1;
            Console.WriteLine(firstNumber);
            Console.WriteLine(secondNumber);
            for (int i = 0; i < n; i++)
            {
                decimal sum = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = sum;
                Console.WriteLine(secondNumber);
            }
        }
    }
}
