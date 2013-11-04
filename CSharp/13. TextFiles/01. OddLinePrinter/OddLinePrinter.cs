using System;
using System.IO;

public class OddLinePrinter
{
    public static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\InOne.txt");
        using (reader)
        {
            string line = reader.ReadLine();
            int lineNumber = 0;
            while (line != null)
            {
                lineNumber++;
                if (lineNumber % 2 != 0)
                {
                    Console.WriteLine("Line {0}: {1}", lineNumber, line);
                }

                line = reader.ReadLine();
            }
        }
    }
}
