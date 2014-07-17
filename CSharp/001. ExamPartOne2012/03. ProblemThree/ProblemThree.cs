namespace _03.ProblemThree
{
    using System;
    using System.Collections.Generic;

    public class ProblemThree
    {
        internal static void Main()
        {
            // input
            var allCards = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "J":
                        allCards.Add(11);
                        break;
                    case "Q":
                        allCards.Add(12);
                        break;
                    case "K":
                        allCards.Add(13);
                        break;
                    case "A":
                        allCards.Add(14);
                        break;
                    default:
                        allCards.Add(int.Parse(input));
                        break;
                }
            }

            // helpers
            allCards.Sort();
            var equalsNum = 1;
            var numsOfPairs = 0;
            var numsOfTipples = 0;
            var numsOfFours = 0;

            for (int i = 0; i < allCards.Count - 1; i++)
            {
                if (allCards[i] == allCards[i + 1])
                {
                    equalsNum++;
                }
                else
                {
                    if (equalsNum == 2)
                    {
                        numsOfPairs++;
                    }
                    else if (equalsNum == 3)
                    {
                        numsOfTipples++;
                    }
                    else if (equalsNum == 4)
                    {
                        numsOfFours++;
                    }

                    equalsNum = 1;
                }
            }

            // last case
            if (equalsNum == 2)
            {
                numsOfPairs++;
            }
            else if (equalsNum == 3)
            {
                numsOfTipples++;
            }
            else if (equalsNum == 4)
            {
                numsOfFours++;
            }

            // straight checker
            bool isStraight = true;
            for (int i = 0; i < allCards.Count - 1; i++)
            {
                if (allCards[i] + 1 != allCards[i + 1])
                {
                    isStraight = false;
                }

                if (allCards[0] == 2 &&
                    allCards[1] == 3 &&
                    allCards[2] == 4 &&
                    allCards[3] == 5 &&
                    allCards[4] == 14)
                {
                    isStraight = true;
                }
            }

            // checks
            if (allCards[0] == allCards[1] &&
                allCards[1] == allCards[2] &&
                allCards[2] == allCards[3] &&
                allCards[3] == allCards[4])
            {
                Console.WriteLine("Impossible");
            }
            else if (numsOfFours == 1)
            {
                Console.WriteLine("Four of a Kind");
            }
            else if (numsOfPairs == 1 && numsOfTipples == 1)
            {
                Console.WriteLine("Full House");
            }
            else if (isStraight)
            {
                Console.WriteLine("Straight");
            }
            else if (numsOfTipples == 1)
            {
                Console.WriteLine("Three of a Kind");
            }
            else if (numsOfPairs == 2)
            {
                Console.WriteLine("Two Pairs");
            }
            else if (numsOfPairs == 1)
            {
                Console.WriteLine("One Pair");
            }
            else
            {
                Console.WriteLine("Nothing");
            }
        }
    }
}
