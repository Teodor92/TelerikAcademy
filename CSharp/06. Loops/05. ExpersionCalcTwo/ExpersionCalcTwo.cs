namespace _05.ExpersionCalcTwo
{
    using System;
    using System.Numerics;

    /// <summary>
    /// Write a program that calculates 
    /// N!*K! / (K-N)! for given N and K (1<N<K).
    /// </summary>
    public class ExpersionCalcTwo
    {
        internal static void Main()
        {
            Console.WriteLine("N!*K! / (K-N)!");
            Console.WriteLine("Enter N:");
            uint n = uint.Parse(Console.ReadLine());
            Console.WriteLine("Enter K:");
            uint k = uint.Parse(Console.ReadLine());
            Console.WriteLine("Result:");
            Console.WriteLine(FactorialCalc(n) * FactorialCalc(k) / FactorialCalc(k - n));
        }

        private static BigInteger FactorialCalc(uint number)
        {
            BigInteger sum = 1;
            for (int i = 1; i <= number; i++)
            {
                sum = sum * i;
            }

            return sum;
        }
    }
}