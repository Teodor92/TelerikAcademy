using System;

class CatalanNumbers
{
    static decimal FactorialCalc(decimal number)
    {
        decimal sum = 1;
        for (int i = 1; i <= number; i++)
        {
            sum = sum * i;
        }
        return sum;
    }
    static void Main()
    {
        decimal n = decimal.Parse(Console.ReadLine());
        decimal CatalanSum = 0;
        CatalanSum = FactorialCalc(2 * n) / FactorialCalc(n + 1) * FactorialCalc(n);
        Console.WriteLine(CatalanSum);
    }
}
