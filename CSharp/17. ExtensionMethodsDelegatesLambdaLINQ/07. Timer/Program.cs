using System;
using System.Threading;

public class Program
{
    public delegate void CountEventHandler();

    public event CountEventHandler Counter;

    public static void Main()
    {
        Timer obj = new Timer();
        Ticker timer = new Ticker(obj.TickerPross);

        while (true)
        {
            Thread.Sleep(1000);
            timer(0);
        }
    }
}
