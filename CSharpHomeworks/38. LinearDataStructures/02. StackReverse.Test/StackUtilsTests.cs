namespace StackReverse.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StackUtilsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StackUtils_ReverseNumbersInvalidNullInput()
        {
            StackUtils.ReverseNumbers(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StackUtils_ReverseNumbersInvalidEmptyInput()
        {
            StackUtils.ReverseNumbers(new Stack<int>());
        }

        [TestMethod]
        public void StackUtils_ReverseNumbersSimpleInput()
        {
            Stack<int> myTestStack = new Stack<int>();

            for (int i = 0; i < 5; i++)
            {
                myTestStack.Push(i);
            }

            string actual = StackUtils.ReverseNumbers(myTestStack);
            string exptected = "4, 3, 2, 1, 0";

            Assert.AreEqual(exptected, actual);
        }

        [TestMethod]
        public void StackUtils_ReverseNumbersReversedInput()
        {
            Stack<int> myTestStack = new Stack<int>();

            for (int i = 5 - 1; i >= 0; i--)
            {
                myTestStack.Push(i);
            }

            string actual = StackUtils.ReverseNumbers(myTestStack);
            string exptected = "0, 1, 2, 3, 4";

            Assert.AreEqual(exptected, actual);
        }
    }
}
