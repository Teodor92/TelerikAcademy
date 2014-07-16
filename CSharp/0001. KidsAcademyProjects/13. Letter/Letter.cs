namespace _13.Letter
{
    using System;

    public class Letter
    {
        internal static void Main()
        {
            var firstWord = Console.ReadLine();
            var secondWord = Console.ReadLine();
            var bestLetterCounter = 0;
            var bestLetter = 'a';
            var letterCounter = 0;

            for (int i = 0; i < firstWord.Length; i++)
            {
                for (int j = 0; j < secondWord.Length; j++)
                {
                    if (firstWord[i] == secondWord[j])
                    {
                        letterCounter++;
                    }
                }

                if (letterCounter == bestLetterCounter)
                {
                    if (bestLetter > firstWord[i])
                    {
                        bestLetter = firstWord[i];
                    }
                }
                else if (letterCounter > bestLetterCounter)
                {
                    bestLetterCounter = letterCounter;
                    bestLetter = firstWord[i];
                }

                letterCounter = 0;
            }

            if (bestLetterCounter == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(bestLetter);
            }
        }
    }
}
