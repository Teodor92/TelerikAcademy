namespace _11.BinarySearch
{
    using System;

    /// <summary>
    /// Write a program that finds the index of 
    /// given element in a sorted array of integers 
    /// by using the binary search algorithm (find it in Wikipedia).
    /// </summary>
    public class BinarySearch
    {
        internal static void Main()
        {
            int[] myArray = { 4, 3, 1, 4, 2, 5, 8, 21, 13, 180 };
            int key = 4;
            Console.WriteLine(BinSearch(myArray, key));
        }

        private static int BinSearch(int[] array, int key)
        {
            Array.Sort(array);
            int indexMax = array.Length - 1;
            int indexMin = 0;
            while (indexMax >= indexMin)
            {
                int indexMidpoint = (indexMin + indexMax) / 2;
                if (array[indexMidpoint] < key)
                {
                    indexMin = indexMidpoint + 1;
                }
                else if (array[indexMidpoint] > key)
                {
                    indexMax = indexMidpoint - 1;
                }
                else
                {
                    return indexMidpoint;
                }
            }

            return -1;
        }
    }
}
