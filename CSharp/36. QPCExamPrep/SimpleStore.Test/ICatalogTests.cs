namespace SimpleStore.Test
{
    using System;
    using System.Linq;
    using SimpleSotre.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ICatalogTests
    {
        [TestMethod]
        public void AddTest_SingleElement()
        {
            Catalog myTestCatalog = new Catalog();
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));

            int expected = 1;
            Assert.AreEqual(expected, myTestCatalog.Count);
        }

        [TestMethod]
        public void AddTest_DuplivateElements()
        {
            Catalog myTestCatalog = new Catalog();
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));

            int expected = 2;
            Assert.AreEqual(expected, myTestCatalog.Count);
        }

        [TestMethod]
        public void AddTest_MultipleElements()
        {
            Catalog myTestCatalog = new Catalog();
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Two", "Meta", "8341120", "http://goo.gl/dIkth7gs" }));

            int expected = 3;
            Assert.AreEqual(expected, myTestCatalog.Count);
        }

        [TestMethod]
        public void GetListContentTest_MultipleElements()
        {
            Catalog myTestCatalog = new Catalog();
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Two", "Meta", "8341120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Three", "fou", "8342120", "http://goao.gl/daIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Foo", "Bar", "8341126", "http://goao.gl/dIkth7gs" }));

            int expected = 3;
            var matched = myTestCatalog.GetListContent("One", 3);
            Assert.AreEqual(expected, matched.Count());
        }

        [TestMethod]
        public void GetListContentTest_LessThenReqMatchCount()
        {
            Catalog myTestCatalog = new Catalog();
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Two", "Meta", "8341120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Three", "fou", "8342120", "http://goao.gl/daIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Foo", "Bar", "8341126", "http://goao.gl/dIkth7gs" }));

            int expected = 3;
            var matched = myTestCatalog.GetListContent("One", 5);
            Assert.AreEqual(expected, matched.Count());
        }

        [TestMethod]
        public void GetListContentTest_MoreThenReqMatchCount()
        {
            Catalog myTestCatalog = new Catalog();
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Two", "Meta", "8341120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Three", "fou", "8342120", "http://goao.gl/daIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Foo", "Bar", "8341126", "http://goao.gl/dIkth7gs" }));

            int expected = 1;
            var matched = myTestCatalog.GetListContent("One", 1);
            Assert.AreEqual(expected, matched.Count());
        }

        [TestMethod]
        public void GetListContentTest_NoMatchCount()
        {
            Catalog myTestCatalog = new Catalog();
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Two", "Meta", "8341120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Three", "fou", "8342120", "http://goao.gl/daIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Foo", "Bar", "8341126", "http://goao.gl/dIkth7gs" }));

            int expected = 0;
            var matched = myTestCatalog.GetListContent("xxx", 2);
            Assert.AreEqual(expected, matched.Count());
        }

        [TestMethod]
        public void UpdateContentTest_MultipleUpdates()
        {
            Catalog myTestCatalog = new Catalog();
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "One", "Metallica", "8771120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Two", "Meta", "8341120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Three", "fou", "8342120", "http://goao.gl/daIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Foo", "Bar", "8341126", "http://goao.gl/dIkth7gs" }));

            int expected = 4;
            int updated = myTestCatalog.UpdateContent("http://goo.gl/dIkth7gs", "UPDATER");
            Assert.AreEqual(expected, updated);
        }

        [TestMethod]
        public void UpdateContentTest_OneUpdate()
        {
            Catalog myTestCatalog = new Catalog();
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Two", "Meta", "8341120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Three", "fou", "8342120", "http://goao.gl/daeIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Foo", "Bar", "8341126", "http://goao.gl/dIkth7gs" }));

            int expected = 1;
            int updated = myTestCatalog.UpdateContent("http://goo.gl/dIkth7gs", "UPDATER");
            Assert.AreEqual(expected, updated);
        }

        [TestMethod]
        public void UpdateContentTest_DoubleSameUpdate()
        {
            Catalog myTestCatalog = new Catalog();
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Two", "Meta", "8341120", "http://goo.gl/dIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Three", "fou", "8342120", "http://goao.gl/daeIkth7gs" }));
            myTestCatalog.Add(new Content(Contents.Book, new string[] { "Foo", "Bar", "8341126", "http://goao.gl/dIkth7gs" }));

            int expected = 1;
            myTestCatalog.UpdateContent("http://goo.gl/dIkth7gs", "UPDATER");
            int updated = myTestCatalog.UpdateContent("UPDATER", "MEGA_UPDATER");
            Assert.AreEqual(expected, updated);
        }
    }
}
