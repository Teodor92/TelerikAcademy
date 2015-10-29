namespace _07.TimeAndDate.Tests
{
    using System;
    using System.IO;

    using NUnit.Framework;

    [TestFixture]
    public class DateTimePrintTests
    {
        [Test]
        public void DateTimeShouldBePrinted()
        {
            var expected = $"{DateTime.Now}{Environment.NewLine}";

            using (var consoleWriter = new StringWriter())
            {
                Console.SetOut(consoleWriter);

                TimeAndDate.Main();

                Assert.AreEqual(expected, consoleWriter.ToString());
            }
        }
    }
}
