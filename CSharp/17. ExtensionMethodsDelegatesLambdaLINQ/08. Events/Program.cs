using System;

public class Program
{
    public static void Main()
    {
        Publisher pub = new Publisher();
        Handler handler = new Handler(pub);
        pub.Starter(2, 20);
    }
}
