using System;
using System.Text;
using System.Collections.Generic;

public struct Point3D
{
    public int pointX { get; set; }
    public int pointY { get; set; }
    public int pointZ { get; set; }

    static private Point3D zero = new Point3D(0, 0, 0);

    public Point3D(int pointX, int pointY, int pointZ)
        : this()
    {
        this.pointX = pointX;
        this.pointY = pointY;
        this.pointZ = pointZ;
    }

    public static Point3D Zero
    {
        get
        {
            return zero;
        }
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

public class Program
{
    static void Main()
    {
        Point3D point = new Point3D(1, 2, 3);
        Point3D pointTwo = new Point3D(3, 4, 5);
        //Console.WriteLine(Distance3D.DistanceCalc(point, pointTwo));
        //Console.WriteLine(point);
        //Console.WriteLine(Point3D.Zero);

        Path firstPath = new Path();
        firstPath.AddPoint(pointTwo);
        firstPath.AddPoint(point);
        firstPath.AddPoint(pointTwo);

        PathStorage.PathSave(firstPath);
        List<Path> pathList = PathStorage.PathLoad();
        foreach (var path in pathList)
        {
            Console.WriteLine("-----Path Start-------");
            foreach (var pointers in path.Paths)
            {
                Console.WriteLine(pointers);
            }
            Console.WriteLine("-----Path End-------");
            
        }

        //foreach (var item in firstPath.Paths)
        //{
        //    Console.WriteLine(item);
        //}
    }
}
