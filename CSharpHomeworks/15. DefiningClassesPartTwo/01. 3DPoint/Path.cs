using System;
using System.Collections.Generic;

public class Path
{
    private List<Point3D> paths = new List<Point3D>();

    public List<Point3D> Paths
    {
        get
        {
            return this.paths;
        }
    }

    public void AddPoint(Point3D point)
    {
        paths.Add(point);
    }

    public void ClearPath()
    {
        paths.Clear();
    }
}
