using System;
using System.Threading;

public class Publisher : EventArgs
{
    public event EventHandler RaiseEventFlag;

    public void Starter(int sec, int end)
    {
        int start = 0;

        while (start <= end)
        {
            Thread.Sleep(sec * 1000);
            start = start + sec;
            Console.WriteLine(start);
        }
    }

    protected virtual void EventRaiser() 
    {
        EventHandler ev = this.RaiseEventFlag;
        if (ev != null)
        {
            ev(this, null);
        }
    }
}