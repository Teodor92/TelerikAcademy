namespace School.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        public void School_ConstructorTest()
        {
            School myTestSchool = new School();
            Assert.IsNotNull(myTestSchool);
        }

        [TestMethod]
        public void School_AddCourseTest()
        {
            Course java = new Course("Java");
            School myTestSchool = new School();
            myTestSchool.AddCourse(java);
            Assert.AreEqual(java.CourseName, myTestSchool.Courses[0].CourseName);
        }

        [TestMethod]
        public void School_RemoveCourseTest()
        {
            Course java = new Course("Java");
            School myTestSchool = new School();
            myTestSchool.AddCourse(java);
            myTestSchool.RemoveCourse(java);

            Assert.AreEqual(myTestSchool.Courses.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void School_RemoveNonExistingCourse()
        {
            Course java = new Course("Java");
            School myTestSchool = new School();
            myTestSchool.RemoveCourse(java);
        }
    }
}
