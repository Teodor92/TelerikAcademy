using System;
using System.Linq;

public class AlpabeticalOrder
{
    public static void Main()
    {
        string[] inWords = Console.ReadLine().Split();

        var sortedWords = inWords.OrderBy(x => x); //.ThenBy(x => x.Length);
        foreach (var item in sortedWords)
        {
            Console.Write("{0} ", item);
        }
    }
}
