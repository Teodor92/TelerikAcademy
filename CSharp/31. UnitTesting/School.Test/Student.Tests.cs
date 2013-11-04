namespace School.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void Student_TestConstructorName()
        {
            string name = "Ivan";
            Student myTestStundet = new Student(name, 11111);

            Assert.AreEqual(name, myTestStundet.Name);
        }

        [TestMethod]
        public void Student_TestConstructorUniqeNumber()
        {
            int id = 11111;
            Student myTestStundet = new Student("Ivan", 11111);

            Assert.AreEqual(id, myTestStundet.UniqeNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_TestNullName()
        {
            string name = null;
            Student myTestStundet = new Student(name, 11111);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Student_TestEmptyName()
        {
            string name = string.Empty;
            Student myTestStundet = new Student(name, 11111);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_TestIDUnderMinValue()
        {
            string name = "Ivan";
            int uniqeNumber = 100;
            Student student = new Student(name, uniqeNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Student_TestIDOverMaxValue()
        {
            string name = "Ivan";
            int uniqueNumber = 10000000;
            Student student = new Student(name, uniqueNumber);
        }
    }
}
