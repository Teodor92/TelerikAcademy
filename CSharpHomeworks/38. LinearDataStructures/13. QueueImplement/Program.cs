namespace QueueImplement
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            CustomQueue<int> test = new CustomQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                test.Enqueue(i);
            }

            int[] teter = test.ToArray();
            test.Clear();
            foreach (var item in teter)
            {
                Console.WriteLine(item);
            }
        }
    }
}
