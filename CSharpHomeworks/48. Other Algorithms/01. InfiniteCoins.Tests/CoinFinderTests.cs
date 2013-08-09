namespace InfiniteCoins.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;

    [TestClass]
    public class CoinFinderTests
    {
        [TestMethod]
        public void FindAllNeededCoins_HomeworkExample()
        {
            CoinFinder myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            List<int> expected = new List<int>() { 1, 2, 5, 5, 5, 5, 5, 5 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(33));
        }

        [TestMethod]
        public void FindAllNeededCoins_ExatFiveCoinMatch()
        {
            CoinFinder myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            List<int> expected = new List<int>() { 5, 5, 5 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(15));
        }

        [TestMethod]
        public void FindAllNeededCoins_SingleFiveCoinMatch()
        {
            CoinFinder myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            List<int> expected = new List<int>() { 5 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(5));
        }

        [TestMethod]
        public void FindAllNeededCoins_SingleTwoCoinMatch()
        {
            CoinFinder myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            List<int> expected = new List<int>() { 2 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(2));
        }

        [TestMethod]
        public void FindAllNeededCoins_SingleOneCoinMatch()
        {
            CoinFinder myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            List<int> expected = new List<int>() { 1 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(1));
        }

        [TestMethod]
        public void FindAllNeededCoins_EightTest()
        {
            CoinFinder myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            List<int> expected = new List<int>() { 1, 2, 5 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(8));
        }
    }
}
