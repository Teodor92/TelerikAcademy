namespace MajorantFind.Test
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class IListUtilsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IListUtils_FindMajorantInvalidNullInput()
        {
            IListUtils.FindMajorant(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IListUtils_FindMajorantInvalidEmptyInput()
        {
            IListUtils.FindMajorant(new List<int>());
        }

        [TestMethod]
        public void IListUtils_FindMajorantSimpleInput()
        {
            int actual = IListUtils.FindMajorant(new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 });
            int expected = 3;

            Assert.AreEqual(expected, actual);
        }
    }
}
