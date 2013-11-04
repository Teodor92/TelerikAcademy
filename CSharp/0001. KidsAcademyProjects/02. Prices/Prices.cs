using System;
using System.Numerics;

class Prices
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        BigInteger firstNumber = BigInteger.Parse(input[0]);
        BigInteger secondNumber = BigInteger.Parse(input[1]);
        Console.WriteLine(firstNumber - secondNumber);
    }
}
