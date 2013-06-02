namespace StackImplement
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main(string[] args)
        {
            CustomStack<int> myStack = new CustomStack<int>();
            List<int> actual = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
            }

            int[] copy = myStack.ToArray();
            for (int i = 0; i < copy.Length; i++)
            {
                Console.WriteLine(copy[i]);
            }
        }
    }
}