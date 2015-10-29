namespace _02.HelloCSharp.Tests
{
    using System;
    using System.IO;

    using NUnit.Framework;

    [TestFixture]
    public class GreetingTests
    {
        [Test]
        public void GreetingShouldBeTheHelloCSharp()
        {
            var expected = "Hello, C#!";

            using (var consoleWriter = new StringWriter())
            {
                Console.SetOut(consoleWriter);

                HelloCSharp.Main();

                Assert.AreEqual(expected, consoleWriter.ToString().Trim());
            }
        }
    }
}
