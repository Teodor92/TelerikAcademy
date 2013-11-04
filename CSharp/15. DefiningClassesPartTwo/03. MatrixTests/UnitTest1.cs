namespace _03.MatrixTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IndexerTest()
        {
            try
            {
                Matrix<int> matrixTest = new Matrix<int>(2, 2);
                matrixTest[3, 3] = 0;
                Assert.Fail("Indexer Problem!");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Out of the matrix!", e.Message);
            }
        }

        [TestMethod]
        public void SumTest()
        {
            try
            {
                Matrix<int> matrixTest = new Matrix<int>(2, 2);
                Matrix<int> matrixTestTwo = new Matrix<int>(4, 4);
                Matrix<int> sumTest = matrixTest + matrixTestTwo;

                Assert.Fail("Sum Problem!");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Wrongs sizeses", e.Message);
            }
        }

        [TestMethod]
        public void SubTest()
        {
            try
            {
                Matrix<int> matrixTest = new Matrix<int>(2, 2);
                Matrix<int> matrixTestTwo = new Matrix<int>(4, 4);
                Matrix<int> sumTest = matrixTest - matrixTestTwo;

                Assert.Fail("Sub Problem!");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Wrongs sizeses", e.Message);
            }
        }

        [TestMethod]
        public void MultiTest()
        {
            try
            {
                Matrix<int> matrixTest = new Matrix<int>(10, 10);
                Matrix<int> matrixTestTwo = new Matrix<int>(2, 24);
                Matrix<int> sumTest = matrixTest * matrixTestTwo;

                Assert.Fail("Multi Problem!");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Wrong sizeses", e.Message);
            }
        }
    }
}
