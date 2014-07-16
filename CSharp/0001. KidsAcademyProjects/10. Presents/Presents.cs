namespace _10.Presents
{
    using System;

    public class Presents
    {
        internal static void Main()
        {
            var input = Console.ReadLine().Split(' ');
            var tieMeters = int.Parse(input[0]);
            var tieCentemeters = int.Parse(input[1]);
            var numOfPresents = int.Parse(input[2]);
            tieMeters = tieMeters * numOfPresents;
            tieCentemeters = tieCentemeters * numOfPresents;
            tieMeters = tieMeters + (tieCentemeters / 100);
            tieCentemeters = tieCentemeters % 100;
            Console.WriteLine("{0} {1}", tieMeters, tieCentemeters);
        }
    }
}
