using System;

[VersionAttribute(5.5)]
public class Point3D
{
    public Point3D(int x, int y, int z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public int X { get; set; }

    public int Y { get; set; }

    public int Z { get; set; }
}