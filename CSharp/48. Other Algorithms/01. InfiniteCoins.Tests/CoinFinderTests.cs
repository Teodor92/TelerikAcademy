namespace _01.InfiniteCoins.Tests
{
    using System.Collections.Generic;

    using _01.InfiniteCoins;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CoinFinderTests
    {
        [TestMethod]
        public void FindAllNeededCoins_HomeworkExample()
        {
            var myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            var expected = new List<int>() { 1, 2, 5, 5, 5, 5, 5, 5 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(33));
        }

        [TestMethod]
        public void FindAllNeededCoins_ExatFiveCoinMatch()
        {
            var myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            var expected = new List<int>() { 5, 5, 5 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(15));
        }

        [TestMethod]
        public void FindAllNeededCoins_SingleFiveCoinMatch()
        {
            var myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            var expected = new List<int>() { 5 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(5));
        }

        [TestMethod]
        public void FindAllNeededCoins_SingleTwoCoinMatch()
        {
            var myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            var expected = new List<int>() { 2 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(2));
        }

        [TestMethod]
        public void FindAllNeededCoins_SingleOneCoinMatch()
        {
            var myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            var expected = new List<int>() { 1 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(1));
        }

        [TestMethod]
        public void FindAllNeededCoins_EightTest()
        {
            var myFinder = new CoinFinder(new int[] { 5, 2, 1 });
            var expected = new List<int>() { 1, 2, 5 };

            CollectionAssert.AreEqual(expected, myFinder.FindAllNeededCoins(8));
        }
    }
}
