namespace BinaryPasswords
{
    using System;
    using System.Numerics;

    public class Program
    {
        public static void Main()
        {
            string line = Console.ReadLine();
            BigInteger starCounter = 0;

            if (string.IsNullOrEmpty(line))
            {
                Console.WriteLine(0);
                return;
            }

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == '*')
                {
                    starCounter++;
                }
            }

            BigInteger combos = (BigInteger)Math.Pow(2, (ulong)starCounter);

            Console.WriteLine(combos);
        }
    }
}
