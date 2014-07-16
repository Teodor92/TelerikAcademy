namespace _02.Prices
{
    using System;
    using System.Numerics;

    public class Prices
    {
        internal static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var firstNumber = BigInteger.Parse(input[0]);
            var secondNumber = BigInteger.Parse(input[1]);
            Console.WriteLine(firstNumber - secondNumber);
        }
    }
}
