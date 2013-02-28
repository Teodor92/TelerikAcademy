using System;

public delegate void Ticker(int start);

public class Timer
{
    public int nums { get; set; }
    public void TickerPross(int start)
    {
        Console.WriteLine(this.nums);
        this.nums++;
    }
}

