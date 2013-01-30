using System;
using System.Collections.Generic;
using System.Numerics;

class Tribonacci
{
    static void Main()
    {
        BigInteger firstElement = BigInteger.Parse(Console.ReadLine());
        BigInteger secondElement = BigInteger.Parse(Console.ReadLine());
        BigInteger thirdElement = BigInteger.Parse(Console.ReadLine());
        BigInteger fourthElement = BigInteger.Parse(Console.ReadLine());
        int row = int.Parse(Console.ReadLine());
        int col = int.Parse(Console.ReadLine());
        List<BigInteger> allNums = new List<BigInteger>();
        BigInteger sum = 0;
        allNums.Add(firstElement);
        allNums.Add(secondElement);
        allNums.Add(thirdElement);
        allNums.Add(fourthElement);
        for (int i = 0; i < (col*row) - 4; i++)
        {
            sum = firstElement + secondElement + thirdElement + fourthElement;
            allNums.Add(sum);
            firstElement = secondElement;
            secondElement = thirdElement;
            thirdElement = fourthElement;
            fourthElement = sum;
        }
        for (int i = 0; i < allNums.Count; i++)
        {
            if (i % col == 0 && i != 0)
            {
                Console.WriteLine();
            }
            Console.Write("{0} ",allNums[i]);
        }
    }
}