namespace PriorityQueueWithBinaryHeap
{
    /* 
     * Implement a class PriorityQueue<T> based on the data structure "binary heap". 
     */

    using System;

    public class Program
    {
        public static void Main()
        {
            Random randomGen = new Random();
            PriorityQueue<int> myQueue = new PriorityQueue<int>();

            for (int i = 0; i < 50; i++)
            {
                myQueue.Enqueue(randomGen.Next(1, 100));
            }

            for (int i = 0; i < 50; i++)
            {
                Console.WriteLine(myQueue.Dequeue());
            }
        }
    }
}
