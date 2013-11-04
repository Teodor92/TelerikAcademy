namespace HashSetImplement
{
    /* 
     * Implement the data structure "set" in a class HashedSet<T> 
     * using your class HashTable<K,T> to hold the elements. 
     * Implement all standard set operations like Add(T), Find(T), 
     * Remove(T), Count, Clear(), union and intersect. 
     */

    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using HashTableImplement;

    public class CustomHashSet<T> : IEnumerable
    {
        // fields
        private HashTable<T, int> innerTable;

        // constructors
        public CustomHashSet()
        {
            this.innerTable = new HashTable<T, int>();
        }

        // properties
        public int Count
        {
            get
            {
                return this.innerTable.Count;
            }
        }

        public IEnumerable<T> Items
        {
            get
            {
                return this.innerTable.Keys;
            }
        }

        // methods
        public IEnumerator GetEnumerator()
        {
            foreach (var item in this.innerTable)
            {
                yield return item.Value;
            }
        }

        public void Add(T value)
        {
            this.innerTable.Add(value, value.GetHashCode());
        }

        public bool Contains(T value)
        {
            this.innerTable.Find(value);

            return true;
        }

        public bool Remove(T value)
        {
            return this.innerTable.Remove(value);
        }

        public void Clear()
        {
            this.innerTable.Clear();
        }

        public CustomHashSet<T> Union(CustomHashSet<T> otherSet)
        {
            IEnumerable<T> union = this.Items.Union(otherSet.Items);
            CustomHashSet<T> newSet = new CustomHashSet<T>();

            foreach (var item in union)
            {
                newSet.Add(item);
            }

            return newSet;
        }

        public CustomHashSet<T> Intersect(CustomHashSet<T> otherSet)
        {
            IEnumerable<T> intersect = this.Items.Intersect(otherSet.Items);
            CustomHashSet<T> newSet = new CustomHashSet<T>();

            foreach (var item in intersect)
            {
                newSet.Add(item);
            }

            return newSet;
        }
    }
}
