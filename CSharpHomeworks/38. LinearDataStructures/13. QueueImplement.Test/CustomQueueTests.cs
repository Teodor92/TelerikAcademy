namespace QueueImplement.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomQueueTests
    {
        [TestMethod]
        public void CustomQueue_EnqueueTest()
        {
            CustomQueue<int> myQueue = new CustomQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                myQueue.Enqueue(i);
            }

            int expected = 10;

            Assert.AreEqual(expected, myQueue.Count);
        }

        [TestMethod]
        public void CustomQueue_DequeueTest()
        {
            CustomQueue<int> myQueue = new CustomQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                myQueue.Enqueue(i);
            }

            for (int i = 0; i < 5; i++)
            {
                myQueue.Dequeue();
            }

            int expected = 5;

            Assert.AreEqual(expected, myQueue.Count);
        }

        [TestMethod]
        public void CustomQueue_AccurateDequeueTest()
        {
            CustomQueue<int> myQueue = new CustomQueue<int>();
            List<int> dequeuedElements = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                myQueue.Enqueue(i);
            }

            for (int i = 0; i < 5; i++)
            {
                dequeuedElements.Add(myQueue.Dequeue());
            }

            List<int> expected = new List<int>() { 0, 1, 2, 3, 4 };

            CollectionAssert.AreEqual(expected, dequeuedElements);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void CustomQueue_InvalidDequeueTest()
        {
            CustomQueue<int> myQueue = new CustomQueue<int>();

            myQueue.Dequeue();
        }

        [TestMethod]
        public void CustomQueue_ClearTest()
        {
            CustomQueue<int> myQueue = new CustomQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                myQueue.Enqueue(i);
            }

            myQueue.Clear();

            int expected = 0;

            Assert.AreEqual(expected, myQueue.Count);
        }

        [TestMethod]
        public void CustomQueue_ContainsTrueTest()
        {
            CustomQueue<int> myQueue = new CustomQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                myQueue.Enqueue(i);
            }

            Assert.IsTrue(myQueue.Contains(3));
        }

        [TestMethod]
        public void CustomQueue_ContainsFalseTest()
        {
            CustomQueue<int> myQueue = new CustomQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                myQueue.Enqueue(i);
            }

            Assert.IsFalse(myQueue.Contains(33));
        }

        [TestMethod]
        public void CustomQueue_ToArrayTest()
        {
            CustomQueue<int> myQueue = new CustomQueue<int>();

            for (int i = 0; i < 10; i++)
            {
                myQueue.Enqueue(i);
            }

            int[] actual = myQueue.ToArray();
            int[] expected = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
