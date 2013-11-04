namespace MajorantFind
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class IListUtils
    {
        public static int FindMajorant(IList<int> sequence)
        {
            if (sequence == null || sequence.Count == 0)
            {
                throw new ArgumentNullException("Sequance must not be empty!");
            }

            int sequenceLength = sequence.Count;
            int bestMajorant = int.MinValue;
            Dictionary<int, int> countedElements = CountElements(sequence);

            foreach (var item in countedElements)
            {
                if (item.Value >= (sequenceLength / 2) - 1)
                {
                    if (bestMajorant < item.Value)
                    {
                        bestMajorant = item.Key;
                    }
                }
            }

            return bestMajorant;
        }

        private static Dictionary<int, int> CountElements(IList<int> sequence)
        {
            if (sequence == null || sequence.Count == 0)
            {
                throw new ArgumentNullException("Sequance must not be empty!");
            }

            Dictionary<int, int> elementCounter = new Dictionary<int, int>();
            int sequenceLength = sequence.Count;

            for (int i = 0; i < sequenceLength; i++)
            {
                if (elementCounter.ContainsKey(sequence[i]))
                {
                    elementCounter[sequence[i]]++;
                }
                else
                {
                    elementCounter.Add(sequence[i], 1);
                }
            }

            return elementCounter;
        }
    }
}
