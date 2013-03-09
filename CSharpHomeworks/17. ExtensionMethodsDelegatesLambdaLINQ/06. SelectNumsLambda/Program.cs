using System;
using System.Linq;

public class Program
{
    public static void Main()
    {
        int[] numbers = new int[100];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i;
        }

        var selectedNums = numbers.Where(x => x % 21 == 0);

        foreach (var num in selectedNums)
        {
            Console.WriteLine(num);
        }
    }
}
