namespace CardWars
{
    using System;
    using System.Numerics;

    public class Player
    {
        public BigInteger GlobalScore = 0;
        public int LocalScore = 0;
        public bool XCardDrawn = false;
        public int GamesWon = 0;

        public void ProccessCard(string card)
        {
            switch (card)
            {
                case "J":
                    this.LocalScore += 11;
                    break;
                case "Q":
                    this.LocalScore += 12;
                    break;
                case "K":
                    this.LocalScore += 13;
                    break;
                case "A":
                    this.LocalScore += 1;
                    break;
                case "Z": 
                    this.GlobalScore *= 2; 
                    break;
                case "Y": 
                    this.GlobalScore -= 200; 
                    break;
                case "X": 
                    this.XCardDrawn = true; 
                    break;
                default:
                    this.LocalScore += 12 - int.Parse(card);
                    break;
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfAllGames = int.Parse(Console.ReadLine());
            const int CardsToPlayer = 3;

            Player playerOne = new Player();
            Player playerTwo = new Player();

            for (int i = 0; i < numberOfAllGames; i++)
            {
                playerOne.LocalScore = 0;
                playerTwo.LocalScore = 0;

                for (int j = 0; j < CardsToPlayer; j++)
                {
                    string currentCard = Console.ReadLine();

                    playerOne.ProccessCard(currentCard);
                }

                for (int j = 0; j < CardsToPlayer; j++)
                {
                    string currentCard = Console.ReadLine();

                    playerTwo.ProccessCard(currentCard);
                }

                if (playerOne.XCardDrawn && playerTwo.XCardDrawn)
                {
                    playerTwo.GlobalScore += 50;
                    playerOne.GlobalScore += 50;

                    playerOne.XCardDrawn = false;
                    playerTwo.XCardDrawn = false;
                }
                else if (playerOne.XCardDrawn)
                {
                    break;
                }
                else if (playerTwo.XCardDrawn)
                {
                    break;
                }

                if (playerOne.LocalScore > playerTwo.LocalScore)
                {
                    playerOne.GlobalScore += playerOne.LocalScore;
                    playerOne.GamesWon++;
                }
                else if (playerOne.LocalScore < playerTwo.LocalScore)
                {
                    playerTwo.GlobalScore += playerTwo.LocalScore;
                    playerTwo.GamesWon++;
                }
            }

            if (playerOne.XCardDrawn)
            {
                Console.WriteLine("X card drawn! Player one wins the match!");
            }
            else if (playerTwo.XCardDrawn)
            {
                Console.WriteLine("X card drawn! Player two wins the match!");
            }
            else if (playerOne.GlobalScore > playerTwo.GlobalScore)
            {
                Console.WriteLine("First player wins!");
                Console.WriteLine("Score: {0}", playerOne.GlobalScore);
                Console.WriteLine("Games won: {0}", playerOne.GamesWon);
            }
            else if (playerOne.GlobalScore < playerTwo.GlobalScore)
            {
                Console.WriteLine("Second player wins!");
                Console.WriteLine("Score: {0}", playerTwo.GlobalScore);
                Console.WriteLine("Games won: {0}", playerTwo.GamesWon);
            }
            else
            {
                Console.WriteLine("It's a tie!");
                Console.WriteLine("Score: {0}", playerOne.GlobalScore);
            }
        }
    }
}
