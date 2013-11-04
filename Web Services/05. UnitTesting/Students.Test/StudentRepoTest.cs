using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using Students.Models;
using Students.Repos;
using System.Transactions;
using Students.Data;

namespace Students.Test
{
    [TestClass]
    public class StudentRepoTest
    {
        public DbContext dbContext { get; set; }

        static Random rand = new Random();

        public IRepository<Student> studenteRepo { get; set; }

        private static TransactionScope tranScope;

        public StudentRepoTest()
        {
            this.dbContext = new StudentsContext();
            this.studenteRepo = new EfRepository<Student>(this.dbContext);
        }

        [TestInitialize]
        public void TestInit()
        {
            tranScope = new TransactionScope();
        }

        [TestCleanup]
        public void TestTearDown()
        {
            tranScope.Dispose();
        }

        [TestMethod]
        public void AddTest_AddOneVailid()
        {
            var studentFirstName = "Test name";
            var school = new Student()
            {
                FirstName = studentFirstName,
                SchoolId = 1
            };

            var addedSchool = this.studenteRepo.Add(school);
            var foundSchool = this.dbContext.Set<Student>().Find(addedSchool.Id);
            Assert.IsNotNull(foundSchool);
            Assert.AreEqual(studentFirstName, foundSchool.FirstName);
        }

        [TestMethod]
        public void AllTest_GetAll_WhereAllIs2()
        {
            int alreadyIn = this.studenteRepo.All().Count();

            var studentFirstName = "Test name";
            var student = new Student()
            {
                FirstName = studentFirstName,
                SchoolId = 1
            };

            var secontStudent = new Student()
            {
                FirstName = studentFirstName,
                SchoolId = 1
            };

            var addedStudent = this.studenteRepo.Add(student);
            var secondAddedStudent = this.studenteRepo.Add(secontStudent);

            var foundMarks = this.studenteRepo.All().ToList();
            Assert.IsNotNull(foundMarks);
            Assert.AreEqual(alreadyIn + 2, foundMarks.Count);
        }

        [TestMethod]
        public void RemoveTest_OneAddOneRemove()
        {
            int alreadyIn = this.studenteRepo.All().Count();

            var studentFirstName = "Test name";
            var mark = new Student()
            {
                FirstName = studentFirstName,
                SchoolId = 1
            };

            var addedStudent = this.studenteRepo.Add(mark);
            bool isDeleted = this.studenteRepo.Delete(addedStudent.Id);

            Assert.IsTrue(isDeleted);
            Assert.AreEqual(alreadyIn, this.studenteRepo.All().Count());
        }
    }
}
