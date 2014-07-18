namespace SimpleCookBook.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SimpleCookBook.Models;

    public sealed class Configuration : DbMigrationsConfiguration<SimpleCookBook.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SimpleCookBook.Data.ApplicationDbContext context)
        {
            //for (int i = 0; i < 100; i++)
            //{
            //    context.Notes.Add(new Note()
            //    {
            //        Author = "BaiIvan " + i,
            //        Content = "Some sample content " + i,
            //        Latitude = i,
            //        Lontitude = i,
            //        PostAddress = "Sample address " + i,
            //        PostDate = DateTime.Now,
            //        Title = "This is SAPARTA" + i + "!!"
            //    });
            //}

            //context.SaveChanges();
        }
    }
}
