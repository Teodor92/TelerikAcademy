namespace StudentSystem.Client
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystem.Data;
    using StudentSystem.Data.Migrations;
    using StudentSystem.Models;

    public class Program
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            Random randomGen = new Random();

            using (var dbContext = new StudentSystemContext())
            {
                for (int i = 0; i < 20; i++)
                {
                    Student student1 = new Student()
                    {
                        Name = "Ivan" + i,
                        StudentNumber = randomGen.Next(100000, 999999)
                    };

                    dbContext.Students.Add(student1);
                }

                dbContext.SaveChanges();
            }
        }
    }
}
