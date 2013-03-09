using System;

public static class Distance3D
{
    public static double CalcDistance(Point3D pointOne, Point3D pointTwo)
    {
        double distance = 0;
        distance = Math.Sqrt(Math.Pow(pointOne.PointX - pointTwo.PointX, 2) + Math.Pow(pointOne.PointY - pointTwo.PointY, 2) + Math.Pow(pointOne.PointZ - pointTwo.PointZ, 2));

        return distance;
    }
}
