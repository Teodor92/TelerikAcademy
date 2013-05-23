namespace CohesionAndCoupling
{
    using System;

    public class Utils3D
    {
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)) + ((z2 - z1) * (z2 - z1)));
            return distance;
        }

        public static double CalcVolume(double x, double y, double z)
        {
            double volume = x * y * z;
            return volume;
        }

        public static double CalcDistanceTo3DOrgin(double x, double y, double z)
        {
            double distance = CalcDistance3D(0, 0, 0, x, y, z);
            return distance;
        }
    }
}
