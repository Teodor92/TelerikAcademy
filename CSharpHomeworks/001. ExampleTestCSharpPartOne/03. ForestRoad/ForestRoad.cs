using System;

class ForestRoad
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int position = 0;
        for (int i = 1; i <= n; i++)
        {
            position++;
            for (int j = 1; j <= n; j++ )
            {
                if ( position == j)
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
