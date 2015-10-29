namespace _03.HelloMyName.Tests
{
    using System;
    using System.IO;

    using NUnit.Framework;

    [TestFixture]
    public class GreetingTests
    {
        [Test]
        public void GreetingShouldBeTheHelloWithName()
        {
            var expected = "Hello, John Doe!";

            using (var consoleWriter = new StringWriter())
            {
                Console.SetOut(consoleWriter);

                HelloMyName.Main();

                Assert.AreEqual(expected, consoleWriter.ToString().Trim());
            }
        }
    }
}
