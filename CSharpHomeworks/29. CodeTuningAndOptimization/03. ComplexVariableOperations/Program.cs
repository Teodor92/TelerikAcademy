namespace ComplexVariableOperations
{
    using System;
    using System.Diagnostics;

    public class Program
    {
        public static void Main()
        {
            // Note: I am not using methods, generics etc. so we can get as accurate readings as we can.
            // Edit the value below to change the amount of test to run.
            int testCount = 10000000;
            Stopwatch testWatch = new Stopwatch();

            #region Sin Tests

            Console.WriteLine("SIN TESTS");

            testWatch.Start();
            for (float i = 0; i < testCount; i++)
            {
                Math.Sin(i);
            }

            testWatch.Stop();

            Console.WriteLine("Float - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (double i = 0; i < testCount; i++)
            {
                Math.Sin(i);
            }

            testWatch.Stop();

            Console.WriteLine("Double - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (decimal i = 0; i < testCount; i++)
            {
                Math.Sin((double)i);
            }

            testWatch.Stop();

            Console.WriteLine("Decimal - {0}", testWatch.Elapsed);
            testWatch.Reset();

            #endregion

            Console.WriteLine();

            #region Square Root

            Console.WriteLine("SQUARE ROOT TESTS");

            testWatch.Start();
            for (float i = 0; i < testCount; i++)
            {
                Math.Sqrt(i);
            }

            testWatch.Stop();

            Console.WriteLine("Float - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (double i = 0; i < testCount; i++)
            {
                Math.Sqrt(i);
            }

            testWatch.Stop();

            Console.WriteLine("Double - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (decimal i = 0; i < testCount; i++)
            {
                Math.Sqrt((double)i);
            }

            testWatch.Stop();

            Console.WriteLine("Decimal - {0}", testWatch.Elapsed);
            testWatch.Reset();

            #endregion

            Console.WriteLine();

            #region Log Tests

            Console.WriteLine("NATURAL LOGARITHM TESTS");

            testWatch.Start();
            for (float i = 0; i < testCount; i++)
            {
                Math.Log10(i);
            }

            testWatch.Stop();

            Console.WriteLine("Float - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (double i = 0; i < testCount; i++)
            {
                Math.Log10(i);
            }

            testWatch.Stop();

            Console.WriteLine("Double - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (decimal i = 0; i < testCount; i++)
            {
                Math.Log10((double)i);
            }

            testWatch.Stop();

            Console.WriteLine("Decimal - {0}", testWatch.Elapsed);
            testWatch.Reset();

            #endregion

            Console.WriteLine();
        }
    }
}
