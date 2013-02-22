using System;

public static class Distance3D
{
    public static double CalcDistance(Point3D pointOne, Point3D pointTwo)
    {
        double distance = 0;
        distance = Math.Sqrt(Math.Pow(pointOne.pointX - pointTwo.pointX, 2) + Math.Pow(pointOne.pointY - pointTwo.pointY, 2) + Math.Pow(pointOne.pointZ - pointTwo.pointZ, 2));

        return distance;
    }
}
