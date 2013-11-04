namespace PriorityQueueWithBinaryHeap
{
    using System;
    using Wintellect.PowerCollections;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private BinaryHeap<T> heap;

        public PriorityQueue()
        {
            this.heap = new BinaryHeap<T>();
        }

        public int Count
        {
            get
            {
                return this.heap.Count;
            }
        }

        public void Enqueue(T element)
        {
            this.heap.Add(element);
        }

        public T Dequeue()
        {
            var element = this.heap.Remove();
            return element;
        }
    }
}