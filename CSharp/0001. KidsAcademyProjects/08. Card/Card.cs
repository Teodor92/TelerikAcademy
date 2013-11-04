using System;

class Card
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        Console.WriteLine("  #*#  ");
        Console.WriteLine("  ***  ");
        Console.WriteLine("  #*#  ");
        Console.WriteLine("   {0}   ", input[1]);
        Console.WriteLine("{0}  {1}  {2}", input[0], input[1], input[0]);
        Console.WriteLine(" {0} {1} {2} ", input[0], input[1], input[0]);
        Console.WriteLine("  {0}{1}{2}  ", input[0], input[1], input[0]);
    }
}