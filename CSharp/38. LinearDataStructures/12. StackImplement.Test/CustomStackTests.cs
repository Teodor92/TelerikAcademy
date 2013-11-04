namespace StackImplement.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomStackTests
    {
        [TestMethod]
        public void CustomStack_StackPushTest()
        {
            CustomStack<int> myStack = new CustomStack<int>();

            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
            }

            int expected = 10;

            Assert.AreEqual(expected, myStack.Count);
        }

        [TestMethod]
        public void CustomStack_StackPopTest()
        {
            CustomStack<int> myStack = new CustomStack<int>();

            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
            }

            for (int i = 0; i < 5; i++)
            {
                myStack.Pop();
            }

            int expected = 5;

            Assert.AreEqual(expected, myStack.Count);
        }

        [TestMethod]
        public void CustomStack_AccurateStackPopTest()
        {
            CustomStack<int> myStack = new CustomStack<int>();
            List<int> actual = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
            }

            for (int i = 0; i < 5; i++)
            {
                actual.Add(myStack.Pop());
            }

            List<int> expected = new List<int>() { 9, 8, 7, 6, 5 };

            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CustomStack_InvalidEmptyStackPopTest()
        {
            CustomStack<int> myStack = new CustomStack<int>();

            myStack.Pop();
        }

        [TestMethod]
        public void CustomStack_CorrectElementPeekTest()
        {
            CustomStack<int> myStack = new CustomStack<int>();

            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
            }

            int actual = myStack.Peek();
            int expected = 9;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CustomStack_NoRemovePeekTest()
        {
            CustomStack<int> myStack = new CustomStack<int>();

            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
            }

            myStack.Peek();
            int expected = 10;

            Assert.AreEqual(expected, myStack.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CustomStack_InvalidEmptyStackPeekTest()
        {
            CustomStack<int> myStack = new CustomStack<int>();

            myStack.Peek();
        }

        [TestMethod]
        public void CustomStack_ContainsTrueTest()
        {
            CustomStack<int> myStack = new CustomStack<int>();

            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
            }

            Assert.IsTrue(myStack.Contains(6));
        }

        [TestMethod]
        public void CustomStack_ContainsFalseTest()
        {
            CustomStack<int> myStack = new CustomStack<int>();

            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
            }

            Assert.IsFalse(myStack.Contains(66));
        }

        [TestMethod]
        public void CustomStack_ToArrayTest()
        {
            CustomStack<int> myStack = new CustomStack<int>();

            for (int i = 0; i < 10; i++)
            {
                myStack.Push(i);
            }

            int[] actual = myStack.ToArray();
            int[] expected = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
