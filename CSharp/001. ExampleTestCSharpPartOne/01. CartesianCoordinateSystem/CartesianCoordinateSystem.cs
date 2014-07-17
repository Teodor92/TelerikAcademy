namespace _01.CartesianCoordinateSystem
{
    using System;

    public class CartesianCoordinateSystem
    {
        internal static void Main()
        {
            var x = decimal.Parse(Console.ReadLine());
            var y = decimal.Parse(Console.ReadLine());

            if (x == 0 && y == 0)
            {
                Console.WriteLine(0);
            }
            else if (x > 0 && y > 0)
            {
                Console.WriteLine(1);
            }
            else if (x < 0 && y > 0)
            {
                Console.WriteLine(2);
            }
            else if (x < 0 && y < 0)
            {
                Console.WriteLine(3);
            }
            else if (x > 0 && y < 0)
            {
                Console.WriteLine(4);
            }
            else if (x == 0 && y != 0)
            {
                Console.WriteLine(5);
            }
            else if (x != 0 && y == 0)
            {
                Console.WriteLine(6);
            }
        }
    }
}
