namespace RemoveOddTimeNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            List<int> sequence = new List<int>() { 4, 2, 2, 5, 2, 3, 2, 3, 1, 5, 2 };

            ListUtils.PrintList(ListUtils.RemoveOddTimeNumbers(sequence));
        }
    }
}
