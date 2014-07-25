namespace _04.HexadecimalToDecimal
{
    using System;

    public class HexadecimalToDecimal
    {
        public static void Main()
        {
            string hexNum = Console.ReadLine();
            int decNum = 0;
            for (int i = hexNum.Length - 1; i > -1; i--)
            {
                int power = hexNum.Length - (i + 1);
                switch (hexNum[i])
                {
                    case 'A': 
                        decNum = decNum + (10 * (int)Math.Pow(16, power)); 
                        break;
                    case 'B': 
                        decNum = decNum + (11 * (int)Math.Pow(16, power)); 
                        break;
                    case 'C': 
                        decNum = decNum + (12 * (int)Math.Pow(16, power)); 
                        break;
                    case 'D': 
                        decNum = decNum + (13 * (int)Math.Pow(16, power)); 
                        break;
                    case 'E': 
                        decNum = decNum + (14 * (int)Math.Pow(16, power)); 
                        break;
                    case 'F': 
                        decNum = decNum + (15 * (int)Math.Pow(16, power)); 
                        break;
                    default: 
                        decNum = decNum + (int.Parse(hexNum[i].ToString()) * (int)Math.Pow(16, power));
                        break;
                }
            }

            Console.WriteLine(decNum);
        }
    }
}
