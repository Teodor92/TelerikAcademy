namespace RemoveAllNegativeNums.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListUtilsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ListUtils_RemoveNegativeElementsInvalidNullInputTest()
        {
            ListUtils.RemoveNegativeElements(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ListUtils_RemoveNegativeElementsInvalidEmptyInputTest()
        {
            ListUtils.RemoveNegativeElements(new List<int>());
        }

        [TestMethod]
        public void ListUtils_RemoveNegativeElementsSimpleInputTest()
        {
            List<int> actual = ListUtils.RemoveNegativeElements(new List<int>() { 1, 2, 3, -12, 3, -12 });
            List<int> expected = new List<int>() { 1, 2, 3, 3 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListUtils_RemoveNegativeElementsAllNegativeInputTest()
        {
            List<int> actual = ListUtils.RemoveNegativeElements(new List<int>() { -1, -2, -3, -12, -3, -12 });
            List<int> expected = new List<int>();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
