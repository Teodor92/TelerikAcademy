namespace RemoveOddTimeNumbers.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ListUtilsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ListUtils_RemoveOddTimeNumbersInvalidNullInputTest()
        {
            ListUtils.RemoveOddTimeNumbers(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ListUtils_RemoveOddTimeNumbersInvalidEmptyInputTest()
        {
            ListUtils.RemoveOddTimeNumbers(new List<int>());
        }

        [TestMethod]
        public void ListUtils_RemoveOddTimeNumbersSimpleInputTest()
        {
            List<int> actual = ListUtils.RemoveOddTimeNumbers(new List<int>() { 1, 1, 1, 2, 3, 3, 6, 6 });
            List<int> expected = new List<int>() { 3, 3, 6, 6 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListUtils_RemoveOddTimeNumbersAllOddInputTest()
        {
            List<int> actual = ListUtils.RemoveOddTimeNumbers(new List<int>() { 1, 1, 1, 2 });
            List<int> expected = new List<int>();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
