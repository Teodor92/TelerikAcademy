namespace _02.Least_Majority_Multiple
{
    using System;
    using System.Collections.Generic;

    public class LeastMajorityMultiple
    {
        internal static void Main()
        {
            var numbers = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                int input = int.Parse(Console.ReadLine());
                numbers.Add(input);
            }

            var best = long.MaxValue;

            for (int i = 0; i < numbers.Count; i++)
            {
                var bestSomething = numbers[i];
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
}
