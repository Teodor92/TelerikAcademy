namespace _04.PrintNumbers.Tests
{
    using System;
    using System.IO;

    using NUnit.Framework;

    [TestFixture]
    public class NumberPrintTests
    {
        [Test]
        public void NumbersShouldBePrinitedOnNewLines()
        {
            var expected = string.Format("1{0}101{0}1001{0}", Environment.NewLine);

            using (var consoleWriter = new StringWriter())
            {
                Console.SetOut(consoleWriter);

                PrintNumbers.Main();

                Assert.AreEqual(expected, consoleWriter.ToString());
            }
        }
    }
}
