namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            int collectionLength = collection.Count;

            for (int i = 0; i < collectionLength - 1; i++)
            {
                int minElementIndex = i;

                for (int j = i + 1; j < collectionLength; j++)
                {
                    if (collection[j].CompareTo(collection[minElementIndex]) < 0)
                    {
                        minElementIndex = j;
                    }
                }

                if (minElementIndex != i)
                {
                    T oldValue = collection[i];
                    collection[i] = collection[minElementIndex];
                    collection[minElementIndex] = oldValue;
                }
            }
        }
    }
}
