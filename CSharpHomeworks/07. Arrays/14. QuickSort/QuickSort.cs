/* Write a program that sorts an array 
 * of strings using the quick sort 
 * algorithm (find it in Wikipedia).
 */

using System;
using System.Collections.Generic;

public class QuickSort
{
    public static List<string> QuickSortEmpement(List<string> unsortedList)
    {
        if (unsortedList.Count <= 1)
        {
            return unsortedList;
        }

        int pivot = unsortedList.Count / 2;
        string pivotValue = unsortedList[pivot];
        unsortedList.RemoveAt(pivot);
        List<string> lesser = new List<string>();
        List<string> greater = new List<string>();
        foreach (string element in unsortedList)
        {
            if (String.Compare(element, pivotValue) < 0)
            {
                lesser.Add(element);
            }
            else
            {
                greater.Add(element);
            }
        }

        List<string> result = new List<string>();
        result.AddRange(QuickSortEmpement(lesser));
        result.Add(pivotValue);
        result.AddRange(QuickSortEmpement(greater));
        return result;
    }

    public static void Main()
    {
        List<string> array = new List<string> { "a", "j", "d", "s", "c", "w", "l", "b", "f" };
        List<string> sortedArray = QuickSortEmpement(array);
        foreach (var item in sortedArray)
        {
            Console.Write("{0} ", item);
        }

        Console.WriteLine();
    }
}
