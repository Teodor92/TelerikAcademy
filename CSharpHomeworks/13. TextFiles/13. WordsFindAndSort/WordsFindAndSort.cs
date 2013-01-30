using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class WordsFindAndSort
{
    public static void Main()
    {
        StreamReader wordReader = new StreamReader(@"..\..\Ex.13\words.txt");
        StreamReader testReader = new StreamReader(@"..\..\Ex.13\test.txt");
        StreamWriter resultWriter = new StreamWriter(@"..\..\Ex.13\result.txt");

        Dictionary<string, int> words = new Dictionary<string, int>();
        string allWords = string.Empty;

        using (wordReader)
        {
            allWords = wordReader.ReadToEnd();
        }

        string[] strWords = allWords.Split();

        foreach (var item in strWords)
        {
            if (!words.ContainsKey(item))
            {
                words.Add(item, 0);
            }
        }

        using (testReader)
        {
            allWords = testReader.ReadToEnd();
        }

        string[] text = allWords.Split();

        foreach (var item in text)
        {
            if (words.ContainsKey(item))
            {
                words[item]++;
            }
        }

        var sortedDes = words.OrderByDescending(x => x.Value);

        using (resultWriter)
        {
            foreach (var item in sortedDes)
            {
                resultWriter.WriteLine("{0} {1}", item.Key, item.Value);
                Console.WriteLine("{0} {1}", item.Key, item.Value);
            }
        }
    }
}
