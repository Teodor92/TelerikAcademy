namespace _01.InfiniteCoins
{
    using System.Collections.Generic;

    public class CoinFinder
    {
        private readonly int[] setOfCoins;
        private readonly Stack<int> usedCoins;

        public CoinFinder(int[] setOfCoins)
        {
            this.setOfCoins = setOfCoins;
            this.usedCoins = new Stack<int>();
        }

        public Stack<int> FindAllNeededCoins(int targetValue)
        {
            this.usedCoins.Clear();

            int progressValue = 0;

            for (int i = 0; i < this.setOfCoins.Length; i++)
            {
                while (true)
                {
                    if (progressValue > targetValue)
                    {
                        progressValue -= this.setOfCoins[i];
                        this.usedCoins.Pop();

                        break;
                    }

                    if (progressValue == targetValue)
                    {
                        break;
                    }

                    progressValue += this.setOfCoins[i];
                    this.usedCoins.Push(this.setOfCoins[i]);
                }
            }

            return this.usedCoins;
        }
    }
}