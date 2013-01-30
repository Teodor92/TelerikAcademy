/* * Modify your last program and try to make 
 * it work for any number type, not just integer 
 * (e.g. decimal, float, byte, etc.). 
 * Use generic method (read in Internet about generic methods in C#).
 */

using System;

public class GenericMethods
{
    public static T MinOfSet<T>(params T[] numArray)
    {
        dynamic min = numArray[0];
        for (int i = 0; i < numArray.Length; i++)
        {
            if (numArray[i] < min)
            {
                min = numArray[i];
            }
        }

        return min;
    }

    public static T MaxOfSet<T>(params T[] numArray)
    {
        dynamic max = numArray[0];
        for (int i = 0; i < numArray.Length; i++)
        {
            if (numArray[i] > max)
            {
                max = numArray[i];
            }
        }

        return max;
    }

    public static T AverageOfSet<T>(params T[] numArray)
    {
        dynamic sum = 0;
        for (int i = 0; i < numArray.Length; i++)
        {
            sum = sum + numArray[i];
        }

        return sum / numArray.Length;
    }

    public static T SumOfSet<T>(params T[] numArray)
    {
        dynamic sum = 0;
        for (int i = 0; i < numArray.Length; i++)
        {
            sum = sum + numArray[i];
        }

        return sum;
    }

    public static T ProductOfSet<T>(params T[] numArray)
    {
        dynamic product = 1;
        for (int i = 0; i < numArray.Length; i++)
        {
            product = product * numArray[i];
        }

        return product;
    }

    public static void Main()
    {
        Console.WriteLine("The minimum of set of ints is: {0}", MinOfSet(1, 2, 3, 4, 5, 6));
        Console.WriteLine("The maximum of set of ints is: {0}", MaxOfSet(1, 2, 3, 4, 5, 6));
        Console.WriteLine("The average of set of ints is: {0}", AverageOfSet(1, 2, 3, 4, 5, 6));
        Console.WriteLine("The sum of set of ints is: {0}", SumOfSet(1, 2, 3, 4, 5, 6));
        Console.WriteLine("The product of set of ints is: {0}", ProductOfSet(1, 2, 3, 4, 5, 6));
    }
}
