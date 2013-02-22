using System;
using System.Text;

public struct Point3D
{
    public int pointX { get; set; }
    public int pointY { get; set; }
    public int pointZ { get; set; }

    static public readonly Point3D zero = new Point3D(0, 0, 0);

    public Point3D(int pointX, int pointY, int pointZ) : this()
    {
        this.pointX = pointX;
        this.pointY = pointY;
        this.pointZ = pointZ;
    }


    public override string ToString()
    {
        StringBuilder endText = new StringBuilder();
        endText.AppendFormat("Point X: {0}", this.pointX.ToString());
        endText.AppendLine();
        endText.AppendFormat("Point Y: {0}", this.pointY.ToString());
        endText.AppendLine();
        endText.AppendFormat("Point Z: {0} \n-", this.pointZ.ToString());
        return endText.ToString();
    }
}