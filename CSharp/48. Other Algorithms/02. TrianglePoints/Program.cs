namespace _02.TrianglePoints
{
    using System;

    /// <summary>
    /// You are given 3 points A, B and C, forming triangle, and 
    /// a point P. Check if the point P is in the triangle or not. 
    /// 
    /// Note: This solution uses Barycentric coordinates. You can find more about them here:
    /// http://en.wikipedia.org/wiki/Barycentric_coordinates_%28mathematics%29
    /// </summary>
    public class Program
    {
        internal static void Main(string[] args)
        {
            var pointA = new Point(0, 0);
            var pointB = new Point(0, 3);
            var pointC = new Point(4, 0);

            var pointX = new Point(3, 0.5);

            var myTriangle = new Triangle(pointA, pointB, pointC);
            Console.WriteLine(myTriangle.CheckIfPointIsInTriangle(pointX));
        }
    }
}
