namespace HashSetImplement
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            CustomHashSet<int> firstSet = new CustomHashSet<int>();

            for (int i = 0; i < 20; i++)
            {
                firstSet.Add(i);
            }

            CustomHashSet<int> secondSet = new CustomHashSet<int>();

            for (int i = 10; i < 30; i++)
            {
                secondSet.Add(i);
            }

            CustomHashSet<int> resultUnion = firstSet.Intersect(secondSet);

            foreach (var item in resultUnion)
            {
                Console.WriteLine(item);
            }
        }
    }
}
