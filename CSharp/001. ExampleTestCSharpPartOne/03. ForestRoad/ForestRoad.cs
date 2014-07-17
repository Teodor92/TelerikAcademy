namespace _03.ForestRoad
{
    using System;

    public class ForestRoad
    {
        internal static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var position = 0;

            for (int i = 1; i <= n; i++)
            {
                position++;
                for (int j = 1; j <= n; j++)
                {
                    if (position == j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }

            for (int i = 1; i < n; i++)
            {
                position--;
                for (int j = 1; j <= n; j++)
                {
                    if (position == j)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
