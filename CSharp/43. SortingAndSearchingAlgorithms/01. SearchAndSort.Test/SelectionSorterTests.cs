using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SortingHomework;

namespace _01.SearchAndSort.Test
{
    [TestClass]
    public class SelectionSorterTests
    {
        [TestMethod]
        public void SimpleQuickSortTest()
        {
            List<int> arrayToSort = new List<int>() { 2, 5, 3, 1, 4 };
            SelectionSorter<int> selectionSorter = new SelectionSorter<int>();

            List<int> expectedArray = new List<int>() { 1, 2, 3, 4, 5 };

            selectionSorter.Sort(arrayToSort);

            CollectionAssert.AreEqual(expectedArray, arrayToSort);
        }

        [TestMethod]
        public void ReversedNumberSortTest()
        {
            List<int> arrayToSort = new List<int>() { 5, 4, 3, 2, 1 };
            SelectionSorter<int> quickSorter = new SelectionSorter<int>();

            List<int> selectionSorter = new List<int>() { 1, 2, 3, 4, 5 };

            quickSorter.Sort(arrayToSort);

            CollectionAssert.AreEqual(selectionSorter, arrayToSort);
        }

        [TestMethod]
        public void AlreadySortedNumsTest()
        {
            List<int> quickSorter = new List<int>() { 1, 2, 3, 4, 5 };
            SelectionSorter<int> selectionSorter = new SelectionSorter<int>();

            List<int> expectedArray = new List<int>() { 1, 2, 3, 4, 5 };

            selectionSorter.Sort(quickSorter);

            CollectionAssert.AreEqual(expectedArray, quickSorter);
        }
    }
}
