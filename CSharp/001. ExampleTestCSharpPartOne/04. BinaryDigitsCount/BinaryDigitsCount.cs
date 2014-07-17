namespace _04.BinaryDigitsCount
{
    using System;

    public class BinaryDigitsCount
    {
        internal static void Main()
        {
            var digit = byte.Parse(Console.ReadLine());
            var n = short.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var number = long.Parse(Console.ReadLine());
                int digitCounter = 0;

                while (true)
                {
                    if (number == 0)
                    {
                        break;
                    }

                    if (number % 2 == digit)
                    {
                        digitCounter++;
                    }

                    number = number / 2;
                }

                Console.WriteLine(digitCounter);
            }
        }
    }
}
