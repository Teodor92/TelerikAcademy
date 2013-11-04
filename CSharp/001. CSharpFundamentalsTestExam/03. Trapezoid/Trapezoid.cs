using System;

class Trapezoid
{
    static void Main()
    {
        
        int n = int.Parse(Console.ReadLine());
        int position = n;
        // top
        for (int i = 0; i < n; i++)
        {
            Console.Write('.');
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write('*');
        }
        Console.WriteLine();
        //center
        for (int i = 0; i < n-1; i++)
        {
            for (int j = 0; j < n*2; j++)
            {
                if (j + 1 == position || j+1 == n*2 )
                {
                    Console.Write('*');
                }
                else
                {
                    Console.Write('.');
                }
            }
            Console.WriteLine();
            position--;
        }
        // bottom
        for (int i = 0; i < n*2; i++)
        {
            Console.Write('*');
        }
        Console.WriteLine();
    }
}
