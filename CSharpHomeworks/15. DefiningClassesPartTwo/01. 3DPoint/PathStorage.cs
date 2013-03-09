using System;
using System.Collections.Generic;
using System.IO;

public static class PathStorage
{
    public static void SavePath(Path path)
    {
        using (StreamWriter writer = new StreamWriter(@"../../PathSaves.txt"))
        {
            foreach (var point in path.AllPoints)
            {
                writer.WriteLine(point);
            }
        }
    }

    public static List<Path> LoadPath()
    {
        Path loadPath = new Path();
        List<Path> pathsLoaded = new List<Path>();
        using (StreamReader reader = new StreamReader(@"../../PathLoads.txt"))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                if (line != "-")
                {
                    Point3D point = new Point3D();
                    string[] points = line.Split(',');
                    point.PointX = int.Parse(points[0]);
                    point.PointY = int.Parse(points[1]);
                    point.PointZ = int.Parse(points[2]);
                    loadPath.AddPoint(point);
                }
                else
                {
                    pathsLoaded.Add(loadPath);
                    loadPath = new Path();
                }

                line = reader.ReadLine();
            }
        }

        return pathsLoaded;
    }
}
