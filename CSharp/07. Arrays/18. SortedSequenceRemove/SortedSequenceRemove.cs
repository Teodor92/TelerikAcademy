namespace _18.SortedSequenceRemove
{
    using System;
    using System.Collections.Generic;

    public class SubSetSum
    {
        internal static void Main()
        {
            long[] elements = { 6, 1, 4, 3, 0, 3, 6, 4, 5 };
            int len = 0;
            int bestLen = 0;
            var bestResult = new List<long>();
            int maxSubsets = (int)Math.Pow(2, elements.Length);
            for (int i = 1; i < maxSubsets; i++)
            {
                var result = new List<long>();

                for (int j = 0; j <= elements.Length; j++)
                {
                    int mask = 1 << j;
                    int valueNAndMask = i & mask;
                    int bit = valueNAndMask >> j;
                    if (bit == 1)
                    {
                        result.Add(elements[j]);
                        len++;
                    }
                }

                if (AreSorted(result))
                {
                    if (len > bestLen)
                    {
                        bestLen = len;
                        bestResult = result;
                    }
                }

                len = 0;
            }

            foreach (var item in bestResult)
            {
                Console.Write("{0} ", item);
            }
        }

        private static bool AreSorted(IList<long> array)
        {
            bool isSorted = true;
            for (int i = 0; i < array.Count - 1; i++)
            {
                if (!(array[i] <= array[i + 1]))
                {
                    isSorted = false;
                }
            }

            return isSorted;
        }
    }
}
