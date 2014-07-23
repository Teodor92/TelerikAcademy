namespace _01.InfiniteCoins
{
    using System;

    /// <summary>
    /// You are given a set of infinite number of coins (1, 2 and 5) 
    /// and end value – N. Write an algorithm that gives the number 
    /// of coins needed so that the sum of the coins equals N. Example:
    /// N = 33 => 6 coins x 5 + 1 coin x 2 + 1 coin x 1
    /// </summary>
    public class Program
    {
        internal static void Main(string[] args)
        {
            int[] coins = { 5, 2, 1 };
            var findMaCoinz = new CoinFinder(coins);

            Console.WriteLine(string.Join(", ", findMaCoinz.FindAllNeededCoins(33)));
        }
    }
}
