using System;

class SubSetSumBin
{
    static void Main()
    {
        long wantedSum = long.Parse(Console.ReadLine());
        long numberOfElements = long.Parse(Console.ReadLine());
        long[] elements = new long[numberOfElements];
        int counter = 0;
        for (int i = 0; i < elements.Length; i++)
        {
            elements[i] = long.Parse(Console.ReadLine());
        }
        int maxSubsets = (int)Math.Pow(2, numberOfElements) - 1;
        for (int i = 1; i <= maxSubsets; i++)
        {
            long checkingSum = 0;
            for (int j = 0; j <= numberOfElements; j++)
            {
                int mask = 1 << j;
                int nAndMask = i & mask;
                int bit = nAndMask >> j;
                if (bit == 1)
                {
                    checkingSum = checkingSum + elements[j];
                }
            }
            if (checkingSum == wantedSum)
            {
                counter++;
            }
        }
        Console.WriteLine(counter);
    }
}