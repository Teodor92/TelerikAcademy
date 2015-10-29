namespace _06.PrintFirstAndLast.Tests
{
    using System;
    using System.IO;

    using NUnit.Framework;

    [TestFixture]
    public class NamePrintTests
    {
        [Test]
        public void NameShouldBePrinited()
        {
            var expected = $"John Doe{Environment.NewLine}";

            using (var consoleWriter = new StringWriter())
            {
                Console.SetOut(consoleWriter);

                PrintFirstAndLast.Main();

                Assert.AreEqual(expected, consoleWriter.ToString());
            }
        }
    }
}
