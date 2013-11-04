namespace _02.MaxSumUnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MaxSumUnitTests
    {
        [TestMethod]
        public void TestOne()
        {
            // check data
            int[,] matrix = 
        {
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 1 },
            { 1, 1, 1, 1, 2 }
        };
            var inTest = MaxSumArea.MaxSum(matrix);

            Assert.AreEqual(10, inTest);
        }

        [TestMethod]
        public void TestTwo()
        {
            // check data
            int[,] matrix = 
            {
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 2 }
            };
            var inTest = MaxSumArea.MaxSum(matrix);

            Assert.AreEqual(2, inTest);
        }
    }
}
