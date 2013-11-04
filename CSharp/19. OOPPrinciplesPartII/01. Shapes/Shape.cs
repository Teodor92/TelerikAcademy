using System;

abstract class Shape
{
    private double? width;
    private double? height;


    public Shape() : this(null, null)
    {
    }

    public Shape(double width) : this(width, null)
    {
    }

    public Shape(double? width, double? height)
    {
        this.width = width;
        this.height = height;
    }

    public double? Width
    {
        get
        {
            return this.width;
        }
        set
        {
            this.width = value;
        }
    }

    public double? Height
    {
        get
        {
            return this.height;
        }
        set
        {
            this.height = value;
        }
    }

    public abstract double? CalculateSurface();
}
