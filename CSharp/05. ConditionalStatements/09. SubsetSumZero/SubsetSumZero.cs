namespace _09.SubsetSumZero
{
    using System;

    /// <summary>
    /// We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. Example: 3, -2, 1, 1, 8 -> 1+1-2=0.
    /// </summary>
    public class SubSetSumBin
    {
        internal static void Main()
        {
            Console.WriteLine("Enter the wanted sum of the subsets:");
            long wantedSum = long.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of elements:");
            long numberOfElements = long.Parse(Console.ReadLine());
            var elements = new long[numberOfElements];
            int counter = 0;
            var subset = string.Empty;

            for (int i = 0; i < elements.Length; i++)
            {
                Console.WriteLine("Enter element № {0}", i + 1);
                elements[i] = long.Parse(Console.ReadLine());
            }

            var maxSubsets = (int)Math.Pow(2, numberOfElements);
            for (int i = 1; i < maxSubsets; i++)
            {
                subset = string.Empty;
                long checkingSum = 0;
                for (int j = 0; j <= numberOfElements; j++)
                {
                    int mask = 1 << j;
                    int valueNAndMask = i & mask;
                    int bit = valueNAndMask >> j;
                    if (bit == 1)
                    {
                        checkingSum = checkingSum + elements[j];
                        subset = subset + " " + elements[j];
                    }
                }

                if (checkingSum == wantedSum)
                {
                    Console.WriteLine("Number of subest that have the sum of {0}", wantedSum);
                    counter++;
                    Console.WriteLine("This subset has a sum of {0} : {1} ", wantedSum, subset);
                }
            }

            Console.WriteLine(counter);
        }
    }
}
