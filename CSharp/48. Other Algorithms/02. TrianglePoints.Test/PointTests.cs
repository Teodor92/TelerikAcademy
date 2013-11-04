namespace TrianglePoints.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TrianglePoints;

    [TestClass]
    public class PointTests
    {
        [TestMethod]
        public void Point_InitTest()
        {
            Point myPoint = new Point(2, 3);
            Assert.AreEqual(myPoint, new Point(2, 3));
        }
    }
}
