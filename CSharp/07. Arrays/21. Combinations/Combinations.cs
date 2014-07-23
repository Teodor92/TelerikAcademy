namespace _21.Combinations
{
    using System;

    public class Combinations
    {
        internal static void Main()
        {
            Console.WriteLine("Enter the number of elements:");
            long numberOfElements = long.Parse(Console.ReadLine());

            Console.WriteLine("Enter K:");
            long combinationElements = long.Parse(Console.ReadLine());

            var elements = new long[numberOfElements];
            string subset = string.Empty;
            int lenCounter = 0;
            for (int i = 0; i < elements.Length; i++)
            {
                Console.WriteLine("Enter element № {0}", i + 1);
                elements[i] = long.Parse(Console.ReadLine());
            }
        
            int maxSubsets = (int)Math.Pow(2, numberOfElements);
            for (int i = 1; i < maxSubsets; i++)
            {
                subset = string.Empty;
                for (int j = 0; j <= numberOfElements; j++)
                {
                    int mask = 1 << j;
                    int valueNAndMask = i & mask;
                    int bit = valueNAndMask >> j;
                    if (bit == 1)
                    {
                        subset = subset + " " + elements[j];
                        lenCounter++;
                    }
                }

                if (lenCounter == combinationElements)
                {
                    Console.WriteLine(subset);   
                }

                lenCounter = 0;
            }
        }
    }
}