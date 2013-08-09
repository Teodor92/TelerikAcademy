namespace PriorityQueueImplement
{
    using System;

    public class Program
    {
        public static void Main()
        {
            PriorityQueue<int> myQueue = new PriorityQueue<int>();
            Random randomGenerator = new Random();

            for (int i = 0; i < 10; i++)
            {
                myQueue.Enqueue(randomGenerator.Next(10, 300));
            }

            int queueLen = myQueue.Count;
            for (int i = 0; i < queueLen; i++)
            {
                Console.WriteLine(myQueue.Dequeue());
            }
        }
    }
}
