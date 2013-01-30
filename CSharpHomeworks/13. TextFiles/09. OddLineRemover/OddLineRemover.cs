using System;
using System.IO;
using System.Text;

public class OddLineRemover
{
    public static void Main()
    {
        StreamReader fileReader = new StreamReader(@"C:\Users\Teodor\Desktop\ExampleFiles\Ex.9\InAndOut.txt");

        StringBuilder newContent = new StringBuilder();
        using (fileReader)
        {
            string line = fileReader.ReadLine();
            int lineNumber = 0; 
            while (line != null)
            {
                lineNumber++;
                if (lineNumber % 2 == 0)
                {
                    newContent.AppendLine(line);
                }

                line = fileReader.ReadLine();
            }
        }

        StreamWriter fileWriter = new StreamWriter(@"..\..\Ex.9\InAndOut.txt");
        using (fileWriter)
        {
            fileWriter.Write(newContent.ToString());
        }
    }
}
