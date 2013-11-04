namespace SubsequenceNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> sequence = new List<int>() { 1, 2, 33, 3, 3, 3, 3, 4, 5, 6, 2, 1, 1, 1, 1, 1, 1 };

            Console.WriteLine("The best same element subsequence is:");
            ListUtils.PrintList(ListUtils.FindMaxSameElemetSubsequence(sequence));
        }
    }
}
