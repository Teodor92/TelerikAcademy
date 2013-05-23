namespace SimpleVariableOperations
{
    using System;
    using System.Diagnostics;

    public class Program
    {
        public static void Main()
        {
            // Note: I am not using methods, generics etc. so we can get as accurate readings as we can.
            Stopwatch testWatch = new Stopwatch();

            // edit the values below to cahnge the number of tests run.
            int sumTestCounts = 1000000;
            int substractTestCount = 1000000;
            int incrementTestCount = 1000000;
            int multiplyTestCount = 10000000;
            int divideTestCount = 10000000;

            int intLocalSum = 0;
            long longLocalSum = 0L;
            float floatLocalSum = 0f;
            double doubleLocalSum = 0;
            decimal decimalLocalSum = 0M;

            #region SumTests
            Console.WriteLine("SUM TESTS");

            testWatch.Start();
            for (int i = 0; i < sumTestCounts; i++)
            {
                intLocalSum += i;
            }

            testWatch.Stop();

            Console.WriteLine("Int - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (long i = 0; i < sumTestCounts; i++)
            {
                longLocalSum += i;
            }

            testWatch.Stop();

            Console.WriteLine("Long - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (double i = 0; i < sumTestCounts; i++)
            {
                doubleLocalSum += i;
            }

            testWatch.Stop();

            Console.WriteLine("Double - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (float i = 0; i < sumTestCounts; i++)
            {
                floatLocalSum += i;
            }

            testWatch.Stop();

            Console.WriteLine("Float - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (decimal i = 0; i < sumTestCounts; i++)
            {
                decimalLocalSum += i;
            }

            testWatch.Stop();

            Console.WriteLine("decimal - {0}", testWatch.Elapsed);
            testWatch.Reset();
            #endregion

            intLocalSum = 0;
            longLocalSum = 0L;
            floatLocalSum = 0f;
            doubleLocalSum = 0;
            decimalLocalSum = 0M;

            Console.WriteLine();

            #region SubstractTest

            Console.WriteLine("SUBSTRACT TESTS");

            testWatch.Start();
            for (int i = 0; i < substractTestCount; i++)
            {
                intLocalSum -= i;
            }

            testWatch.Stop();

            Console.WriteLine("Int - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (long i = 0; i < substractTestCount; i++)
            {
                longLocalSum -= i;
            }

            testWatch.Stop();

            Console.WriteLine("Long - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (double i = 0; i < substractTestCount; i++)
            {
                doubleLocalSum -= i;
            }

            testWatch.Stop();

            Console.WriteLine("Double - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (float i = 0; i < substractTestCount; i++)
            {
                floatLocalSum -= i;
            }

            testWatch.Stop();

            Console.WriteLine("Float - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (decimal i = 0; i < substractTestCount; i++)
            {
                decimalLocalSum -= i;
            }

            testWatch.Stop();

            Console.WriteLine("decimal - {0}", testWatch.Elapsed);
            testWatch.Reset();

            #endregion

            intLocalSum = 0;
            longLocalSum = 0L;
            floatLocalSum = 0f;
            doubleLocalSum = 0;
            decimalLocalSum = 0M;

            Console.WriteLine();

            #region IncrementTests

            Console.WriteLine("INCREMENT TESTS");

            testWatch.Start();
            for (int i = 0; i < incrementTestCount; i++)
            {
                intLocalSum++;
            }

            testWatch.Stop();

            Console.WriteLine("Int - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (long i = 0; i < incrementTestCount; i++)
            {
                longLocalSum++;
            }

            testWatch.Stop();

            Console.WriteLine("Long - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (double i = 0; i < incrementTestCount; i++)
            {
                doubleLocalSum++;
            }

            testWatch.Stop();

            Console.WriteLine("Double - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (float i = 0; i < incrementTestCount; i++)
            {
                floatLocalSum++;
            }

            testWatch.Stop();

            Console.WriteLine("Float - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (decimal i = 0; i < incrementTestCount; i++)
            {
                decimalLocalSum++;
            }

            testWatch.Stop();

            Console.WriteLine("decimal - {0}", testWatch.Elapsed);
            testWatch.Reset();

            #endregion

            intLocalSum = 1;
            longLocalSum = 1L;
            floatLocalSum = 1f;
            doubleLocalSum = 1;
            decimalLocalSum = 0M;

            Console.WriteLine();

            #region MultiplyTests

            Console.WriteLine("MULTIPLY TESTS");

            testWatch.Start();
            for (int i = 1; i < multiplyTestCount; i++)
            {
                intLocalSum *= i;
            }

            testWatch.Stop();

            Console.WriteLine("Int - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (long i = 1; i < multiplyTestCount; i++)
            {
                longLocalSum *= i;
            }

            testWatch.Stop();

            Console.WriteLine("Long - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (double i = 1; i < multiplyTestCount; i++)
            {
                doubleLocalSum *= i;
            }

            testWatch.Stop();

            Console.WriteLine("Double - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (float i = 1; i < multiplyTestCount; i++)
            {
                floatLocalSum *= i;
            }

            testWatch.Stop();

            Console.WriteLine("Float - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (decimal i = 1; i < multiplyTestCount; i++)
            {
                decimalLocalSum *= i;
            }

            testWatch.Stop();

            Console.WriteLine("Cant test decimal due to overflow.");
            Console.WriteLine("decimal - {0}", testWatch.Elapsed);
            testWatch.Reset();

            #endregion

            intLocalSum = int.MaxValue;
            longLocalSum = long.MaxValue;
            floatLocalSum = float.MaxValue;
            doubleLocalSum = double.MaxValue;
            decimalLocalSum = decimal.MaxValue;

            Console.WriteLine();

            #region DivisionTests

            Console.WriteLine("DIVISION TESTS");

            testWatch.Start();
            for (int i = 1; i < divideTestCount; i++)
            {
                intLocalSum /= i;
            }

            testWatch.Stop();

            Console.WriteLine("Int - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (long i = 1; i < divideTestCount; i++)
            {
                longLocalSum /= i;
            }

            testWatch.Stop();

            Console.WriteLine("Long - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (double i = 1; i < divideTestCount; i++)
            {
                doubleLocalSum /= i;
            }

            testWatch.Stop();

            Console.WriteLine("Double - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (float i = 1; i < divideTestCount; i++)
            {
                floatLocalSum /= i;
            }

            testWatch.Stop();

            Console.WriteLine("Float - {0}", testWatch.Elapsed);
            testWatch.Reset();

            testWatch.Start();
            for (decimal i = 1; i < divideTestCount; i++)
            {
                decimalLocalSum /= i;
            }

            testWatch.Stop();

            Console.WriteLine("decimal - {0}", testWatch.Elapsed);
            testWatch.Reset();

            #endregion

            Console.WriteLine();
        }
    }
}
