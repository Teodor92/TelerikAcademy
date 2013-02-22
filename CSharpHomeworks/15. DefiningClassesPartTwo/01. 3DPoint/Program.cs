using System;
using System.Text;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Point3D point = new Point3D(1, 2, 3);
        Point3D pointTwo = new Point3D(3, 4, 5);
        //Console.WriteLine(Distance3D.DistanceCalc(point, pointTwo));
        //Console.WriteLine(point);
        //Console.WriteLine(Point3D.Zero);
        Console.WriteLine(Point3D.zero);

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
