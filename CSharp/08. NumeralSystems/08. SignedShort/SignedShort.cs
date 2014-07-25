namespace _08.SignedShort
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SignedShort
    {
        internal static void Main()
        {
            short number = short.Parse(Console.ReadLine());
            var endNum = new StringBuilder();
            if (number >= 0)
            {
                var numInBin = DecToBin(number);
                foreach (var item in numInBin)
                {
                    endNum.Append(item);
                }

                Console.WriteLine(EndingNums(endNum.ToString(), 0));
            }
            else
            {
                number = (short)(Math.Abs(number) - 1);
                var numInBin = DecToBin(number);
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

        private static List<short> DecToBin(short num)
        {
            var bin = new List<short>();
            while (num != 0)
            {
                bin.Add((short)(num % 2));
                num = (short)(num / 2);
            }

            bin.Reverse();
            return bin;
        }

        private static string EndingNums(string strNum, int endingNum)
        {
            var newNum = new StringBuilder();
            while (newNum.Length != 16 - strNum.Length)
            {
                newNum.Append(endingNum);
            }

            newNum.Append(strNum);
            return newNum.ToString();
        }
    }
}
