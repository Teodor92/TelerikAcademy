namespace PriorityQueueImplement
{
    using System;
    using System.Collections.Generic;
    using Wintellect.PowerCollections;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private OrderedBag<T> bag;

        public PriorityQueue()
        {
            this.bag = new OrderedBag<T>();
        }

        public int Count
        {
            get
            {
                return this.bag.Count;
            }
        }

        public void Enqueue(T element)
        {
            this.bag.Add(element);
        }

        public T Dequeue()
        {
            var element = this.bag.GetFirst();
            this.bag.RemoveFirst();
            return element;
        }
    }
}
