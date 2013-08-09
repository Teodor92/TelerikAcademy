namespace WordExtract
{
    /*
     * Write a program that extracts from a given sequence of strings 
     * all elements that present in it odd number of times. 
     * Example:{C#, SQL, PHP, PHP, SQL, SQL }  {C#, SQL}
     */

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static IDictionary<string, int> CountElements(IList<string> sequence)
        {
            if (sequence == null || sequence.Count == 0)
            {
                throw new ArgumentNullException("Sequance must not be empty!");
            }

            IDictionary<string, int> elementCounter = new Dictionary<string, int>();
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

        public static void Main()
        {
            string[] sequence = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };

            IDictionary<string, int> countedElements = CountElements(sequence);

            foreach (var element in countedElements)
            {
                if (element.Value % 2 != 0)
                {
                    // TODO: Better key-value print
                    Console.WriteLine(element.ToString());
                }
            }
        }
    }
}
