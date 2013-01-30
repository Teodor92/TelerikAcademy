using System;

class MinDigit
{
    static void Main()
    {
        string input = Console.ReadLine();
        int minNumber = int.MaxValue;
        int[] inputInNumbers = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            inputInNumbers[i] = Convert.ToInt32(input[i]) - 48;
        }
        for (int i = 0; i < input.Length; i++)
        {
            if (inputInNumbers[i] < minNumber && inputInNumbers[i] != 0)
            {
                minNumber = inputInNumbers[i];
            }
        }
        Console.WriteLine(minNumber);
    }
}
