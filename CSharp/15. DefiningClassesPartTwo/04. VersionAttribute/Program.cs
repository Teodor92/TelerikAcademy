using System;

public class Program
{
    public static void Main()
    {
        Point3D testPoint = new Point3D(1, 2, 3);
        Type myType = typeof(Point3D);

        object[] myAttributes = myType.GetCustomAttributes(false);

        foreach (VersionAttribute attr in myAttributes)
        {
            Console.WriteLine("{0} {1}", attr, attr.Version);
        }
    }
}
