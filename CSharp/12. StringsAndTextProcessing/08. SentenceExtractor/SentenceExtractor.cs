using System;
using System.Text.RegularExpressions;

class SentenceExtractor
{
    static void Main()
    {
        char[] splitChars = { '.' };
        string[] textSentences = Console.ReadLine().Split(splitChars, StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < textSentences.Length; i++)
        {
            MatchCollection inWord = Regex.Matches(textSentences[i], @"\bin\b");
            if (inWord.Count != 0)
            {
                Console.WriteLine(textSentences[i].Trim() + '.');
            }
        }
    }
}
