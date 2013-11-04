/* Modify the solution of the previous 
 * problem to replace only whole words (not substrings).
 */

using System;
using System.IO;
using System.Text;

public class WordReplace
{
    public static string[] WordReplacer(string[] allWordsInText, string[] specialChars)
    {
        try
        {
            for (int i = 0; i < allWordsInText.Length; i++)
            {
                string comparisonWord = allWordsInText[i];
                for (int j = 0; j < specialChars.Length; j++)
                {
                    comparisonWord = comparisonWord.Replace(specialChars[j], string.Empty);
                }

                if (comparisonWord == "start")
                {
                    allWordsInText[i] = allWordsInText[i].Replace(comparisonWord, "finish");
                }
            }

            return allWordsInText;
        }
        catch (Exception removerExp)
        {
            Console.WriteLine(removerExp.Message);
        }

        return null;
    }

    public static void Main()
    {
        StreamReader fileReader = new StreamReader(@"..\..\Ex.8\InOne.txt");
        StreamWriter fileWriter = new StreamWriter(@"..\..\Ex.8\OutResult.txt");
        string[] specialSigns = { ".", ",", "!", "?", "\"" };

        string allText = string.Empty;

        using (fileReader)
        {
            allText = fileReader.ReadToEnd();
        }

        string[] words = allText.Split(' ');

        words = WordReplacer(words, specialSigns);

        StringBuilder wholeText = new StringBuilder();
        for (int i = 0; i < words.Length; i++)
        {
            wholeText.AppendFormat("{0} ", words[i]);
        }

        using (fileWriter)
        {
            fileWriter.Write(wholeText.ToString());
        }
    }
}
