using System;

public class Display
{
    private int size;
    private int numberOfColors;

    public Display(int size) : this(size, 0)
    { 
        
    }

    public Display(int size, int numberOfColors)
    {
        this.size = size;
        this.numberOfColors = numberOfColors;
    }

    public int Size
    {
        get { return this.size; }
        set { this.size = value; }
    }

    public int NumberOfColors
    {
        get { return this.numberOfColors; }
        set { this.numberOfColors = value; }
    }
}

