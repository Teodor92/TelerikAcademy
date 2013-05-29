namespace RemoveAllNegativeNums
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class CollectionUtils
    {
        public static void PrintCollection(IEnumerable<int> collection)
        {
            if (collection == null || collection.Count() == 0)
            {
                throw new ArgumentNullException("Collection must not be empty!");
            }

            StringBuilder output = new StringBuilder();

            foreach (var element in collection)
            {
                output.AppendFormat("{0}, ", element);
            }

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.DarkRed;

            Console.WriteLine(output.ToString().Trim(' ', ','));

            Console.ResetColor();
        }
    }
}
