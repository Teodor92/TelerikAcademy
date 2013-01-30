using System;

class Cake
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        double numGuests = double.Parse(input[0]);
        double piecesOfCake = double.Parse(input[1]);
        Console.WriteLine(Math.Ceiling(numGuests / piecesOfCake));
    }
}
