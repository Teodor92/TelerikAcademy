namespace SubsequenceNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class ListUtils
    {
        public static List<int> GenerateSameElementSequence(int element, int elementCount)
        {
            if (elementCount <= 0)
            {
                throw new ArgumentOutOfRangeException("The elements count must be greater than 0");
            }

            List<int> sequence = new List<int>();

            for (int i = 0; i < elementCount; i++)
            {
                sequence.Add(element);
            }

            return sequence;
        }

        public static List<int> FindMaxSameElemetSubsequence(IList<int> sequence)
        {
            if (sequence == null || sequence.Count == 0)
            {
                throw new ArgumentNullException("Sequance must not be empty!");
            }

            List<int> subsequence = new List<int>();

            int sequenceLength = sequence.Count;
            int currentElement = sequence[0];
            int elementCount = 1;
            int bestElement = 0;
            int bestCount = int.MinValue;

            for (int i = 0; i < sequenceLength - 1; i++)
            {
                if (sequence[i] == sequence[i + 1])
                {
                    currentElement = sequence[i];
                    elementCount++;
                }
                else
                {
                    if (elementCount > bestCount)
                    {
                        bestCount = elementCount;
                        bestElement = currentElement;
                    }

                    elementCount = 1;
                }
            }

            // special case - TODO: Make a fix
            if (elementCount > bestCount)
            {
                bestCount = elementCount;
                bestElement = currentElement;
            }

            subsequence = GenerateSameElementSequence(bestElement, bestCount);

            return subsequence;
        }

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
    }
}
