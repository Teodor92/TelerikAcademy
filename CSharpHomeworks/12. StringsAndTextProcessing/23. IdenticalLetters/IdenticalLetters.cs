using System;
using System.Text;

public class IdenticalLetters
{
    public static void Main()
    {
        string input = Console.ReadLine();
        StringBuilder nonIndenticalString = new StringBuilder();

        for (int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] != input[i + 1])
            {
                nonIndenticalString.Append(input[i]);
            }
        }

        // Last Case
        if (input[input.Length] != input[input.Length - 1])
        {
            nonIndenticalString.Append(input[input.Length]);
        }

        // More testing
        Console.WriteLine(nonIndenticalString.ToString());
    }
}
