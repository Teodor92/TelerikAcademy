namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class BiDictionary<K1, K2, T>
    {
        private MultiDictionary<K1, T> firstInnerDictonary;
        private MultiDictionary<K2, T> secondInnerDictonary;
        private MultiDictionary<Tuple<K1, K2>, T> bothInnerDictonary;
        private int count;
        private bool duplicateValuesAllowed = false;

        public BiDictionary(bool allowDuplicateValues)
        {
            this.duplicateValuesAllowed = allowDuplicateValues;
            this.firstInnerDictonary = new MultiDictionary<K1, T>(allowDuplicateValues);
            this.secondInnerDictonary = new MultiDictionary<K2, T>(allowDuplicateValues);
            this.bothInnerDictonary = new MultiDictionary<Tuple<K1, K2>, T>(allowDuplicateValues);
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void AddByFirstKey(K1 firstKey, T value)
        {
            this.count++;
            this.firstInnerDictonary.Add(firstKey, value);
        }

        public void AddBySecondKey(K2 secondKey, T value)
        {
            this.count++;
            this.secondInnerDictonary.Add(secondKey, value);
        }

        public void AddByBothKeys(K1 firstKey, K2 secondKey, T value)
        {
            this.count++;
            this.bothInnerDictonary.Add(new Tuple<K1, K2>(firstKey, secondKey), value);
        }

        public bool ContainsFirstKey(K1 firstKey)
        {
            if (this.firstInnerDictonary.ContainsKey(firstKey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsSecondKey(K2 secondKey)
        {
            if (this.secondInnerDictonary.ContainsKey(secondKey))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ContainsBothKey(K1 firstKey, K2 secondKey)
        {
            if (this.bothInnerDictonary.ContainsKey(new Tuple<K1, K2>(firstKey, secondKey)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Clear()
        {
            this.count = 0;
            this.firstInnerDictonary = new MultiDictionary<K1, T>(this.duplicateValuesAllowed);
            this.secondInnerDictonary = new MultiDictionary<K2, T>(this.duplicateValuesAllowed);
            this.bothInnerDictonary = new MultiDictionary<Tuple<K1, K2>, T>(this.duplicateValuesAllowed);
        }

        public ICollection<T> FindByFirstKey(K1 firstKey)
        {
            return this.firstInnerDictonary[firstKey].ToArray();
        }

        public ICollection<T> FindBySecondKey(K2 secondKey)
        {
            return this.secondInnerDictonary[secondKey].ToArray();
        }

        public ICollection<T> FindByFirstAndSecondKey(K1 firstKey, K2 secondKey)
        {
            return this.bothInnerDictonary[new Tuple<K1, K2>(firstKey, secondKey)];
        }

        public void RemoveByFirstKey(K1 firstKey)
        {
            if (this.firstInnerDictonary.Remove(firstKey))
            {
                this.count--;
            }
        }

        public void RemoveBySecondKey(K2 secondKey)
        {
            if (this.secondInnerDictonary.Remove(secondKey))
            {
                this.count--;
            }
        }

        public void RemoveByBothKeys(K1 firstKey, K2 secondKey)
        {
            if (this.bothInnerDictonary.Remove(new Tuple<K1, K2>(firstKey, secondKey))) 
            {
                this.count--;
            }
        }
    }
}
