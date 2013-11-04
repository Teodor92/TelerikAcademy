using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Students.Models;
using Students.Repos;
using Students.Api.Controllers;
using System.Data.Entity;
using System.Transactions;
using Students.Data;

namespace Students.Test
{
    [TestClass]
    public class MarkRepoTest
    {
        public DbContext dbContext { get; set; }

        static Random rand = new Random();

        public IRepository<Mark> marksRepo { get; set; }

        private static TransactionScope tranScope;

        public MarkRepoTest()
        {
            this.dbContext = new StudentsContext();
            this.marksRepo = new EfRepository<Mark>(this.dbContext);
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
            var subject = "Test subject";
            var mark = new Mark()
            {
                Subject = subject,
                StudentId = 1
            };

            var addedMark = this.marksRepo.Add(mark);
            var foundMark = this.dbContext.Set<Mark>().Find(addedMark.Id);
            Assert.IsNotNull(foundMark);
            Assert.AreEqual(subject, foundMark.Subject);
        }

        [TestMethod]
        public void AllTest_GetAll_WhereAllIs2()
        {
            int alreadyIn = this.marksRepo.All().Count();

            var subject = "Test subject";
            var mark = new Mark()
            {
                Subject = subject,
                StudentId = 1
            };

            var secondMark = new Mark()
            {
                Subject = subject,
                StudentId = 1
            };

            var addedMark = this.marksRepo.Add(mark);
            var secondAddedMark = this.marksRepo.Add(secondMark);

            var foundMarks = this.marksRepo.All().ToList();
            Assert.IsNotNull(foundMarks);
            Assert.AreEqual(alreadyIn + 2, foundMarks.Count);
        }

        [TestMethod]
        public void RemoveTest_OneAddOneRemove()
        {
            int alreadyIn = this.marksRepo.All().Count();

            var subject = "Test subject";
            var mark = new Mark()
            {
                Subject = subject,
                StudentId = 1
            };

            var addedMark = this.marksRepo.Add(mark);
            bool isDeleted = this.marksRepo.Delete(addedMark.Id);

            Assert.IsTrue(isDeleted);
            Assert.AreEqual(alreadyIn, this.marksRepo.All().Count());
        }
    }
}
