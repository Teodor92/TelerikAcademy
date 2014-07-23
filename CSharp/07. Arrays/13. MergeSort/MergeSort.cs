namespace _13.MergeSort
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// * Write a program that sorts an array of 
    /// integers using the merge sort algorithm 
    /// (find it in Wikipedia).
    /// </summary>
    public class MergeSort
    {
        internal static void Main()
        {
            var array = new List<string> { "asdasd", "a", "asdwww", "wawdwa" };
            var sortedArray = MergeSortAlg(array);
            foreach (var item in sortedArray)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }

        private static List<string> MergeSortAlg(List<string> unsortedList)
        {
            if (unsortedList.Count <= 1)
            {
                return unsortedList;
            }

            var left = new List<string>();
            var right = new List<string>();
            int middle = unsortedList.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(unsortedList[i]);
            }

            for (int i = middle; i < unsortedList.Count; i++)
            {
                right.Add(unsortedList[i]);
            }

            left = MergeSortAlg(left);
            right = MergeSortAlg(right);
            return Merge(left, right);
        }

        private static List<string> Merge(List<string> left, List<string> right)
        {
            var result = new List<string>();
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (string.CompareOrdinal(left[0], right[0]) < 0)
                    {
                        result.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
                else if (right.Count > 0)
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
            }

            return result;
        }
    }
}
