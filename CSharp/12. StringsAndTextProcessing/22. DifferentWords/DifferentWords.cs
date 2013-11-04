using System;
using System.Collections.Generic;

public class DifferentWords
{
    public static void Main()
    {
        string[] specialSigns = { " ", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "-", "_", "+" };

        string input = Console.ReadLine();
        string[] words = input.Split();

        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < specialSigns.Length; j++)
            {
                words[i] = words[i].Replace(specialSigns[j], string.Empty);
            }
        }

        Dictionary<string, int> allWords = new Dictionary<string, int>();

        for (int i = 0; i < words.Length; i++)
        {
            if (allWords.ContainsKey(words[i]))
            {
                allWords[words[i]]++;
            }
            else
            {
                allWords.Add(words[i], 1);
            }
        }

        foreach (var item in allWords)
        {
            Console.WriteLine("Letter --> {0} - Number --> {1}", item.Key, item.Value);
        }
    }
}
