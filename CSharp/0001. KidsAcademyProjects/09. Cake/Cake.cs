namespace _09.Cake
{
    using System;

    public class Cake
    {
        internal static void Main()
        {
            var input = Console.ReadLine().Split();
            var numGuests = double.Parse(input[0]);
            var piecesOfCake = double.Parse(input[1]);
            Console.WriteLine(Math.Ceiling(numGuests / piecesOfCake));
        }
    }
}
