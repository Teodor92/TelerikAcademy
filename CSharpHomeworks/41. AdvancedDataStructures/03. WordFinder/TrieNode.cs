namespace WordFinder
{
    using System;

    public class TrieNode
    {
        private readonly TrieNode[] edges;
        private int words;
        private int prefixes;

        public TrieNode()
        {
            this.edges = new TrieNode[26];
            this.Words = 0;
            this.Prefixes = 0;
        }

        public int Words
        {
            get
            {
                return this.words;
            }

            set
            {
                this.words = value;
            }
        }

        public int Prefixes
        {
            get
            {
                return this.prefixes;
            }

            set
            {
                this.prefixes = value;
            }
        }

        public TrieNode AddWord(TrieNode node, string word)
        {
            return this.AddWord(node, word, 0);
        }

        public void AddOccuranceIfExists(TrieNode node, string word)
        {
            this.AddOccuranceIfExists(node, word, 0);
        }

        public int CountWords(TrieNode node, string word)
        {
            return this.CountWords(node, word, 0);
        }

        public int CountPrefix(TrieNode node, string word)
        {
            return this.CountPrefix(node, word, 0);
        }

        private void AddOccuranceIfExists(TrieNode node, string word, int indexInWord)
        {
            if (word.Length == indexInWord)
            {
                node.Words += 1;
            }
            else
            {
                int nextCharIndex = word[indexInWord] - 'a';
                indexInWord++;
                node.Prefixes += 1;

                if (node.edges[nextCharIndex] == null)
                {
                    return;
                }
                else
                {
                    this.AddOccuranceIfExists(node.edges[nextCharIndex], word, indexInWord);
                }
            }
        }

        private TrieNode AddWord(TrieNode node, string word, int indexInWord)
        {
            if (word.Length != indexInWord)
            {
                node.Prefixes += 1;

                int index = word[indexInWord] - 'a';
                indexInWord++;

                if (node.edges[index] == null)
                {
                    node.edges[index] = new TrieNode();
                }

                node.edges[index] = this.AddWord(node.edges[index], word, indexInWord);
            }

            return node;
        }

        private int CountWords(TrieNode node, string word, int indexInWord)
        {
            if (word.Length == indexInWord)
            {
                return node.words;
            }
            else
            {
                int nextCharIndex = word[indexInWord] - 'a';
                indexInWord++;

                if (node.edges[nextCharIndex] == null)
                {
                    return 0;
                }
                else
                {
                    return this.CountWords(node.edges[nextCharIndex], word, indexInWord);
                }
            }
        }

        private int CountPrefix(TrieNode node, string word, int indexInWord)
        {
            if (word.Length == indexInWord)
            {
                return node.prefixes;
            }
            else
            {
                int nextCharIndex = word[indexInWord] - 'a';
                indexInWord++;

                if (node.edges[nextCharIndex] == null)
                {
                    return 0;
                }
                else
                {
                    return this.CountPrefix(node.edges[nextCharIndex], word, indexInWord);
                }
            }
        }
    }
}