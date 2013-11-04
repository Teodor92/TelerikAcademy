/* Write an expression that checks if 
 * given point (x,  y) is within a circle K(O, 5).
 */

using System;

class PointInCircle
{
    static void Main()
    {
        int circleRadius = 5;
        int pointX = 4;
        int pointY = 3;
        double disFormPointToCenter = Math.Sqrt(pointX * pointX + pointY * pointY);
        if (circleRadius >= disFormPointToCenter)
        {
            Console.WriteLine("The point is in the circle");
        }
        else
        {
            Console.WriteLine("The point is NOT in the circle");
        }
    }
}
