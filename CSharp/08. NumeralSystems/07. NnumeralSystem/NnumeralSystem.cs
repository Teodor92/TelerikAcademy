using System;
using System.Collections.Generic;
using System.Text;

public class NnumeralSystem
{
    public static void Main()
    {
        string number = Console.ReadLine();
        int baseS = 2;
        int baseB = 16;

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
            decNum = decNum + (int.Parse(number[i].ToString()) * (int)Math.Pow(baseS, i));    
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
                switch (modulo)
                {
                    case 10: 
                        endNum.Add("A"); 
                        break;
                    case 11: 
                        endNum.Add("B"); 
                        break;
                    case 12: 
                        endNum.Add("C"); 
                        break;
                    case 13: 
                        endNum.Add("D"); 
                        break;
                    case 14: 
                        endNum.Add("E"); 
                        break;
                    case 15: 
                        endNum.Add("F"); 
                        break;
                    default: 
                        endNum.Add(modulo.ToString());
                        break;
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
