using System;

public class Program
{
    public static void Main()
    {
        Shape[] myShapes = 
        {
            new Triangle(2, 2),
            new Circle(4),
            new Rectangle(2, 6)
        };

        foreach (var shape in myShapes)
        {
            Console.WriteLine(shape.CalculateSurface());
        }
    }
}
