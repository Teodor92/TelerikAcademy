namespace _09.NumberSequence.Tests
{
    using System;
    using System.IO;
    using System.Text;

    using NUnit.Framework;

    [TestFixture]
    public class SequncePrintTests
    {
        [Test]
        public void SequnceShouldBePrinted()
        {
            var expected = this.GetExpectedOutPutForSequnce(10);

            using (var consoleWriter = new StringWriter())
            {
                Console.SetOut(consoleWriter);

                NumebrSequence.Main();

                Assert.AreEqual(expected, consoleWriter.ToString());
            }
        }

        private string GetExpectedOutPutForSequnce(int sequnceLength)
        {
            var output = new StringBuilder();

            for (int i = 2; i < sequnceLength + 2; i++)
            {
                if (i % 2 == 0)
                {
                    output.AppendFormat("{0}{1}", i, Environment.NewLine);
                }
                else
                {
                    output.AppendFormat("{0}{1}", -i, Environment.NewLine);
                }
            }

            return output.ToString();
        }
    }
}
