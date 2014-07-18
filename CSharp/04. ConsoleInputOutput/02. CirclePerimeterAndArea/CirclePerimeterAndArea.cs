namespace _02.CirclePerimeterAndArea
{
    using System;

    /// <summary>
    /// Write a program that reads the radius r of a circle 
    /// and prints its perimeter and area.
    /// </summary>
    public class CirclePerimeterAndArea
    {
        internal static void Main()
        {
            Console.WriteLine("Please enter the radius of the circle:");
            double radius = double.Parse(Console.ReadLine());
            double area = Math.PI * radius * radius;
            Console.WriteLine(area);

            double perimeter = 2 * Math.PI * radius;
            Console.WriteLine(perimeter);
        }
    }
}