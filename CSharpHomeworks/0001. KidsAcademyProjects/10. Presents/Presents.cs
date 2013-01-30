using System;

class Presents
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split(' ');
        int tieMeters = int.Parse(input[0]);
        int tieCentemeters = int.Parse(input[1]);
        int numOfPresents = int.Parse(input[2]);
        tieMeters = tieMeters * numOfPresents;
        tieCentemeters = tieCentemeters * numOfPresents;
        tieMeters = tieMeters + (tieCentemeters / 100);
        tieCentemeters = tieCentemeters % 100;
        Console.WriteLine("{0} {1}", tieMeters, tieCentemeters);
    }
}
