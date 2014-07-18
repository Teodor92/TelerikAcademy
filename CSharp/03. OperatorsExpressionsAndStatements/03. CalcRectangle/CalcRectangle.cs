namespace _03.CalcRectangle
{
    using System;

    /// <summary>
    /// Write an expression that calculates rectangle’s area by given width and height.
    /// </summary>
    public class CalcRectangle
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("Please enter width");
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine("Plase enter hight");
            int hight = int.Parse(Console.ReadLine());
            Console.WriteLine("The area od the rectangle is: {0}", width * hight);
        }
    }
}
