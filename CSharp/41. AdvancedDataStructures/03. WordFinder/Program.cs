namespace WordFinder
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class WordOccurance
    {
        private static readonly Stopwatch stopwatchTest = new Stopwatch();

        public static void Main()
        {
            TrieNode start = new TrieNode();
            Dictionary<string, int> wordsInDictionary = new Dictionary<string, int>();

            string inputText = string.Empty;
            StreamReader inputReader = new StreamReader(@"..\..\text.txt");
            using (inputReader)
            {
                inputText = inputReader.ReadToEnd().ToLower();
            }

            // Regex is a bit slow but its easy to implement.
            var allWords = Regex.Matches(inputText, @"[a-zA-Z]+");
            
            List<string> searchedWords = new List<string>();

            // change number to increase searched words count
            for (int i = 0; i < 50; i++)
            {
                searchedWords.Add(allWords[i].ToString());
            }

            AddWordsForSearchInDictionary(searchedWords, wordsInDictionary);
            AddWordsForSearchInTrie(start, searchedWords);

            IncrementOccuranceCountTrie(start, allWords);
            IncrementOccuranceCountDictionary(wordsInDictionary, allWords);

            Console.WriteLine("Searched words count trie: ");
            foreach (var word in searchedWords)
            {
                Console.WriteLine("{0}: {1}", word, start.CountWords(start, word));
            }

            Console.WriteLine("Searched words count dictionary: ");
            foreach (var item in wordsInDictionary)
            {
                Console.WriteLine("{0}: {1}", item.Key, item.Value);
            }
        }

        private static void IncrementOccuranceCountTrie(TrieNode start, MatchCollection allWords)
        {
            stopwatchTest.Restart();
            foreach (var word in allWords)
            {
                start.AddOccuranceIfExists(start, word.ToString());
            }

            stopwatchTest.Stop();
            Console.WriteLine("Adding searched words count trie for: {0}", stopwatchTest.Elapsed);
        }

        private static void IncrementOccuranceCountDictionary(Dictionary<string, int> wordsInDictionary, MatchCollection allWords)
        {
            stopwatchTest.Restart();
            foreach (var word in allWords)
            {
                string wordStr = word.ToString();
                if (wordsInDictionary.ContainsKey(wordStr))
                {
                    wordsInDictionary[wordStr] += 1;
                }
            }

            stopwatchTest.Stop();

            Console.WriteLine("Adding searched words count dictionary for: {0}", stopwatchTest.Elapsed);
        }

        private static void AddWordsForSearchInTrie(TrieNode start, List<string> words)
        {
            stopwatchTest.Start();
            foreach (var item in words)
            {
                start.AddWord(start, item.ToString());
            }

            stopwatchTest.Stop();
            Console.WriteLine("Time to populate the trie: {0}", stopwatchTest.Elapsed);
        }

        private static void AddWordsForSearchInDictionary(List<string> words, Dictionary<string, int> wordsInDictionary)
        {
            stopwatchTest.Restart();
            foreach (var item in words)
            {
                string word = item.ToString();
                if (!wordsInDictionary.ContainsKey(word))
                {
                    wordsInDictionary[word] = 0;
                }
            }

            stopwatchTest.Stop();
            Console.WriteLine("Time to populate dictionary: {0}", stopwatchTest.Elapsed);
        }
    }
}