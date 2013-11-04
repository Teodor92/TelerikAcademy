using System;

class SandGlass
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int half = (n-1)/2;
        string halfLine = new string('.', half);
        int dotCounter = 0;
        int starCounter = n;
        // top half 
        for (int i = 0; i < half; i++)
        {
            Console.Write(new string('.', dotCounter));
            Console.Write(new string('*', starCounter));
            Console.Write(new string('.', dotCounter));
            dotCounter++;
            starCounter = starCounter - 2;
            Console.WriteLine();
        }
        //bottom half
        for (int i = 0; i <= half; i++)
        {
            Console.Write(new string('.', dotCounter));
            Console.Write(new string('*', starCounter));
            Console.Write(new string('.', dotCounter));
            dotCounter--;
            starCounter = starCounter + 2;
            Console.WriteLine();
        }
    }
}
