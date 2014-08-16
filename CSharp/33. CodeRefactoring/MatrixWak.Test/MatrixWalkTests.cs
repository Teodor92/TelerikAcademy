namespace TestMatrix
{
    using System;
    using MatrixWalk;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ZeroDimentionsTest()
        {
            var matrix = new MatrixRotatingWalk(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NegativeDimentionsTest()
        {
            var matrix = new MatrixRotatingWalk(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TooBigDimentionsTest()
        {
            var matrix = new MatrixRotatingWalk(101);
        }

        [TestMethod]
        public void OneDimentionTest()
        {
            var matrix = new MatrixRotatingWalk(1);

            Assert.IsTrue(matrix.ToString() == string.Format("  1{0}", Environment.NewLine));
        }

        [TestMethod]
        public void TwoDimentionTest()
        {
            var matrix = new MatrixRotatingWalk(2);

            Assert.IsTrue(matrix.ToString() == string.Format("  1  4{0}  3  2{0}", Environment.NewLine));
        }

        [TestMethod]
        public void ThreeDimentionTest()
        {
            var matrix = new MatrixRotatingWalk(3);

            Assert.AreEqual(matrix.ToString(), string.Format("  1  7  8{0}  6  2  9{0}  5  4  3{0}", Environment.NewLine));
        }

        [TestMethod]
        public void SixDimentionTest()
        {
            var matrix = new MatrixRotatingWalk(6);

            Assert.AreEqual(
                matrix.ToString(), 
                string.Format(
                    "{0}{6}{1}{6}{2}{6}{3}{6}{4}{6}{5}{6}",
                    "  1 16 17 18 19 20",
                    " 15  2 27 28 29 21",
                    " 14 31  3 26 30 22",
                    " 13 36 32  4 25 23",
                    " 12 35 34 33  5 24",
                    " 11 10  9  8  7  6",
                    Environment.NewLine));
        }
    }
}