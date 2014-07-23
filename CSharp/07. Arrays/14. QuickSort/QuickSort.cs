namespace _14.QuickSort
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Write a program that sorts an array 
    /// of strings using the quick sort 
    /// algorithm (find it in Wikipedia).
    /// </summary>
    public class QuickSort
    {
        internal static void Main()
        {
            var array = new List<string> { "a", "j", "d", "s", "c", "w", "l", "b", "f" };
            var sortedArray = QuickSortEmpement(array);
            foreach (var item in sortedArray)
            {
                Console.Write("{0} ", item);
            }

            Console.WriteLine();
        }

        private static IEnumerable<string> QuickSortEmpement(List<string> unsortedList)
        {
            if (unsortedList.Count <= 1)
            {
                return unsortedList;
            }

            int pivot = unsortedList.Count / 2;
            string pivotValue = unsortedList[pivot];
            unsortedList.RemoveAt(pivot);
            var lesser = new List<string>();
            var greater = new List<string>();
            foreach (string element in unsortedList)
            {
                if (string.CompareOrdinal(element, pivotValue) < 0)
                {
                    lesser.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }

            var result = new List<string>();
            result.AddRange(QuickSortEmpement(lesser));
            result.Add(pivotValue);
            result.AddRange(QuickSortEmpement(greater));
            return result;
        }
    }
}
