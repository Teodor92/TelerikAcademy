using System;

class FirTree
{
    static void Main()
    {
        byte n = byte.Parse(Console.ReadLine());
        int length = n * 2 - 3;
        int treeCounter = 0;
        int firstHalf = 0;
        firstHalf = length / 2;
        //body
        for (int i = 0; i < n-1; i++)
        {
            treeCounter = length/2 + i;
            
            for (int j = 0; j < length; j++)
            {
                if (firstHalf > j || j > treeCounter)
                {
                    Console.Write('.');
                }
                else
                {
                    Console.Write('*');
                }
            }
            firstHalf--;
            Console.WriteLine();
        }
        //bottom
        for (int i = 0; i < length; i++)
        {
            if (i == (length) / 2)
            {
                Console.Write('*');
            }
            else
            {
                Console.Write('.');
            }
        }
        Console.WriteLine();
    }
}
