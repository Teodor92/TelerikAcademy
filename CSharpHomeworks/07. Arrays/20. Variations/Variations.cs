/* Write a program that reads two numbers N and K 
 * and generates all the variations of K elements 
 * from the set [1..N]. Example:
 * N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}
 */

using System;

public class Variations
{
    public static void VariationsGen(int[] array, int index, int allElements)
    {
        if (array.Length == index)
        {
            PrintVar(array);
        }
        else
        {
            for (int i = 1; i < allElements + 1; i++)
            {
                array[index] = i;
                VariationsGen(array, index + 1, allElements);
            }
        }
    }

    public static void PrintVar(int[] array)
    {
        Console.Write("{ ");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }

        Console.Write("}");
        Console.WriteLine();
    }

    public static void Main()
    {
        int allElements = 3;
        int variationElements = 2;
        int[] vars = new int[variationElements];
        VariationsGen(vars, 0, allElements);
    }
}
