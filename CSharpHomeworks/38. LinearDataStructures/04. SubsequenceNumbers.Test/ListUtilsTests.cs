namespace SubsequenceNumbers.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListUtils_GenerateSameElementSequenceInvalidNegativeCountTest()
        {
            ListUtils.GenerateSameElementSequence(2, -2);
        }

        [TestMethod]
        public void ListUtils_GenerateSameElementSequenceSimpleTestTest()
        {
            List<int> actual = ListUtils.GenerateSameElementSequence(2, 5);
            List<int> expected = new List<int>() { 2, 2, 2, 2, 2 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ListUtils_FindMaxSameElemetSubsequenceIvalidNullInputTest()
        {
            ListUtils.FindMaxSameElemetSubsequence(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ListUtils_FindMaxSameElemetSubsequenceIvalidEmptyInputTest()
        {
            ListUtils.FindMaxSameElemetSubsequence(new List<int>());
        }

        [TestMethod]
        public void ListUtils_FindMaxSameElemetSubsequenceSimpleInputTest()
        {
            List<int> actual = ListUtils.FindMaxSameElemetSubsequence(new List<int>() { 1, 2, 6, 3, 4, 2, 2, 2, 2, 2, 33, 1, 1 });
            List<int> expected = new List<int>() { 2, 2, 2, 2, 2 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListUtils_FindMaxSameElemetSubsequenceSequenceAtTheBeginingTest()
        {
            List<int> actual = ListUtils.FindMaxSameElemetSubsequence(new List<int>() { 2, 2, 2, 2, 2, 1, 2, 6, 3, 4, 33, 1, 1 });
            List<int> expected = new List<int>() { 2, 2, 2, 2, 2 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ListUtils_FindMaxSameElemetSubsequenceSequenceAtTheEndTest()
        {
            List<int> actual = ListUtils.FindMaxSameElemetSubsequence(new List<int>() { 1, 2, 6, 3, 4, 33, 1, 1, 2, 2, 2, 2, 2 });
            List<int> expected = new List<int>() { 2, 2, 2, 2, 2 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
