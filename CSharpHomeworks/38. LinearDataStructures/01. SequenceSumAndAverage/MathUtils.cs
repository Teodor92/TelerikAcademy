namespace SequenceSumAndAverage
{
    using System;
    using System.Collections.Generic;

    public class MathUtils
    {
        public static decimal FindAverage(List<int> myList)
        {
            if (myList == null || myList.Count == 0)
            {
                throw new ArgumentNullException("List must not be empty!");
            }

            decimal average = 0;
            decimal sum = 0;

            decimal listLen = myList.Count;

            sum = FindSum(myList);
            average = sum / listLen;

            return average;
        }

        public static long FindSum(List<int> myList)
        {
            if (myList == null || myList.Count == 0)
            {
                throw new ArgumentNullException("List must not be empty!");
            }

            long sum = 0;

            for (int i = 0; i < myList.Count; i++)
            {
                sum = sum + myList[i];
            }

            return sum;
        }
    }
}
