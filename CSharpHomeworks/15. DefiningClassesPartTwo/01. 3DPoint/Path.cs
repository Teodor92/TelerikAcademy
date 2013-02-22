using System;
using System.Collections.Generic;

public class Path
{
    public readonly List<Point3D> allPoints = new List<Point3D>();

    public List<Point3D> Paths
    {
        get
        {
            return this.allPoints;
        }
    }

    public void AddPoint(Point3D point)
    {
        allPoints.Add(point);
    }

    public void ClearPath()
    {
        allPoints.Clear();
    }
}
