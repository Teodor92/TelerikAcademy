using System;

public class UniCodeChars
{
    public static void Main()
    {
        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            string hex = Convert.ToString((int)input[i], 16);
            Console.Write("\\u");
            Console.Write(hex.PadLeft(4, '0'));
        }

        Console.WriteLine();
    }
}
