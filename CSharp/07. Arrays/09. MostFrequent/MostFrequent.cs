namespace _09.MostFrequent
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that finds the most frequent number in an array.
    /// Example:
    /// {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3}  4 (5 times)
    /// </summary>
    public class MostFrequent
    {
        public static void Main()
        {
            int[] myArray = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 };
            var mostFrequnet = new Dictionary<int, int>();
            int bestElement = 0;
            int bestFrequnecy = int.MinValue;
            for (int i = 0; i < myArray.Length; i++)
            {
                int tempValue;
                if (mostFrequnet.TryGetValue(myArray[i], out tempValue))
                {
                    mostFrequnet[myArray[i]] = tempValue + 1;
                }
                else
                {
                    mostFrequnet.Add(myArray[i], 1);
                }
            }

            foreach (var item in mostFrequnet)
            {
                if (item.Value > bestFrequnecy)
                {
                    bestElement = item.Key;
                    bestFrequnecy = item.Value;
                }
            }

            Console.WriteLine("The number {0} shows {1} times", bestElement, bestFrequnecy);
        }
    }
}
