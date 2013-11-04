using System;
using System.Collections.Generic;
using System.Text;

public class NnumeralSystem
{
    public static void Main()
    {
        string number = Console.ReadLine();
        int baseS = 10;
        int baseB = 36;

        // reversing the string
        StringBuilder reverser = new StringBuilder();
        for (int i = number.Length - 1; i >= 0; i--)
        {
            reverser.Append(number[i]);
        }

        number = reverser.ToString();

        // to middle decimal
        int decNum = 0;
        for (int i = 0; i < number.Length; i++)
        {
            Console.WriteLine(number[i]);
            if (number[i] < 64)
            {
                decNum = decNum + (int.Parse(number[i].ToString()) * (int)Math.Pow(baseS, i));
            }
            else
            {
                decNum = decNum + (((number[i] - 55)) * (int)Math.Pow(baseS, i));
            }
        }

        if (baseB == 10)
        {
            Console.WriteLine(decNum);
        }
        else
        {
            List<string> endNum = new List<string>();
            while (decNum > 0)
            {
                int modulo = decNum % baseB;
                if (modulo < 10)
	            {
                    endNum.Add(modulo.ToString());
	            }
                else
	            {
                    endNum.Add(((char)((modulo - 10)+65)).ToString());
	            }

                decNum = decNum / baseB;
            }

            endNum.Reverse();
            foreach (var item in endNum)
            {
                Console.Write(item);
            }

            Console.WriteLine();
        }
    }
}
