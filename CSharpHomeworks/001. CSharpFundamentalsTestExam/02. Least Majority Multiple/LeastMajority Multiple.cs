using System;
using System.Collections.Generic;

class LeastMajorityMultiple
{
    static void Main()
    {
        List<int> numbers = new List<int>();

        for (int i = 0; i < 5; i++)
        {
            int input = int.Parse(Console.ReadLine());
            numbers.Add(input);
        }
        long bestSomething = 0;
        long best = long.MaxValue;
        for (int i = 0; i < numbers.Count; i++)
        {
            bestSomething = numbers[i];
            for (int j = 0; j < numbers.Count; j++)
            {
                if (j == i)
                {
                    continue;
                }
                if (j >= 2)
                {
                    if (bestSomething < best)
                    {
                        best = bestSomething;
                    }    
                }
                bestSomething = bestSomething * numbers[j];
            }
        }
        Console.WriteLine(best);
    }
}
