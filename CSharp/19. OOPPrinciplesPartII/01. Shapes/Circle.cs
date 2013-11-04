using System;

public class Circle : Shape
{
    public Circle(double radius)
        : base(radius * 2, radius * 2)
    {
    }

    public override double? CalculateSurface()
    {
        return 2 * Math.PI * this.Height;
    }
}