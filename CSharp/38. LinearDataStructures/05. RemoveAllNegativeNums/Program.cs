namespace RemoveAllNegativeNums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main()
        {
            List<int> sequence = new List<int>() { 1, 2, 33, -3, 3, 3, -3, 4, 5, -6, 2, 1, 1, -1, -1, -1, -1 };

            // Using lambda expressions
            var noneNegativeSequence = sequence.Where(x => x > 0);
            CollectionUtils.PrintCollection(noneNegativeSequence);

            // Using LINQ
            var noneNegativeList =
                from element in sequence
                where element > 0
                select element;
            CollectionUtils.PrintCollection(noneNegativeList);

            // Using good old Remove
            sequence = ListUtils.RemoveNegativeElements(sequence);

            ListUtils.PrintList(sequence);
        }
    }
}
