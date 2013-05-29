namespace WordsCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static Dictionary<string, int> CountElements(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("Path must not be empty!");
            }

            string input = string.Empty;

            using (StreamReader inputStream = new StreamReader(path))
            {
                input = inputStream.ReadToEnd();
            }

            string[] words = input.Split(new char[] { ' ', ',', '-', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, int> elementCounter = new Dictionary<string, int>();
            int wordsCount = words.Length;

            for (int i = 0; i < wordsCount; i++)
            {
                if (elementCounter.ContainsKey(words[i].ToLowerInvariant()))
                {
                    elementCounter[words[i].ToLowerInvariant()]++;
                }
                else
                {
                    elementCounter.Add(words[i].ToLowerInvariant(), 1);
                }
            }

            return elementCounter;
        }

        public static void PrintDictonary(IDictionary<string, int> myDictonary)
        {
            if (myDictonary == null || myDictonary.Count == 0)
            {
                throw new ArgumentNullException("Dictonary must not be empty!");
            }

            StringBuilder output = new StringBuilder();

            foreach (var element in myDictonary)
            {
                output.AppendFormat("Element: {0}, Times: {1} {2}", element.Key, element.Value, Environment.NewLine);
            }

            Console.WriteLine(output.ToString());
        }

        public static void Main()
        {
            Dictionary<string, int> wordsCount = CountElements(@"../../input.txt");

            PrintDictonary(wordsCount);
        }
    }
}
