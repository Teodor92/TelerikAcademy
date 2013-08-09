namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                if (this.Items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            // TODO: Ensure sort
            int indexMax = this.Items.Count - 1;
            int indexMin = 0;
            while (indexMax >= indexMin)
            {
                int indexMidpoint = (indexMin + indexMax) / 2;
                if (this.Items[indexMidpoint].CompareTo(item) < 0)
                {
                    indexMin = indexMidpoint + 1;
                }
                else if (this.Items[indexMidpoint].CompareTo(item) > 0)
                {
                    indexMax = indexMidpoint - 1;
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            var itemsCount = this.Items.Count;
            for (var i = 0; i < itemsCount; i++)
            {
                int r = i + RandomProvider.Instance.Next(0, itemsCount - i);
                var temp = this.Items[i];
                this.Items[i] = this.Items[r];
                this.Items[r] = temp;
            }
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
