using System;
using System.Collections.Generic;

public class HexToBinDirectly
{
    public static void Main()
    {
        string hex = Console.ReadLine();
        List<int> binNum = new List<int>();
        for (int i = hex.Length - 1; i >= 0; i--)
        {
            int hexPart = 0;
            List<int> binPart = new List<int>();
            switch (hex[i])
            {
                case 'A':
                    hexPart = 10;
                    break;
                case 'B':
                    hexPart = 11;
                    break;
                case 'C':
                    hexPart = 12;
                    break;
                case 'D':
                    hexPart = 13;
                    break;
                case 'E':
                    hexPart = 14;
                    break;
                case 'F':
                    hexPart = 15;
                    break;
                default:
                    hexPart = Convert.ToInt32(hex[i]);
                    break;
            }

            for (int j = 0; j < 4; j++)
            {
                binPart.Add(hexPart % 2);
                hexPart = hexPart / 2;
            }

            binNum.AddRange(binPart);
        }

        binNum.Reverse();
        foreach (var item in binNum)
        {
            Console.Write(item);
        }

        Console.WriteLine();
    }
}
