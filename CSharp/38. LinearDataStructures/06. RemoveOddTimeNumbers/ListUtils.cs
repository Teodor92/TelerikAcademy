namespace RemoveOddTimeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ListUtils
    {
        public static void PrintList(IList<int> myList)
        {
            if (myList == null || myList.Count == 0)
            {
                throw new ArgumentNullException("List must not be empty!");
            }

            int myListLen = myList.Count;

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < myListLen; i++)
            {
                output.AppendFormat("{0}, ", myList[i]);
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(output.ToString().Trim(' ', ','));

            Console.ResetColor();
        }

        public static List<int> RemoveOddTimeNumbers(List<int> sequence)
        {
            if (sequence == null || sequence.Count == 0)
            {
                throw new ArgumentNullException("List must not be empty!");
            }

            Dictionary<int, int> elementCounter = CountElements(sequence);

            foreach (var element in elementCounter)
            {
                if (element.Value % 2 != 0)
                {
                    sequence.RemoveAll(item => item == element.Key);
                }
            }

            return sequence;
        }

        private static Dictionary<int, int> CountElements(IList<int> sequence)
        {
            if (sequence == null || sequence.Count == 0)
            {
                throw new ArgumentNullException("Sequance must not be empty!");
            }

            Dictionary<int, int> elementCounter = new Dictionary<int, int>();
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
    }
}
