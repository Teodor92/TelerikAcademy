namespace SearchAndSort.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SortingHomework;
    using System.Collections.Generic;

    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void SimpleMergeSortTest()
        {
            List<int> arrayToSort = new List<int>() { 2, 5, 3, 1, 4 };
            MergeSorter<int> mergeSorter = new MergeSorter<int>();

            List<int> expectedArray = new List<int>() { 1, 2, 3, 4, 5 };

            mergeSorter.Sort(arrayToSort);

            CollectionAssert.AreEqual(expectedArray, arrayToSort);
        }

        [TestMethod]
        public void ReversedNumberSortTest()
        {
            List<int> arrayToSort = new List<int>() { 5, 4, 3, 2, 1 };
            MergeSorter<int> mergeSorter = new MergeSorter<int>();

            List<int> expectedArray = new List<int>() { 1, 2, 3, 4, 5 };

            mergeSorter.Sort(arrayToSort);

            CollectionAssert.AreEqual(expectedArray, arrayToSort);
        }

        [TestMethod]
        public void AlreadySortedNumsTest()
        {
            List<int> arrayToSort = new List<int>() { 1, 2, 3, 4, 5 };
            MergeSorter<int> mergeSorter = new MergeSorter<int>();

            List<int> expectedArray = new List<int>() { 1, 2, 3, 4, 5 };

            mergeSorter.Sort(arrayToSort);

            CollectionAssert.AreEqual(expectedArray, arrayToSort);
        }
    }
}
