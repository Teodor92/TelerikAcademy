using System;
using System.Text;

public struct Point3D
{
    public static readonly Point3D Zero = new Point3D(0, 0, 0);

    public Point3D(int pointX, int pointY, int pointZ)
        : this()
    {
        this.PointX = pointX;
        this.PointY = pointY;
        this.PointZ = pointZ;
    }

    public int PointX { get; set; }

    public int PointY { get; set; }

    public int PointZ { get; set; }

    public override string ToString()
    {
        StringBuilder endText = new StringBuilder();
        endText.AppendFormat("Point X: {0}", this.PointX.ToString());
        endText.AppendLine();
        endText.AppendFormat("Point Y: {0}", this.PointY.ToString());
        endText.AppendLine();
        endText.AppendFormat("Point Z: {0} \n-", this.PointZ.ToString());
        return endText.ToString();
    }
}