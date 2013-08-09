namespace TrianglePoints.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void CheckIfPointIsInTriangle_OnFirstEdgeTest()
        {
            Triangle myTriangle = new Triangle(new Point(0, 0), new Point(0, 3), new Point(4, 0));

            Assert.IsFalse(myTriangle.CheckIfPointIsInTriangle(new Point(0, 0)));
        }

        [TestMethod]
        public void CheckIfPointIsInTriangle_OnSecondEdgeTest()
        {
            Triangle myTriangle = new Triangle(new Point(0, 0), new Point(0, 3), new Point(4, 0));

            Assert.IsFalse(myTriangle.CheckIfPointIsInTriangle(new Point(0, 3)));
        }

        [TestMethod]
        public void CheckIfPointIsInTriangle_OnThridEdgeTest()
        {
            Triangle myTriangle = new Triangle(new Point(0, 0), new Point(0, 3), new Point(4, 0));

            Assert.IsFalse(myTriangle.CheckIfPointIsInTriangle(new Point(4, 0)));
        }

        [TestMethod]
        public void CheckIfPointIsInTriangle_InsideOfTriangleTest()
        {
            Triangle myTriangle = new Triangle(new Point(0, 0), new Point(0, 3), new Point(4, 0));

            Assert.IsTrue(myTriangle.CheckIfPointIsInTriangle(new Point(1, 1)));
        }
    }
}
