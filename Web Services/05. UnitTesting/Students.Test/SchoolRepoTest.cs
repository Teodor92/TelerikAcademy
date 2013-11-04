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
    public class SchoolRepoTest
    {
        public DbContext dbContext { get; set; }

        static Random rand = new Random();

        public IRepository<School> schoolRepo { get; set; }

        private static TransactionScope tranScope;

        public SchoolRepoTest()
        {
            this.dbContext = new StudentsContext();
            this.schoolRepo = new EfRepository<School>(this.dbContext);
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
            var schoolName = "Test name";
            var school = new School()
            {
                Name = schoolName,
            };

            var addedSchool = this.schoolRepo.Add(school);
            var foundSchool = this.dbContext.Set<School>().Find(addedSchool.Id);
            Assert.IsNotNull(foundSchool);
            Assert.AreEqual(schoolName, foundSchool.Name);
        }

        [TestMethod]
        public void AllTest_GetAll_WhereAllIs2()
        {
            int alreadyIn = this.schoolRepo.All().Count();

            var schoolName = "Test name";
            var school = new School()
            {
                Name = schoolName,
            };

            var secondSchool = new School()
            {
                Name = schoolName,
            };

            var addedSchool = this.schoolRepo.Add(school);
            var secondAddedSchool = this.schoolRepo.Add(secondSchool);

            var foundMarks = this.schoolRepo.All().ToList();
            Assert.IsNotNull(foundMarks);
            Assert.AreEqual(alreadyIn + 2, foundMarks.Count);
        }

        [TestMethod]
        public void RemoveTest_OneAddOneRemove()
        {
            int alreadyIn = this.schoolRepo.All().Count();

            var schoolName = "Test name";
            var mark = new School()
            {
                Name = schoolName,
            };

            var addedSchool = this.schoolRepo.Add(mark);
            bool isDeleted = this.schoolRepo.Delete(addedSchool.Id);

            Assert.IsTrue(isDeleted);
            Assert.AreEqual(alreadyIn, this.schoolRepo.All().Count());
        }
    }
}
