using System;

public delegate void Ticker(int start);

public class Timer
{
    public int Nums { get; set; }

    public void TickerPross(int start)
    {
        Console.WriteLine(this.Nums);
        this.Nums++;
    }
}