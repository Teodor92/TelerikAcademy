namespace SortingAlgos
{
    using System.Collections.Generic;

    public class Sorter
    {
        public List<int> SelectionSort(List<int> unsortedList)
        {
            for (int i = 0; i < unsortedList.Count - 1; i++)
            {
                int minimalElementIndex = i;

                for (int j = i + 1; j < unsortedList.Count; j++)
                {
                    if (unsortedList[j] < unsortedList[minimalElementIndex])
                    {
                        minimalElementIndex = j;
                    }
                }

                if (minimalElementIndex != i)
                {
                    int oldValue = 0;
                    oldValue = unsortedList[i];
                    unsortedList[i] = unsortedList[minimalElementIndex];
                    unsortedList[minimalElementIndex] = oldValue;
                }
            }

            return unsortedList;
        }

        public List<double> SelectionSort(List<double> unsortedList)
        {
            for (int i = 0; i < unsortedList.Count - 1; i++)
            {
                int minimalElementIndex = i;

                for (int j = i + 1; j < unsortedList.Count; j++)
                {
                    if (unsortedList[j] < unsortedList[minimalElementIndex])
                    {
                        minimalElementIndex = j;
                    }
                }

                if (minimalElementIndex != i)
                {
                    double oldValue = 0;
                    oldValue = unsortedList[i];
                    unsortedList[i] = unsortedList[minimalElementIndex];
                    unsortedList[minimalElementIndex] = oldValue;
                }
            }

            return unsortedList;
        }

        public List<string> SelectionSort(List<string> unsortedList)
        {
            for (int i = 0; i < unsortedList.Count - 1; i++)
            {
                int minimalElementIndex = i;

                for (int j = i + 1; j < unsortedList.Count; j++)
                {
                    if (string.Compare(unsortedList[j], unsortedList[minimalElementIndex]) == 1)
                    {
                        minimalElementIndex = j;
                    }
                }

                if (minimalElementIndex != i)
                {
                    string oldValue = string.Empty;
                    oldValue = unsortedList[i];
                    unsortedList[i] = unsortedList[minimalElementIndex];
                    unsortedList[minimalElementIndex] = oldValue;
                }
            }

            return unsortedList;
        }

        public List<string> QuickSort(List<string> unsortedList)
        {
            if (unsortedList.Count <= 1)
            {
                return unsortedList;
            }

            int pivot = unsortedList.Count / 2;
            string pivotValue = unsortedList[pivot];
            unsortedList.RemoveAt(pivot);
            List<string> lesser = new List<string>();
            List<string> greater = new List<string>();

            foreach (string element in unsortedList)
            {
                if (string.Compare(element, pivotValue) < 0)
                {
                    lesser.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }

            List<string> result = new List<string>();
            result.AddRange(QuickSort(lesser));
            result.Add(pivotValue);
            result.AddRange(QuickSort(greater));
            return result;
        }

        public List<int> QuickSort(List<int> unsortedList)
        {
            if (unsortedList.Count <= 1)
            {
                return unsortedList;
            }

            int pivot = unsortedList.Count / 2;
            int pivotValue = unsortedList[pivot];
            unsortedList.RemoveAt(pivot);
            List<int> lesser = new List<int>();
            List<int> greater = new List<int>();

            foreach (int element in unsortedList)
            {
                if (element < pivotValue)
                {
                    lesser.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }

            List<int> result = new List<int>();
            result.AddRange(QuickSort(lesser));
            result.Add(pivotValue);
            result.AddRange(QuickSort(greater));
            return result;
        }

        public List<double> QuickSort(List<double> unsortedList)
        {
            if (unsortedList.Count <= 1)
            {
                return unsortedList;
            }

            int pivot = unsortedList.Count / 2;
            double pivotValue = unsortedList[pivot];
            unsortedList.RemoveAt(pivot);
            List<double> lesser = new List<double>();
            List<double> greater = new List<double>();

            foreach (double element in unsortedList)
            {
                if (element < pivotValue)
                {
                    lesser.Add(element);
                }
                else
                {
                    greater.Add(element);
                }
            }

            List<double> result = new List<double>();
            result.AddRange(QuickSort(lesser));
            result.Add(pivotValue);
            result.AddRange(QuickSort(greater));
            return result;
        }

        public List<int> InsertionSort(List<int> unsortedList)
        {
            int arraySize = unsortedList.Count;
            int oldValue = 0;
            int holePos = 0;

            for (int i = 1; i < arraySize; i++)
            {
                oldValue = unsortedList[i];
                holePos = i - 1;
                while (holePos >= 0 && unsortedList[holePos] > oldValue)
                {
                    unsortedList[holePos + 1] = unsortedList[holePos];
                    holePos--;
                }

                unsortedList[holePos + 1] = oldValue;
            }

            return unsortedList;
        }

        public List<double> InsertionSort(List<double> unsortedList)
        {
            int arraySize = unsortedList.Count;
            double oldValue = 0;
            int holePos = 0;

            for (int i = 1; i < arraySize; i++)
            {
                oldValue = unsortedList[i];
                holePos = i - 1;
                while (holePos >= 0 && unsortedList[holePos] > oldValue)
                {
                    unsortedList[holePos + 1] = unsortedList[holePos];
                    holePos--;
                }

                unsortedList[holePos + 1] = oldValue;
            }

            return unsortedList;
        }

        public List<string> InsertionSort(List<string> unsortedList)
        {
            int arraySize = unsortedList.Count;
            string oldValue = string.Empty;
            int holePos = 0;

            for (int i = 1; i < arraySize; i++)
            {
                oldValue = unsortedList[i];
                holePos = i - 1;
                while (holePos >= 0 && string.Compare(unsortedList[holePos], oldValue) < 0)
                {
                    unsortedList[holePos + 1] = unsortedList[holePos];
                    holePos--;
                }

                unsortedList[holePos + 1] = oldValue;
            }

            return unsortedList;
        }
    }
}
