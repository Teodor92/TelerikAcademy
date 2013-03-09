namespace _02.GenericListImpTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        private GenericList<int> mainListTest = new GenericList<int>(6);

        [TestMethod]
        public void AddingTest()
        {
            this.mainListTest.AddElement(2);
            this.mainListTest.AddElement(123);
            this.mainListTest.AddElement(-333);
            this.mainListTest.AddElement(123333);
            this.mainListTest.AddElement(1);
            this.mainListTest.AddElement(0);

            Assert.AreEqual(6, this.mainListTest.Length());
        }

        [TestMethod]
        public void RemoveTest()
        {
            this.mainListTest.AddElement(2);
            this.mainListTest.AddElement(123);
            this.mainListTest.AddElement(-333);
            this.mainListTest.AddElement(123333);
            this.mainListTest.AddElement(1);
            this.mainListTest.AddElement(0);

            this.mainListTest.RemoveElemAtIndex(2);

            Assert.AreEqual(5, this.mainListTest.Length());
        }

        [TestMethod]
        public void MaxTest()
        {
            this.mainListTest.AddElement(2);
            this.mainListTest.AddElement(123);
            this.mainListTest.AddElement(-333);
            this.mainListTest.AddElement(123333);
            this.mainListTest.AddElement(1);
            this.mainListTest.AddElement(0);

            Assert.AreEqual(123333, this.mainListTest.Max());
        }

        [TestMethod]
        public void MinTest()
        {
            this.mainListTest.AddElement(2);
            this.mainListTest.AddElement(123);
            this.mainListTest.AddElement(-333);
            this.mainListTest.AddElement(123333);
            this.mainListTest.AddElement(1);
            this.mainListTest.AddElement(0);

            Assert.AreEqual(-333, this.mainListTest.Min());
        }

        [TestMethod]
        public void InsertTest()
        {
            this.mainListTest.AddElement(2);
            this.mainListTest.AddElement(123);
            this.mainListTest.AddElement(-333);
            this.mainListTest.AddElement(123333);
            this.mainListTest.AddElement(1);
            this.mainListTest.AddElement(0);

            this.mainListTest.InsertElemAtIndex(2, 2000000);

            Assert.AreEqual(2000000, this.mainListTest.Max());
        }

        [TestMethod]
        public void FindTest()
        {
            this.mainListTest.AddElement(2);
            this.mainListTest.AddElement(123);
            this.mainListTest.AddElement(-333);
            this.mainListTest.AddElement(123333);
            this.mainListTest.AddElement(1);
            this.mainListTest.AddElement(0);

            Assert.AreEqual(3, this.mainListTest.FindElemByValue(123333));
        }

        [TestMethod]
        public void ClearTest()
        {
            this.mainListTest.AddElement(2);
            this.mainListTest.AddElement(123);
            this.mainListTest.AddElement(-333);
            this.mainListTest.AddElement(123333);
            this.mainListTest.AddElement(1);
            this.mainListTest.AddElement(0);

            this.mainListTest.ClearList();

            Assert.AreEqual(1, this.mainListTest.Length());
        }
    }
}
