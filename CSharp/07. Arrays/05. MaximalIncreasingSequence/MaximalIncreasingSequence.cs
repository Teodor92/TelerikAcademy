namespace _05.MaximalIncreasingSequence
{
    using System;

    /// <summary>
    /// Write a program that finds the maximal 
    /// increasing sequence in an array. Example: 
    /// {3, 2, 3, 4, 2, 2, 4}  {2, 3, 4}.
    /// </summary>
    public class MaximalIncreasingSequence
    {
        public static void Main()
        {
            int[] myArray = { 2, 2, 2, 1, 2, 3, 5, 6, 7, 8, 9, 10, 2, 1, 2, 3, 4, 4 };
            int len = 1;
            int bestLen = 0;
            int endIndex = 0;

            // main logic
            for (int i = 0; i < myArray.Length - 1; i++)
            {
                if (myArray[i] < myArray[i + 1])
                {
                    len++;
                }
                else
                {
                    if (len > bestLen)
                    {
                        bestLen = len;
                        endIndex = i;
                    }

                    len = 1;
                }
            }

            // checking a special last case
            if (len > bestLen)
            {
                bestLen = len;
                endIndex = myArray.Length - 1;
            }

            // output
            len = 1;
            Console.WriteLine("The longest sequence of increasing elemints is:");
            Console.Write("{");
            for (int i = endIndex - bestLen + 1; i < endIndex + 1; i++)
            {
                Console.Write("{0},", myArray[i]);
            }

            Console.WriteLine("}");
        }
    }
}
