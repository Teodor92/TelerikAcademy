using System;

public class Handler
{
    public Handler(Publisher publish)
    {
        publish.RaiseEventFlag += this.CustomEvent;
    }

    public void CustomEvent(object sender, EventArgs e)
    {
        Console.WriteLine("This is a test message!");
    }
}