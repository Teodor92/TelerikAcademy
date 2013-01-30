/* Write a program that replaces all occurrences of 
 * the substring "start" with the substring "finish"
 * in a text file. Ensure it will work with large files (e.g. 100 MB).
 */
using System;
using System.IO;

public class StringReplace
{
    public static void Main()
    {
        StreamReader fileReader = new StreamReader(@"..\..\Ex.7\InOne.txt");
        StreamWriter fileWriter = new StreamWriter(@"..\..\Ex.7\OutResult.txt");

        string allText = string.Empty;

        using (fileReader)
        {
            allText = fileReader.ReadToEnd();
        }

        allText = allText.Replace("start", "finish");

        using (fileWriter)
        {
            fileWriter.Write(allText);
        }
    }
}
