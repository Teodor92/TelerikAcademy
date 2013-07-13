using System;
using System.Numerics;

public class CarWars
{
    public static void Main()
    {
        int numberOfMatches = int.Parse(Console.ReadLine());
        const int cardsPerGame = 3;
        BigInteger globalFirstPlayerScore = 0;
        BigInteger globalSecondPlayerScore = 0;
        int gamesWonByFirstPlayer = 0;
        int gamesWonBySecondPlayer = 0;
        bool xCardDrawnPlayerOne = false;
        bool xCardDrawnPlayerTwo = false;

        for (int i = 0; i < numberOfMatches; i++)
        {
            int currentMatchScorePlayerOne = 0;
            int currentMatchScorePlayerTwo = 0;

            for (int j = 0; j < cardsPerGame; j++)
            {
                string currentCard = Console.ReadLine();

                switch (currentCard)
                {
                    case "Z":
                        globalFirstPlayerScore = globalFirstPlayerScore * 2;
                        break;
                    case "Y":
                        globalFirstPlayerScore -= 200;
                        break;
                    case "X":
                        xCardDrawnPlayerOne = true;
                        break;
                    case "J": 
                        currentMatchScorePlayerOne += 11; 
                        break;
                    case "Q": 
                        currentMatchScorePlayerOne += 12; 
                        break;
                    case "K": 
                        currentMatchScorePlayerOne += 13; 
                        break;
                    case "A": 
                        currentMatchScorePlayerOne += 1; 
                        break;
                    default:
                        currentMatchScorePlayerOne += 12 - int.Parse(currentCard);
                        break;
                }
            }

            for (int j = 0; j < cardsPerGame; j++)
            {
                string currentCard = Console.ReadLine();

                switch (currentCard)
                {
                    case "Z":
                        globalSecondPlayerScore = globalSecondPlayerScore * 2;
                        break;
                    case "Y":
                        globalSecondPlayerScore -= 200;
                        break;
                    case "X":
                        xCardDrawnPlayerTwo = true;
                        break;
                    case "J":
                        currentMatchScorePlayerTwo += 11;
                        break;
                    case "Q":
                        currentMatchScorePlayerTwo += 12;
                        break;
                    case "K":
                        currentMatchScorePlayerTwo += 13;
                        break;
                    case "A":
                        currentMatchScorePlayerTwo += 1;
                        break;
                    default:
                        currentMatchScorePlayerTwo += 12 - int.Parse(currentCard);
                        break;
                }
            }

            if (xCardDrawnPlayerOne && xCardDrawnPlayerTwo)
            {
                globalFirstPlayerScore += 50;
                globalSecondPlayerScore += 50;

                xCardDrawnPlayerOne = false;
                xCardDrawnPlayerTwo = false;
                return;
            }
            else if (xCardDrawnPlayerOne)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
                return;
            }
            else if(xCardDrawnPlayerTwo)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
                return;
            }


            if (currentMatchScorePlayerOne > currentMatchScorePlayerTwo)
            {
                globalFirstPlayerScore += currentMatchScorePlayerOne;
                gamesWonByFirstPlayer++;
            }
            else if (currentMatchScorePlayerOne < currentMatchScorePlayerTwo)
            {
                globalSecondPlayerScore += currentMatchScorePlayerTwo;
                gamesWonBySecondPlayer++;
            }

            xCardDrawnPlayerOne = false;
            xCardDrawnPlayerTwo = false;
        }

        if (globalSecondPlayerScore == globalFirstPlayerScore)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", globalFirstPlayerScore);
        }
        else if (globalFirstPlayerScore > globalSecondPlayerScore)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", globalFirstPlayerScore);
            Console.WriteLine("Games won: {0}", gamesWonByFirstPlayer);
        }
        else
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", globalSecondPlayerScore);
            Console.WriteLine("Games won: {0}", gamesWonBySecondPlayer);
        }

    }
}