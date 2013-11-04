using System;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger firstElement = long.Parse(Console.ReadLine());
        BigInteger secondElement = long.Parse(Console.ReadLine());
        BigInteger thirdElement = long.Parse(Console.ReadLine());
        short n = short.Parse(Console.ReadLine());
        BigInteger sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum = firstElement + secondElement + thirdElement;
            firstElement = secondElement;
            secondElement = thirdElement;
            thirdElement = sum;
        }
        Console.WriteLine(thirdElement);
    }
}
