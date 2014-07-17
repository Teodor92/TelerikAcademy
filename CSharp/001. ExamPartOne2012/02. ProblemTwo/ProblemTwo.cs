namespace _02.ProblemTwo
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Tribonacci
    {
        internal static void Main()
        {
            var firstElement = BigInteger.Parse(Console.ReadLine());
            var secondElement = BigInteger.Parse(Console.ReadLine());
            var thirdElement = BigInteger.Parse(Console.ReadLine());
            var fourthElement = BigInteger.Parse(Console.ReadLine());
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            var allNums = new List<BigInteger>();
            allNums.Add(firstElement);
            allNums.Add(secondElement);
            allNums.Add(thirdElement);
            allNums.Add(fourthElement);

            for (int i = 0; i < (col * row) - 4; i++)
            {
                BigInteger sum = firstElement + secondElement + thirdElement + fourthElement;
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

                Console.Write("{0} ", allNums[i]);
            }
        }
    }
}