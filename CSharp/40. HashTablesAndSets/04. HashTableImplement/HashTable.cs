namespace HashTableImplement
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValuePair<TKey, TValue>>
    {
        // fields
        private LinkedList<KeyValuePair<TKey, TValue>>[] innerLinkArray;
        private int count;
        private int fullCells;

        // constructors
        public HashTable()
        {
            this.innerLinkArray = new LinkedList<KeyValuePair<TKey, TValue>>[16];
            this.count = 0;
            this.fullCells = 0;
        }

        // properties
        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public int FullCells
        {
            get
            {
                return this.fullCells;
            }
        }

        public List<TKey> Keys
        {
            get
            {
                List<TKey> keys = new List<TKey>();
                for (int i = 0; i < this.innerLinkArray.Length; i++)
                {
                    if (this.innerLinkArray[i] != null)
                    {
                        var next = this.innerLinkArray[i].First;
                        while (next != null)
                        {
                            keys.Add(next.Value.Key);
                            next = next.Next;
                        }
                    }
                }

                return keys;
            }
        }

        // indexer
        public TValue this[TKey key]
        {
            get
            {
                int index = Math.Abs(key.GetHashCode() % this.innerLinkArray.Length);

                if (this.innerLinkArray[index] == null)
                {
                    throw new ArgumentException("There is no element with this key");
                }

                return this.Find(key);
            }

            set
            {
                this.Add(key, value);
            }
        }

        // methods
        public void Add(TKey key, TValue value)
        {
            if (this.fullCells >= this.innerLinkArray.Length * 0.75)
            {
                this.ResizeInnerArray();
            }

            int index = Math.Abs(key.GetHashCode() % this.innerLinkArray.Length);

            if (this.innerLinkArray[index] == null)
            {
                this.fullCells += 1;
                this.innerLinkArray[index] = new LinkedList<KeyValuePair<TKey, TValue>>();
            }

            LinkedListNode<KeyValuePair<TKey, TValue>> next = this.innerLinkArray[index].First;
            while (next != null)
            {
                if (next.Value.Key.Equals(key))
                {
                    throw new ArgumentException("Key already exists.");
                }

                next = next.Next;
            }

            this.innerLinkArray[index].AddLast(new KeyValuePair<TKey, TValue>(key, value));
            this.count += 1;
        }

        public TValue Find(TKey key)
        {
            int index = Math.Abs(key.GetHashCode() % this.innerLinkArray.Length);

            if (this.innerLinkArray[index] == null)
            {
                throw new InvalidOperationException("No elements with such key.");
            }
            else
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> next = this.innerLinkArray[index].First;
                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        return next.Value.Value;
                    }

                    next = next.Next;
                }

                throw new InvalidOperationException("No elements with such key.");
            }
        }

        public bool Remove(TKey key)
        {
            int index = Math.Abs(key.GetHashCode() % this.innerLinkArray.Length);

            if (this.innerLinkArray[index] == null)
            {
                throw new ArgumentException("No elements with such key.");
            }
            else
            {
                LinkedListNode<KeyValuePair<TKey, TValue>> next = this.innerLinkArray[index].First;
                while (next != null)
                {
                    if (next.Value.Key.Equals(key))
                    {
                        this.innerLinkArray[index].Remove(next);
                        this.count -= 1;
                        return true;
                    }

                    next = next.Next;
                }

                if (this.innerLinkArray[index].First == null)
                {
                    this.fullCells -= 1;
                }

                return false;
            }
        }

        public void Clear()
        {
            this.innerLinkArray = new LinkedList<KeyValuePair<TKey, TValue>>[16];
            this.count = 0;
            this.fullCells = 0;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            for (int i = 0; i < this.innerLinkArray.Length; i++)
            {
                if (this.innerLinkArray[i] != null)
                {
                    var next = this.innerLinkArray[i].First;
                    while (next != null)
                    {
                        yield return next.Value;
                        next = next.Next;
                    }
                }
            }
        }

        private void ResizeInnerArray()
        {
            int newLength = this.innerLinkArray.Length * 2;
            LinkedList<KeyValuePair<TKey, TValue>>[] newArray = new LinkedList<KeyValuePair<TKey, TValue>>[newLength];

            for (int i = 0; i < this.innerLinkArray.Length; i++)
            {
                newArray[i] = this.innerLinkArray[i];
            }

            this.innerLinkArray = newArray;
        }
    }
}
