namespace _06.ExpersionCalcThree
{
    using System;

    /// <summary>
    /// Write a program that, for a given two 
    /// integer numbers N and X, 
    /// calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN
    /// </summary>
    public class ExpersionCalcThree
    {
        internal static void Main()
        {
            double x = int.Parse(Console.ReadLine());
            double n = int.Parse(Console.ReadLine());
            double sum = 1;
            for (uint i = 1; i <= n; i++)
            {
                sum = sum + (FactorialCalc(i) / Math.Pow(x, i));
            }

            Console.WriteLine(sum);
        }

        private static ulong FactorialCalc(uint number)
        {
            ulong sum = 1;
            for (uint i = 1; i <= number; i++)
            {
                sum = sum * i;
            }

            return sum;
        }
    }
}
