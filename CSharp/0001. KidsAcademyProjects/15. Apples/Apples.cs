using System;

class Apples
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int y = int.Parse(input[0]);
        int k = int.Parse(input[1]);
        int n = int.Parse(input[2]);
        int rangeOfX = n - y;
        int counter = 0;
        for (int i = 1; i < rangeOfX + 1; i++)
        {
            if ((i+y)%k==0)
            {
                Console.Write("{0} ", i);
                counter++;
            }
        }
        if (counter == 0 || rangeOfX < 0)
        {
            Console.WriteLine(-1);
        }
        Console.WriteLine();

    }
}
