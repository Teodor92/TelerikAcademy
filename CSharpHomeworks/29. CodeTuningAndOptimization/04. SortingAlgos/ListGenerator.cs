namespace SortingAlgos
{
    using System;
    using System.Collections.Generic;

    public class ListGenerator
    {
        private Random randGen = new Random();

        public List<int> GenerateOrderdIntList()
        {
            List<int> localList = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                localList.Add(i);
            }

            return localList;
        }

        public List<double> GenerateOrderdDoubleList()
        {
            List<double> localList = new List<double>();

            for (double i = 0; i < 100; i++)
            {
                localList.Add(i);
            }

            return localList;
        }

        public List<string> GenerateOrderdStringList()
        {
            List<string> localList = new List<string>();

            for (double i = 0; i < 25; i++)
            {
                localList.Add(('a').ToString());
            }

            return localList;
        }

        public List<int> GenerateReverseOrderdIntList()
        {
            List<int> localList = new List<int>();

            for (int i = 100; i > 0; i--)
            {
                localList.Add(i);
            }

            return localList;
        }

        public List<double> GenerateReverseOrderdDoubleList()
        {
            List<double> localList = new List<double>();

            for (double i = 100; i > 0; i--)
            {
                localList.Add(i);
            }

            return localList;
        }

        public List<string> GenerateReverseOrderdStringList()
        {
            List<string> localList = new List<string>();

            for (double i = 25; i >= 0; i--)
            {
                localList.Add(('a').ToString());
            }

            return localList;
        }

        public List<int> GenerateRandomIntList()
        {
            List<int> localList = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                localList.Add(randGen.Next(0,100));
            }

            return localList;
        }

        public List<double> GenerateRandomDoubleList()
        {
            List<double> localList = new List<double>();

            for (double i = 0; i < 100; i++)
            {
                localList.Add(randGen.NextDouble());
            }

            return localList;
        }

        public List<string> GenerateRandomStringList()
        {
            List<string> localList = new List<string>();

            for (double i = 0; i < 100; i++)
            {
                localList.Add(('a' + randGen.Next(0,25)).ToString());
            }

            return localList;
        }
    }
}
