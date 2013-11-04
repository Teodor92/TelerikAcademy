namespace RemoveAllNegativeNums
{
    using System;
    using System.Collections.Generic;
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

        public static List<int> RemoveNegativeElements(List<int> sequence)
        {
            if (sequence == null || sequence.Count == 0)
            {
                throw new ArgumentNullException("Sequence must not be empty!");
            }

            List<int> negativeElements = new List<int>();
            int sequnceLength = sequence.Count;

            for (int i = 0; i < sequnceLength; i++)
            {
                if (sequence[i] < 0)
                {
                    negativeElements.Add(sequence[i]);
                }
            }

            for (int i = 0; i < negativeElements.Count; i++)
            {
                sequence.Remove(negativeElements[i]);
            }

            return sequence;
        }
    }
}
