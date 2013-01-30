using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;

class ProblemFour
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        //top
        for (int i = n/2; i > 0; i--)
        {
            Console.Write(new string('.', n/2 - i));
            Console.Write("\\");
            Console.Write(new string('.',i - 1));
            Console.Write("|");
            Console.Write(new string('.',i - 1));
            Console.Write("/");
            Console.Write(new string('.', n / 2 - i));
            Console.WriteLine();
        }
        //middle
        Console.Write(new string('-', n/2));
        Console.Write('*');
        Console.WriteLine(new string('-', n / 2));
        // bottom
        for (int i = n / 2; i > 0; i--)
        {
            Console.Write(new string('.', i - 1));         
            Console.Write("/");
            Console.Write(new string('.', n / 2 - i));
            Console.Write("|");
            Console.Write(new string('.', n / 2 - i));
            Console.Write("\\");
            Console.Write(new string('.', i - 1));
            Console.WriteLine();
        }
    }
}
