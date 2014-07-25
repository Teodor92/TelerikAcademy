namespace _02.BinaryToDecimal
{
    using System;

    /// <summary>
    /// Write a program to convert binary 
    /// numbers to their decimal representation.
    /// </summary>
    public class BinaryToDecimal
    {
        public static void Main()
        {
            string input = Console.ReadLine();
            int decNum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                decNum = decNum << 1;
                if (input[i] == '1')
                {
                    decNum = decNum ^ 1;
                }
            }

            Console.WriteLine(decNum);
        }
    }
}
