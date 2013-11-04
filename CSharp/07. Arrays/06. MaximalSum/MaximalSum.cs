/* Write a program that reads two 
 * integer numbers N and K and an array 
 * of N elements from the console. Find 
 * in the array those K elements that have maximal sum.
 */

using System;

public class MaximalSum
{
    public static void Main()
    {
        // input
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());
        int[] myArray = new int[n];
        for (int i = 0; i < myArray.Length; i++)
        {
            myArray[i] = int.Parse(Console.ReadLine());
        }

        // testing
        //int[] myArray = { 12, 12, 12, 11, 11, 11, 7, 8, 9 };
        // help values
        string bestSeq = string.Empty;
        int sum = 0;
        int bestSum = int.MinValue;
        int arrayLen = myArray.Length;
        for (int i = 0; i < arrayLen; i++)
        {
            string currentSeq = string.Empty;

            // out of the array bounds
            if (i + k > arrayLen)
            {
                break;
            }

            // set check
            for (int j = i; j < i + k; j++)
            {
                sum = sum + myArray[j];
                currentSeq = currentSeq + ' ' + myArray[j];
            }

            // best sum check
            if (sum > bestSum)
            {
                bestSeq = currentSeq;
                bestSum = sum;
            }

            sum = 0;
        }

        Console.WriteLine(bestSeq);
        Console.WriteLine(bestSum);
    }
}
