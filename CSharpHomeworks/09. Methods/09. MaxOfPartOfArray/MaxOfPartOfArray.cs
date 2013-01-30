/* Write a method that return the maximal 
 * element in a portion of array of integers 
 * starting at given index. Using it write 
 * another method that sorts an array in 
 * ascending / descending order.
 */

using System;

public class MaxOfPartOfArray
{
    public static int MaxOfPart(int[] wholeArrey, int startIndex)
    {
        int biggest = startIndex;
        for (int i = startIndex + 1; i < wholeArrey.Length; i++)
        {
            if (wholeArrey[i] > wholeArrey[biggest])
            {
                biggest = i;
            }
        }

        return biggest;
    }

    public static void ArraySwap(int[] array, int firstNumberIndex, int secondNumberIndex)
    {
        int temp = array[firstNumberIndex];
        array[firstNumberIndex] = array[secondNumberIndex];
        array[secondNumberIndex] = temp;
    }

    public static int[] SelectionSort(int[] array, bool assending)
    {
        for (int i = 0; i < array.Length; i++)
        {
            int max = MaxOfPart(array, i);
            ArraySwap(array, i, max);
        }

        if (assending)
        {
            Array.Reverse(array);
        }

        return array;
    }

    public static void Main()
    {
        int[] myArray = { 1, 147, 3, 4, 5, 6, 7, 20, 9, 10 };
        Console.WriteLine("Max element in a portion of array");
        Console.WriteLine(myArray[MaxOfPart(myArray, 4)]);

        Console.WriteLine("Selection sort");
        myArray = SelectionSort(myArray, true);
        foreach (var item in myArray)
        {
            Console.Write("{0} ", item);
        }
    }
}
