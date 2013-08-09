namespace TrianglePoints
{
    /* 
     * You are given 3 points A, B and C, forming triangle, and 
     * a point P. Check if the point P is in the triangle or not. 
     */

    /* 
     * Note: This solution uses Barycentric coordinates. You can find more about them here:
     * http://en.wikipedia.org/wiki/Barycentric_coordinates_%28mathematics%29
     */

    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Point PointA = new Point(0, 0);
            Point PointB = new Point(0, 3);
            Point PointC = new Point(4, 0);

            Point PointX = new Point(3, 0.5);

            Triangle myTriangle = new Triangle(PointA, PointB, PointC);
            Console.WriteLine(myTriangle.CheckIfPointIsInTriangle(PointX));
        }
    }
}
