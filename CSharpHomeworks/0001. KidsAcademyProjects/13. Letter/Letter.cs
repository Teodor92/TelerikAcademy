using System;

class Letter
{
    static void Main()
    {
        string firstWord = Console.ReadLine();
        string secondWord = Console.ReadLine();
        int bestLetterCounter = 0;
        char bestLetter = 'a';
        int letterCounter = 0;
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
