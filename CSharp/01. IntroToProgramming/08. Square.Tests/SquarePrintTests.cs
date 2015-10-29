namespace _08.Square.Tests
{
    using System;
    using System.IO;

    using NUnit.Framework;

    [TestFixture]
    public class SquarePrintTests
    {
        [Test]
        public void TheSquareOf12345ShouldBePrinted()
        {
            var expected = $"{Math.Pow(12345, 2)}{Environment.NewLine}";

            using (var consoleWriter = new StringWriter())
            {
                Console.SetOut(consoleWriter);

                Square.Main();

                Assert.AreEqual(expected, consoleWriter.ToString());
            }
        }
    }
}
