using System;
using System.Collections.Generic;
using System.Diagnostics;

//Written by Kristian Nikolov 2012

class Benchmark
{

    //Place methods here (if there are any)!


    static void Main()
    {
        Stopwatch sw = new Stopwatch();
        List<decimal> times = new List<decimal>();
        int repetitions = 200; //change here to adjust the numbe of time your code will be run




        //define input here!
        string[] input = Console.ReadLine().Split(' ');
        int numOfPresents = int.Parse(Console.ReadLine());


        for (int i = 1; i <= repetitions; i++)
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

        decimal avarage = 0m;
        for (int i = 0; i < times.Count; i++)
        {
            avarage = avarage + times[i];
        }
        avarage = avarage / times.Count;
        Console.WriteLine("\nAvarage runtime: " + avarage + " seconds\n");


    }
}
