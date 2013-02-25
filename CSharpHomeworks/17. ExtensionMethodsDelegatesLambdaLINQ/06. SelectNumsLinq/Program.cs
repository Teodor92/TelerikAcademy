using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = new int[100];
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = i;
        }

        var selectedNums =
        from num in numbers
        where num % 21 == 0
        select num;

        foreach (var num in selectedNums)
        {
            Console.WriteLine(num);
        }
    }
}