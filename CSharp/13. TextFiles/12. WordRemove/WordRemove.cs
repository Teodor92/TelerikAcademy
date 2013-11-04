using System;
using System.IO;
using System.Text;

public class WordRemove
{
    public static string[] ReadWordList()
    {
        try
        {
            StreamReader wordList = new StreamReader(@"..\..\Ex.12\Words.txt");
            string allWords = string.Empty;
            using (wordList)
            {
                allWords = wordList.ReadToEnd();
            }

            string[] words = allWords.Split();
            return words;
        }
        catch (Exception strReaderEx)
        {
            Console.Error.WriteLine(strReaderEx.Message);
        }

        return null;
    }

    public static string[] ReadAndSplitText()
    {
        try
        {
            StreamReader text = new StreamReader(@"..\..\Ex.12\Text.txt");
            string allText = string.Empty;

            using (text)
            {
                allText = text.ReadToEnd();
            }

            string[] wordsInText = allText.Split();
            return wordsInText;
        }
        catch (Exception strReaderEx)
        {
            Console.Error.WriteLine(strReaderEx.Message);
        }

        return null;
    }

    public static string[] WordRemover(string[] allWordsInText, string[] wordsToRemove, string[] specialChars)
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

                for (int k = 0; k < wordsToRemove.Length; k++)
                {
                    if (wordsToRemove[k] == comparisonWord)
                    {
                        allWordsInText[i] = allWordsInText[i].Replace(comparisonWord, string.Empty);
                    }
                }
            }

            return allWordsInText;
        }
        catch (Exception removerExp)
        {
            Console.Error.WriteLine(removerExp.Message);
        }

        return null;
    }

    public static void Main()
    {
        string[] specialSigns = { ".", ",", "!", "?", "\"" };
        string[] wordsList = ReadWordList();
        string[] wordsInText = ReadAndSplitText();

        wordsInText = WordRemover(wordsInText, wordsList, specialSigns);

        StringBuilder outText = new StringBuilder();
        for (int i = 0; i < wordsInText.Length; i++)
        {
            outText.AppendFormat("{0} ", wordsInText[i]);
        }

        Console.WriteLine(outText.ToString());
    }
}
