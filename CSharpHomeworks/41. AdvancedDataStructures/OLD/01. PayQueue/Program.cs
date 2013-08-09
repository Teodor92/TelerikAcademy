namespace PayQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            PriorityQueue<Student> payQueue = new PriorityQueue<Student>();

            for (int i = 0; i < 5; i++)
            {
                payQueue.Enqueue(new Student("Student" + i, 12, true));
            }

            for (int i = 5; i < 10; i++)
            {
                payQueue.Enqueue(new Student("Student" + i, 12, false));
            }

            for (int i = 0; i < 5; i++)
            {
                payQueue.Enqueue(new Student("StudentVer2" + i, 12, true));
            }

            int payQueueLength = payQueue.Count;

            for (int i = 0; i < payQueueLength; i++)
            {
                Console.WriteLine(payQueue.Dequeue().ToString());
            }
        }
    }
}
