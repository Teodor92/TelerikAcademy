using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortingHomework;

namespace _01.SearchAndSort.Test
{
    [TestClass]
    public class SortableCollectionTest
    {
        [TestMethod]
        public void LinerSearchItemFound()
        {
            var searchCollection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 122, 22, 33, 11, 3445667, 1233, 123, 101 });

            Assert.IsTrue(searchCollection.LinearSearch(11));
        }

        [TestMethod]
        public void LinerSearchItemNotFound()
        {
            var searchCollection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 122, 22, 33, 11, 3445667, 1233, 123, 101 });

            Assert.IsFalse(searchCollection.LinearSearch(66));
        }

        [TestMethod]
        public void BinarySearchItemFound()
        {
            var searchCollection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 122, 22, 33, 11, 3445667, 1233, 123, 101 });

            searchCollection.Sort(new Quicksorter<int>()); 

            Assert.IsTrue(searchCollection.BinarySearch(11));
        }

        [TestMethod]
        public void BinarySearchItemNotFound()
        {
            var searchCollection = new SortableCollection<int>(new[] { 22, 11, 101, 33, 0, 122, 22, 33, 11, 3445667, 1233, 123, 101 });

            searchCollection.Sort(new SelectionSorter<int>()); 

            Assert.IsFalse(searchCollection.BinarySearch(66));
        }


    }
}
