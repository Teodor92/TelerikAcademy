using System;
using System.Collections.Generic;
using System.Text;

public class SignedShort
{
    public static List<short> DecToBin(short num)
    {
        List<short> bin = new List<short>();
        while (num != 0)
        {
            bin.Add((short)(num % 2));
            num = (short)(num / 2);
        }

        bin.Reverse();
        return bin;
    }

    public static string EndingNums(string strNum, int endingNum)
    {
        StringBuilder newNum = new StringBuilder();
        while (newNum.Length != 16 - strNum.Length)
        {
            newNum.Append(endingNum);
        }

        newNum.Append(strNum);
        return newNum.ToString();
    }

    public static void Main()
    {
        short number = short.Parse(Console.ReadLine());
        StringBuilder endNum = new StringBuilder();
        if (number >= 0)
        {
            List<short> numInBin = DecToBin(number);
            foreach (var item in numInBin)
            {
                endNum.Append(item);
            }

            Console.WriteLine(EndingNums(endNum.ToString(), 0));
        }
        else
        {
            number = (short)(Math.Abs(number) - 1);
            List<short> numInBin = DecToBin(number);
            for (int i = 0; i < numInBin.Count; i++)
            {
                if (numInBin[i] == 0)
                {
                    endNum.Append(1);
                }
                else
                {
                    endNum.Append(0);
                }
            }

            Console.WriteLine(EndingNums(endNum.ToString(), 1));
        }
    }
}
