namespace SequenceSumAndAverage.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SequenceSumAndAverage;

    [TestClass]
    public class FindAverageTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MathUtils_FindAverageInvalidNullInput()
        {
            MathUtils.FindAverage(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MathUtils_FindAverageInvalidEmptyInput()
        {
            MathUtils.FindAverage(new List<int>());
        }

        [TestMethod]
        public void MathUtils_SimpleInput()
        {
            decimal actual = MathUtils.FindAverage(new List<int>() { 1, 2, 3, 6 });
            decimal expected = 3m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void MathUtils_DeciamlResultInput()
        {
            decimal actual = MathUtils.FindAverage(new List<int>() { 1, 2, 3, 6, 1 });
            decimal expected = 2.6m;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MathUtils_FindSumInvalidNullInput()
        {
            MathUtils.FindSum(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void MathUtils_FindSumInvalidEmptyInput()
        {
            MathUtils.FindSum(new List<int>());
        }

        [TestMethod]
        public void MathUtils_SimpleResultInput()
        {
            decimal actual = MathUtils.FindSum(new List<int>() { 1, 2, 3, 6, 1 });
            decimal expected = 13m;

            Assert.AreEqual(expected, actual);
        }
    }
}
