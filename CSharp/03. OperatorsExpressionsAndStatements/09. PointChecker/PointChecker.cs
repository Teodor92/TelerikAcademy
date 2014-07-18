namespace _09.PointChecker
{
    using System;

    /// <summary>
    /// Write an expression that checks for given 
    /// point (x, y) if it is within 
    /// the circle K( (1,1), 3) and out of 
    /// the rectangle R(top=1, left=-1, width=6, height=2).
    /// </summary>
    public class PointChecker
    {
        internal static void Main()
        {
            int pointX = 1;
            int pointY = 4;
            int pointXforCircle = Math.Abs(pointX - 1);
            int pointYforCircle = Math.Abs(pointY - 1);
            bool inRecrangle = false;
            bool inCircle = Math.Sqrt((pointXforCircle * pointXforCircle) + (pointYforCircle * pointYforCircle)) <= 3;
            if (pointX >= -1 && pointX <= 5 && pointY <= 1 && pointY >= -1)
            {
                inRecrangle = true;
            }

            if (inCircle && !inRecrangle)
            {
                Console.WriteLine("The point is in the circle, but not in the rectangle");
            }
            else if (inRecrangle)
            {
                Console.WriteLine("The point is in the Rectangle");
            }
            else if (inCircle)
            {
                Console.WriteLine("The point is in the Circle");
            }
            else if (inCircle && inRecrangle)
            {
                Console.WriteLine("The point is in the Circle and in the Rectangle");
            }
            else
            {
                Console.WriteLine("The point is NOT in the circle and NOT in the rectangle");
            }
        }
    }
}
