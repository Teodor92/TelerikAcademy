namespace LinkedListImplement
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            LinkedList<int> test = new LinkedList<int>();

            CustomLinkedList<int> myLink = new CustomLinkedList<int>();
            myLink.AddFirst(2);
            myLink.RemoveFirst();

            for (int i = 0; i < 10; i++)
            {
                myLink.AddFirst(i);
            }

            myLink.AddLast(123);
            myLink.RemoveFirst();
            myLink.RemoveFirst();

            Console.WriteLine(myLink.Count);

            Console.WriteLine();
        }
    }
}
