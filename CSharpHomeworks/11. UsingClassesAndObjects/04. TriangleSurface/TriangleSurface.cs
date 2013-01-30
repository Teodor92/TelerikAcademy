/* Write methods that calculate the surface of a triangle by given:
 * Side and an altitude to it; Three sides; 
 * Two sides and an angle between them. Use System.Math.
 */

using System;

public class TriangleSurface
{
    public static void Main()
    {
        // By side and hight
        double sideOne = 3;
        double heightToSideOne = 4;

        double area = (1d / 2d) * sideOne * heightToSideOne;
        Console.WriteLine(area);

        // By three sides
        double sideTwo = 4;
        double sideThree = 5;
        double semiperimeter = (sideOne + sideTwo + sideThree) / 2;

        area = Math.Sqrt(semiperimeter * (semiperimeter - sideOne) * (semiperimeter - sideTwo) * (semiperimeter - sideThree));
        Console.WriteLine(area);

        // By two sides and a angle
        double angle = 90;
        double angleInRads = (angle * Math.PI) / 180d;

        area = (1d / 2d) * sideOne * sideTwo * Math.Sin(angleInRads);
        Console.WriteLine(area);
    }
}
