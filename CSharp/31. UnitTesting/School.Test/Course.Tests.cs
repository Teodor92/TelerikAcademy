namespace School.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void Course_ConstructorNameTest()
        {
            string name = "Java";
            Course testCourse = new Course("Java");

            Assert.AreEqual(testCourse.CourseName, name);
        }

        [TestMethod]
        public void Course_TestStudentsList()
        {
            Course testCourse = new Course("Java");
            Student ivan = new Student("Ivan", 11111);

            testCourse.AddStudent(ivan);

            Assert.IsTrue(testCourse.Students.Contains(ivan));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Course_TestNullName()
        {
            string name = null;
            Course testCourse = new Course(name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Course_TestEmptyName()
        {
            string name = string.Empty;
            Course testCourse = new Course(name);
        }

        [TestMethod]
        public void Course_TestAddingStudents()
        {
            Course myTestCourse = new Course("Java");

            for (int i = 0; i < 13; i++)
            {
                Student myTestStudent = new Student("Pesho", 11111 + i);
                myTestCourse.AddStudent(myTestStudent);
            }

            Assert.IsTrue(myTestCourse.Students.Count == 13);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_TestSameStudentAdding()
        {
            string name = "Java";
            Course course = new Course(name);
            Student ivan = new Student("Ivan", 12345);

            course.AddStudent(ivan);
            course.AddStudent(ivan);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Course_TestMaximumStudents()
        {
            string name = "Java";
            Course course = new Course(name);

            for (int i = 0; i < 31; i++)
            {
                Student ivan = new Student("Ivan", 11111 + i);
                course.AddStudent(ivan);
            }
        }

        [TestMethod]
        public void Course_TestRemoveingStudents()
        {
            string name = "Java";
            Course course = new Course(name);

            Student ivan = new Student("Ivan", 11111);

            course.AddStudent(ivan);
            course.RemoveStudent(ivan);

            Assert.AreEqual(course.Students.Count, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Course_TestRemovingNonExistingStudent()
        {
            string name = "Java";
            Course course = new Course(name);

            Student ivan = new Student("Ivan", 11111);
            course.RemoveStudent(ivan);
        }

        [TestMethod]
        public void Course_TestToStringOverride()
        {
            string name = "Java";
            Course course = new Course(name);

            Student ivan = new Student("Ivan", 11111);
            course.AddStudent(ivan);

            string expected = "Course name Java; Student Ivan, ID 11111; ";
            string actual = course.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
