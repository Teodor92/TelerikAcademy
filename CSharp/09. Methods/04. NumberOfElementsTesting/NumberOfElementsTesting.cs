namespace _04.NumberOfElementsTesting
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class NumberOfElementsTesting
    {
        [TestMethod]
        public void FirstTest()
        {
            // Testing data
            int[] myTestArray = { 1, 1, 2, 3, 2, 1, 1 };

            // Method out
            int actual = NumberOfElements.NumberCounter(myTestArray, 1);
            int expected = 4;

            // Testing
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SecondTest()
        {
            // Testing data
            int[] myTestArray = { 1 };

            // Method out
            int actual = NumberOfElements.NumberCounter(myTestArray, 1);
            int expected = 1;

            // Testing
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ThirdTest()
        {
            // Testing data
            int[] myTestArray = { 1, 2, 3, 4, 5, 6, 7 };

            // Method out
            int actual = NumberOfElements.NumberCounter(myTestArray, 1);
            int expected = 1;

            // Testing
            Assert.AreEqual(expected, actual);
        }
    }
}
