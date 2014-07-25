namespace _07._1.NnumeralSystemCharTest
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class NnumeralSystem
    {
        internal static void Main()
        {
            string number = Console.ReadLine();
            const int BaseS = 10;
            const int BaseB = 36;

            // reversing the string
            var reverser = new StringBuilder();
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
                    decNum = decNum + (int.Parse(number[i].ToString()) * (int)Math.Pow(BaseS, i));
                }
                else
                {
                    decNum = decNum + ((number[i] - 55) * (int)Math.Pow(BaseS, i));
                }
            }

            if (BaseB == 10)
            {
                Console.WriteLine(decNum);
            }
            else
            {
                var endNum = new List<string>();
                while (decNum > 0)
                {
                    int modulo = decNum % BaseB;
                    if (modulo < 10)
                    {
                        endNum.Add(modulo.ToString());
                    }
                    else
                    {
                        endNum.Add(((char)((modulo - 10) + 65)).ToString());
                    }

                    decNum = decNum / BaseB;
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
}
