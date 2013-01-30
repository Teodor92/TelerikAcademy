using System;

class OddNumber
{
    static void Main()
    {
            int lines = int.Parse(Console.ReadLine());
            long number = 0;
            long odd = 0;
 
            for (long i = 1; i <= lines; i++)
            {
                number = long.Parse(Console.ReadLine());
 
                odd = number ^ odd;    
            }
            Console.WriteLine(odd);
    }
}
