namespace _09.Fibonacci
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Write a program to print the first 100 members 
    /// of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
    /// </summary>
    public class Fibonacci
    {
        internal static void Main()
        {
            BigInteger firstNumber = 0;
            BigInteger secondNumber = 1;
            Console.WriteLine(firstNumber);
            Console.WriteLine(secondNumber);

            for (int i = 1; i < 100; i++)
            {
                BigInteger sum = firstNumber + secondNumber;
                firstNumber = secondNumber;
                secondNumber = sum;
                Console.WriteLine(sum);
            }
        }
    }
}
