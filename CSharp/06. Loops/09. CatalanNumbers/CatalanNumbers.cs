namespace _09.CatalanNumbers
{
    using System;

    public class CatalanNumbers
    {
        internal static void Main()
        {
            decimal n = decimal.Parse(Console.ReadLine());
            decimal catalanSum = FactorialCalc(2 * n) / FactorialCalc(n + 1) * FactorialCalc(n);
            Console.WriteLine(catalanSum);
        }

        private static decimal FactorialCalc(decimal number)
        {
            decimal sum = 1;
            for (int i = 1; i <= number; i++)
            {
                sum = sum * i;
            }

            return sum;
        }
    }
}
