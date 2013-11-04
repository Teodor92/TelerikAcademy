namespace InfiniteCoins
{
    using System.Collections.Generic;

    public class CoinFinder
    {
        private int[] setOfCoins;

        private Stack<int> usedCoins;

        public CoinFinder(int[] setOfCoins)
        {
            this.setOfCoins = setOfCoins;
            usedCoins = new Stack<int>();
        }

        public Stack<int> FindAllNeededCoins(int targetValue)
        {
            usedCoins.Clear();

            int progressValue = 0;

            for (int i = 0; i < setOfCoins.Length; i++)
            {
                while (true)
                {
                    if (progressValue > targetValue)
                    {
                        progressValue -= setOfCoins[i];
                        usedCoins.Pop();

                        break;
                    }

                    if (progressValue == targetValue)
                    {
                        break;
                    }

                    progressValue += setOfCoins[i];
                    usedCoins.Push(setOfCoins[i]);
                }
            }

            return usedCoins;
        }
    }
}