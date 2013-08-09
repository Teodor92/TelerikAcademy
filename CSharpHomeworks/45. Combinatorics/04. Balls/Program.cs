namespace Balls
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Program
    {
        public static BigInteger CalcFactorial(int n)
        {
            BigInteger result = 1;

            for (int i = n; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }

        public static void Main()
        {
            string line = Console.ReadLine();

            Dictionary<char, int> balls = new Dictionary<char, int>();

            for (int i = 0; i < line.Length; i++)
            {
                if (balls.ContainsKey(line[i]))
                {
                    balls[line[i]]++;
                }
                else
                {
                    balls.Add(line[i], 1);
                }
            }

            BigInteger allFac = CalcFactorial(line.Length);

            foreach (var item in balls)
            {
                allFac /= CalcFactorial(item.Value);
            }

            Console.WriteLine(allFac);
        }
    }
}
