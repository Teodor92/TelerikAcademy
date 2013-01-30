

using System;

public class SimpleSetOfNumbersTasks
{
    public static int MinOfSet(params int[] numArray)
    {
        int min = numArray[0];
        for (int i = 0; i < numArray.Length; i++)
        {
            if (numArray[i] < min)
            {
                min = numArray[i];
            }
        }

        return min;
    }

    public static int MaxOfSet(params int[] numArray)
    {
        int max = numArray[0];
        for (int i = 0; i < numArray.Length; i++)
        {
            if (numArray[i] > max)
            {
                max = numArray[i];
            }
        }

        return max;
    }

    public static int AverageOfSet(params int[] numArray)
    {
        int sum = 0;
        for (int i = 0; i < numArray.Length; i++)
        {
            sum = sum + numArray[i];
        }

        return sum / numArray.Length;
    }

    public static int SumOfSet(params int[] numArray)
    {
        int sum = 0;
        for (int i = 0; i < numArray.Length; i++)
        {
            sum = sum + numArray[i];
        }

        return sum;
    }

    public static int ProductOfSet(params int[] numArray)
    {
        int product = 0;
        for (int i = 0; i < numArray.Length; i++)
        {
            product = product * numArray[i];
        }

        return product;
    }

    public static void Main()
    {
        Console.WriteLine("The minimum of set of ints is: {0}", MinOfSet(1, 2, 3, 4, -5, 6, 7));
        Console.WriteLine("The maximum of set of ints is: {0}", MaxOfSet(1, 2, 3, 4, -5, 6, 7));
        Console.WriteLine("The average of set of ints is: {0}", AverageOfSet(1, 2, 3, 4, -5, 6, 7));
        Console.WriteLine("The sum of set of ints is: {0}", SumOfSet(1, 2, 3, 4, -5, 6, 7));
        Console.WriteLine("The product of set of ints is: {0}", ProductOfSet(1, 2, 3, 4, -5, 6, 7));
    }
}
