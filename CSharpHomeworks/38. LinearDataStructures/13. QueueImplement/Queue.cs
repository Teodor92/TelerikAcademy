namespace QueueImplement
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class CustomQueue<T> : IEnumerable
    {
        // fields
        private LinkedList<T> innerLinkList;

        // constructors
        public CustomQueue()
        {
            this.innerLinkList = new LinkedList<T>();
        }

        // properties
        public int Count
        {
            get
            {
                return this.innerLinkList.Count;
            }
        }

        // methods
        public IEnumerator GetEnumerator()
        {
            return this.innerLinkList.GetEnumerator();
        }

        public void Enqueue(T element)
        {
            this.innerLinkList.AddLast(element);
        }

        public T Dequeue()
        {
            if (this.innerLinkList.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty!");
            }

            T dequeuedElement = this.innerLinkList.First.Value;
            this.innerLinkList.RemoveFirst();

            return dequeuedElement;
        }

        public T[] ToArray()
        { 
            T[] copiedArray = new T[this.Count];
            this.innerLinkList.CopyTo(copiedArray, 0);
            return copiedArray;
        }

        public bool Contains(T element)
        {
            return this.innerLinkList.Contains(element);
        }

        public void Clear()
        {
            this.innerLinkList.Clear();
        }
    }
}
