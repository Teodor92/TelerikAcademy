namespace _01.HelloTest
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using _01.Hello;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FirstTest()
        {
            string actual = Hello.GetGreeting("Ivan");
            string expected = "Hello, Ivan!";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SecondTest()
        {
            string actual = Hello.GetGreeting("Iliq");
            string expected = "Hello, Iliq!";
            Assert.AreEqual(expected, actual);
        }
    }
}
