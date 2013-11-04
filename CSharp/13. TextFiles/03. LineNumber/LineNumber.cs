using System;
using System.IO;

public class LineNumber
{
    public static void Main()
    {
        StreamReader fileReader = new StreamReader(@"..\..\Ex.3\InOne.txt");
        StreamWriter fileWriter = new StreamWriter(@"..\..\Ex.3\OutResult.txt");

        using (fileReader)
        {
            string line = fileReader.ReadLine();
            int lineNumber = 0;
            while (line != null)
            {
                lineNumber++;
                fileWriter.WriteLine("Line {0} - {1}", lineNumber, line);

                line = fileReader.ReadLine();
            }

            fileWriter.Close();
        }
    }
}
