using System;
using System.Collections.Generic;
using System.IO;

public class DictonaryAndExplanation
{
    public static void Main()
    {
        // file input reader
        Dictionary<string, string> explanationDictonary = new Dictionary<string, string>();
        StreamReader reader = new StreamReader("C:\\Users\\Teodor\\Desktop\\New folder\\New Text Document.txt");
        using (reader)
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                string[] fragedLine = line.Split('-');

                // TODO fix '-' term problem
                explanationDictonary.Add(fragedLine[0].Trim().ToLower(), fragedLine[1].Trim());
                line = reader.ReadLine();
            }
        }

        // Testing
        ////foreach (var elm in ExplanationDictonary)
        ////{
        ////    Console.WriteLine("Term: {0} Explanation: {1}",elm.Key,elm.Value);
        ////}
        string term = Console.ReadLine().Trim().ToLower();
        if (explanationDictonary.ContainsKey(term))
        {
            Console.WriteLine(explanationDictonary[term]);
        }
        else
        {
            Console.WriteLine("No explanation");
        }
    }
}
