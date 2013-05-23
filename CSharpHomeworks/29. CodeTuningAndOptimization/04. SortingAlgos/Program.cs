namespace SortingAlgos
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static string ListShow(List<int> array)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < array.Count; i++)
            {
                output.AppendFormat("{0} ", array[i]);
            }

            return output.ToString();
        }

        public static string ListShow(List<double> array)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < array.Count; i++)
            {
                output.AppendFormat("{0} ", array[i]);
            }

            return output.ToString();
        }

        public static string ListShow(List<string> array)
        {
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < array.Count; i++)
            {
                output.AppendFormat("{0} ", array[i]);
            }

            return output.ToString();
        }

        public static void Main()
        {
            Sorter myTestSorter = new Sorter();
            Stopwatch testWatch = new Stopwatch();
            ListGenerator testGen = new ListGenerator();

            // test values
            // ints
            List<int> orderedInts = testGen.GenerateOrderdIntList();
            List<int> reversedInts = testGen.GenerateReverseOrderdIntList();
            List<int> randomInts = testGen.GenerateRandomIntList();

            // doubles
            List<double> orderedDouble = testGen.GenerateOrderdDoubleList();
            List<double> reversedDouble = testGen.GenerateReverseOrderdDoubleList();
            List<double> randomDouble = testGen.GenerateReverseOrderdDoubleList();

            // strings
            List<string> orderedString = testGen.GenerateOrderdStringList();
            List<string> reversedString = testGen.GenerateReverseOrderdStringList();
            List<string> randomString = testGen.GenerateRandomStringList();

            // Tests
            #region Ordered Ints
            Console.WriteLine("ORDERED INT TESTS");
                
            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(orderedInts));
            testWatch.Start();
            myTestSorter.SelectionSort(orderedInts);
            testWatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListShow(orderedInts));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            orderedInts = testGen.GenerateRandomIntList();

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(orderedInts));
            testWatch.Start();
            myTestSorter.InsertionSort(orderedInts);
            testWatch.Stop();
            Console.WriteLine("After insetion sort: {0}", ListShow(orderedInts));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            orderedInts = testGen.GenerateRandomIntList();

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(orderedInts));
            testWatch.Start();
            myTestSorter.QuickSort(orderedInts);
            testWatch.Stop();
            Console.WriteLine("After Quick sort: {0}", ListShow(orderedInts));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            orderedInts = testGen.GenerateRandomIntList();

            Console.WriteLine();
            #endregion

            #region Orderd Doubles
            Console.WriteLine("ORDERED DOUBLE TEST");

            Console.WriteLine();
            Console.WriteLine("Before sort: {0}", ListShow(orderedDouble));
            testWatch.Start();
            myTestSorter.SelectionSort(orderedDouble);
            testWatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListShow(orderedDouble));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            orderedDouble = testGen.GenerateOrderdDoubleList();

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(orderedDouble));
            testWatch.Start();
            myTestSorter.InsertionSort(orderedDouble);
            testWatch.Stop();
            Console.WriteLine("After insetion sort: {0}", ListShow(orderedDouble));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            orderedDouble = testGen.GenerateOrderdDoubleList();

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(orderedDouble));
            testWatch.Start();
            myTestSorter.QuickSort(orderedDouble);
            testWatch.Stop();
            Console.WriteLine("After Quick sort: {0}", ListShow(orderedDouble));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            orderedDouble = testGen.GenerateOrderdDoubleList();

            Console.WriteLine();

            #endregion

            #region Orderd Strings
            Console.WriteLine("ORDERED STRING TEST");

            Console.WriteLine();
            Console.WriteLine("Before sort: {0}", ListShow(orderedString));
            testWatch.Start();
            myTestSorter.SelectionSort(orderedString);
            testWatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListShow(orderedString));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            orderedString = testGen.GenerateReverseOrderdStringList();

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(orderedString));
            testWatch.Start();
            myTestSorter.InsertionSort(orderedString);
            testWatch.Stop();
            Console.WriteLine("After insetion sort: {0}", ListShow(orderedString));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            orderedString = testGen.GenerateReverseOrderdStringList();

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(orderedString));
            testWatch.Start();
            myTestSorter.QuickSort(orderedString);
            testWatch.Stop();
            Console.WriteLine("After Quick sort: {0}", ListShow(orderedString));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            orderedString = testGen.GenerateReverseOrderdStringList();

            Console.WriteLine();

            #endregion

            #region Reverse Ordered Ints
            Console.WriteLine("REVERS ORDERED INT TESTS");

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(reversedInts));
            testWatch.Start();
            myTestSorter.SelectionSort(reversedInts);
            testWatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListShow(reversedInts));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            reversedInts = testGen.GenerateReverseOrderdIntList();

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(reversedInts));
            testWatch.Start();
            myTestSorter.InsertionSort(reversedInts);
            testWatch.Stop();
            Console.WriteLine("After insetion sort: {0}", ListShow(reversedInts));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            reversedInts = testGen.GenerateReverseOrderdIntList();

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(reversedInts));
            testWatch.Start();
            myTestSorter.QuickSort(reversedInts);
            testWatch.Stop();
            Console.WriteLine("After Quick sort: {0}", ListShow(reversedInts));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            reversedInts = testGen.GenerateReverseOrderdIntList();

            Console.WriteLine();
            #endregion

            #region Reverse Ordered Doubles
            Console.WriteLine("REVERS ORDERED DOUBLE TESTS");

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(reversedDouble));
            testWatch.Start();
            myTestSorter.SelectionSort(reversedDouble);
            testWatch.Stop();
            Console.WriteLine("After selection sort: {0}", ListShow(reversedDouble));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            reversedDouble = testGen.GenerateReverseOrderdDoubleList();

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(reversedDouble));
            testWatch.Start();
            myTestSorter.InsertionSort(reversedDouble);
            testWatch.Stop();
            Console.WriteLine("After insetion sort: {0}", ListShow(reversedDouble));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            reversedDouble = testGen.GenerateReverseOrderdDoubleList();

            Console.WriteLine();

            Console.WriteLine("Before sort: {0}", ListShow(reversedDouble));
            testWatch.Start();
            myTestSorter.QuickSort(reversedDouble);
            testWatch.Stop();
            Console.WriteLine("After Quick sort: {0}", ListShow(reversedDouble));

            Console.WriteLine("Time - {0}", testWatch.Elapsed);
            testWatch.Reset();
            reversedDouble = testGen.GenerateReverseOrderdDoubleList();

            Console.WriteLine();
            #endregion

            #region Reverse Orderd Strings

            #endregion

        }
    }
}
