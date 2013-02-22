using System;

public static class Distance3D
{
    public static double DistanceCalc(Point3D pointOne, Point3D pointTwo)
    {
        double distance = 0;
        distance = Math.Sqrt(pointOne.pointX*pointTwo.pointX + pointOne.pointY*pointTwo.pointY + pointOne.pointZ*pointTwo.pointZ);

        return distance;
    }
}
