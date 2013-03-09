namespace _01._3DPointTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ZeroCoordTest()
        {
            Point3D zeroTest = new Point3D(0, 0, 0);

            Assert.AreEqual(zeroTest, Point3D.Zero);
        }

        [TestMethod]
        public void DistanceTest1()
        {
            Point3D zeroTest = new Point3D(2, 2, 2);
            Point3D zeroTestTwo = new Point3D(2, 2, 2);

            Assert.AreEqual(0, Distance3D.CalcDistance(zeroTest, zeroTestTwo));
        }

        [TestMethod]
        public void DistanceTest2()
        {
            Point3D zeroTest = new Point3D(2, 2, 2);
            Point3D zeroTestTwo = new Point3D(2, 2, 1);

            Assert.AreEqual(1, Distance3D.CalcDistance(zeroTest, zeroTestTwo));
        }

        [TestMethod]
        public void PathStoreTest()
        {
            Path pathTest = new Path();
            pathTest.AddPoint(new Point3D(1, 1, 1));
            pathTest.AddPoint(new Point3D(2, 2, 2));

            Assert.AreEqual(2, pathTest.AllPoints.Count);
        }
    }
}
