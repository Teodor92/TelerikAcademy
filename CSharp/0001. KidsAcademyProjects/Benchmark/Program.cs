namespace Benchmark
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public class Benchmark
    {
        // Place methods here (if there are any)!
        internal static void Main()
        {
            // change here to adjust the numbe of time your code will be run
            const int Repetitions = 200;

            var sw = new Stopwatch();
            var times = new List<decimal>();
            
            // define input here!
            var input = Console.ReadLine().Split(' ');
            var numOfPresents = int.Parse(Console.ReadLine());

            for (int i = 1; i <= Repetitions; i++)
            {
                sw.Start();

                int tieMeters = int.Parse(input[0]);
                int tieCentemeters = int.Parse(input[1]);

                tieMeters = tieMeters * numOfPresents;
                tieCentemeters = tieCentemeters * numOfPresents;
                tieMeters = tieMeters + (tieCentemeters / 100);
                tieCentemeters = tieCentemeters % 100;
                Console.WriteLine("{0} {1}", tieMeters, tieCentemeters);

                sw.Stop();
                times.Add(Convert.ToDecimal(sw.Elapsed.TotalSeconds));
                sw.Reset();
            }

            times.Sort();
            Console.WriteLine("\n\n\nMinimum runtime: " + times[0] + " seconds");
            Console.WriteLine("\nMaximum runtime: " + times[times.Count - 1] + " seconds");

            var avarage = 0m;
            for (int i = 0; i < times.Count; i++)
            {
                avarage = avarage + times[i];
            }

            avarage = avarage / times.Count;
            Console.WriteLine("\nAvarage runtime: " + avarage + " seconds\n");
        }
    }
}
