using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>(10);
        for (int i = 0; i < numbers.Count; i++)
        {
            numbers[i] = i;
        }

        Console.WriteLine(numbers);
    }
}
