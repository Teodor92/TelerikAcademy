namespace _02.Tribonacci
{
    using System;
    using System.Numerics;

    public class Tribonacci
    {
        internal static void Main()
        {
            var firstElement = BigInteger.Parse(Console.ReadLine());
            var secondElement = BigInteger.Parse(Console.ReadLine());
            var thirdElement = BigInteger.Parse(Console.ReadLine());
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
}
