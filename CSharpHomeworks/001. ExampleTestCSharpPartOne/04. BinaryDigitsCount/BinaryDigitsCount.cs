using System;

class BinaryDigitsCount
{
    static void Main()
    {
        byte digit = byte.Parse(Console.ReadLine());
        short n = short.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            long number = long.Parse(Console.ReadLine());
            int digitCounter = 0;
            while(true)
            {
                if (number == 0)
                {
                    break;
                }
                if( number % 2 == digit)
                {
                    digitCounter++;
                }
                number = number / 2;
            }
            Console.WriteLine(digitCounter);
        }

    }
}
