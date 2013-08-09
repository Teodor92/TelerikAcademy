namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        private IList<T> QuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int pivot = (collection.Count - 1) / 2;
            T pivotValue = collection[pivot];
            collection.RemoveAt(pivot);
            List<T> lesser = new List<T>();
            List<T> greater = new List<T>();
            foreach (T element in collection)
            {
                if (element.CompareTo(pivotValue) < 0)
                {
                    lesser.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }

            List<T> result = new List<T>();
            result.AddRange(this.QuickSort(lesser));
            result.Add(pivotValue);
            result.AddRange(this.QuickSort(greater));
            return result;
        }

        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null!");
            }

            if (collection.Count <= 1)
            {
                return;
            }

            var newCollection = this.QuickSort(collection);
            collection.Clear();

            for (int i = 0; i < newCollection.Count; i++)
            {
                collection.Add(newCollection[i]);
            }
        }
    }
}
