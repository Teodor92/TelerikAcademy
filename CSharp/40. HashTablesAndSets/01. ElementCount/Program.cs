namespace ElementCount
{
    /*
     * Write a program that finds in given array of integers 
     * (all belonging to the range [0..1000]) how many times each of them occurs.
     * 
     * Example: array = {3, 4, 4, 2, 3, 3, 4, 3, 2}
     * 2  2 times
     * 3  4 times
     * 4  3 times
     */

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static IDictionary<int, int> CountElements(IList<int> sequence)
        {
            if (sequence == null || sequence.Count == 0)
            {
                throw new ArgumentNullException("Sequance must not be empty!");
            }

            IDictionary<int, int> elementCounter = new SortedDictionary<int, int>();
            int sequenceLength = sequence.Count;

            for (int i = 0; i < sequenceLength; i++)
            {
                if (elementCounter.ContainsKey(sequence[i]))
                {
                    elementCounter[sequence[i]]++;
                }
                else
                {
                    elementCounter.Add(sequence[i], 1);
                }
            }

            return elementCounter;
        }

        public static void PrintDictonary(IDictionary<int, int> myDictonary)
        {
            StringBuilder output = new StringBuilder();

            foreach (var element in myDictonary)
            {
                output.AppendFormat("Element: {0}, Times: {1} {2}", element.Key, element.Value, Environment.NewLine);
            }

            Console.WriteLine(output.ToString());
        }

        public static void Main()
        {
            int[] sequence = new int[] { 3, 4, 4, 2, 3, 3, 4, 3, 2 };

            PrintDictonary(CountElements(sequence));
        }
    }
}
