/* Write a program that reads 
 * two arrays from the console 
 * and compares them element by element.
 */

using System;

public class TwoArrayCompare
{
    public static int[] ArrayCreate(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine("Enter element - {0} ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        return array;
    }

    public static bool AreEqual(int[] arrayOne, int[] arrayTwo)
    {
        bool areEqual = true;
        for (int i = 0; i < arrayOne.Length; i++)
        {
            if (arrayOne[i] != arrayTwo[i])
            {
                areEqual = false;
                break;
            }
        }

        return areEqual;
    }

    public static void Main()
    {
        Console.WriteLine("Enter the arrays length:");
        int n = int.Parse(Console.ReadLine());
        int[] firstArray = new int[n];
        int[] secondArray = new int[n];

        firstArray = ArrayCreate(firstArray);
        secondArray = ArrayCreate(secondArray);

        Array.Sort(firstArray);
        Array.Sort(secondArray);
        
        Console.WriteLine("The two arrays are equal: {0}", AreEqual(firstArray, secondArray));
    }
}
