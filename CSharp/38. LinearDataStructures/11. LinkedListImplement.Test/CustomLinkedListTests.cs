namespace LinkedListImplement.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CustomLinkedListTests
    {
        [TestMethod]
        public void CustomLinkedList_AddFirstTest()
        {
            CustomLinkedList<int> myLink = new CustomLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                myLink.AddFirst(i);
            }

            int expected = 10;

            Assert.AreEqual(expected, myLink.Count);
        }

        [TestMethod]
        public void CustomLinkedList_AddLastTest()
        {
            CustomLinkedList<int> myLink = new CustomLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                myLink.AddLast(i);
            }

            int expected = 10;

            Assert.AreEqual(expected, myLink.Count);
        }

        [TestMethod]
        public void CustomLinkedList_RemoveFirstTest()
        {
            CustomLinkedList<int> myLink = new CustomLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                myLink.AddLast(i);
            }

            for (int i = 0; i < 5; i++)
            {
                myLink.RemoveFirst();
            }

            int expected = 5;

            Assert.AreEqual(expected, myLink.Count);
        }

        [TestMethod]
        public void CustomLinkedList_RemoveLastTest()
        {
            CustomLinkedList<int> myLink = new CustomLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                myLink.AddLast(i);
            }

            for (int i = 0; i < 5; i++)
            {
                myLink.RemoveLast();
            }

            int expected = 5;

            Assert.AreEqual(expected, myLink.Count);
        }

        [TestMethod]
        public void CustomLinkedList_ClearTest()
        {
            CustomLinkedList<int> myLink = new CustomLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                myLink.AddLast(i);
            }

            myLink.Clear();

            int expected = 0;

            Assert.AreEqual(expected, myLink.Count);
        }
    }
}
