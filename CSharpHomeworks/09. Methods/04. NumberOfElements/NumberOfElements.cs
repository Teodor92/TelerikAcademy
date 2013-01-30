/* Write a method that counts how many times given 
 * number appears in given array. Write a test 
 * program to check if the method is working correctly.
 */

using System;

public class NumberOfElements
{
    public static int NumberCounter(int[] array, int numForSearch)
    {
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == numForSearch)
            {
                counter++;
            }
        }

        return counter;
    }

    public static void Main()
    {
        int[] myArray = { 1, 2, 3, 4, 4, 4, 4, 4, 4, 5 };
        Console.WriteLine(NumberCounter(myArray, 4));
    }
}

// NOTE: For the unit test see the next project. 