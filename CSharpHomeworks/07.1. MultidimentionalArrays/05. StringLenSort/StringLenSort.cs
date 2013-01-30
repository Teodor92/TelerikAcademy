using System;
using System.Linq;

public class StringLenSort
{
    public static void Main()
    {
        string[] unsortedStrings = { "a", "aaaaa", "aaaawasdawd", "a", "12355asdf", "wdasdwe" };

        // TODO Try with Linq !
        var sortedArray = unsortedStrings.OrderBy(uStrings => uStrings.Length);
        foreach (var item in sortedArray)
        {
            Console.WriteLine(item);
        }
    }
}
