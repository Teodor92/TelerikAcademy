/* Write a program, that reads from the console an array of N 
 * integers and an integer K, sorts the array and using the 
 * method Array.BinSearch() finds the largest number in the array which is ≤ K. 
 */

using System;

public class KBinSearch
{
    public static void Main()
    {
        int[] myArray = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int k = int.Parse(Console.ReadLine());
        int neededIndex = 0;
        neededIndex = Array.BinarySearch(myArray, k);

        if (k < myArray[0])
        {
            Console.WriteLine("There is no such number");
        }
        else
        {
            if (neededIndex >= 0)
            {
                Console.WriteLine(myArray[neededIndex]);
            }
            else
            {
                Console.WriteLine(myArray[~neededIndex - 1]);
            }
        }
    }
}
