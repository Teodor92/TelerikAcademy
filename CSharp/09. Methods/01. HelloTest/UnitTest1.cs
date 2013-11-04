namespace _01.HelloTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FirstTest()
        {
            string actual = Hello.NameGreeter("Ivan");
            string expected = "Hello, Ivan!";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SecondTest()
        {
            string actual = Hello.NameGreeter("Iliq");
            string expected = "Hello, Iliq!";
            Assert.AreEqual(expected, actual);
        }
    }
}
