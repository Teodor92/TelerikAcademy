namespace Exam.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Exam.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //string userId = "36d6b620-4792-435d-95c5-763aecde7ac3";

            //for (int i = 0; i < 10; i++)
            //{
            //    var category = new Category()
            //    {
            //        Name = "Category Number " + i
            //    };

            //    for (int j = 0; j < 10; j++)
            //    {
            //        var ticket = new Ticket()
            //        {
            //            AuthorId = userId,
            //            Category = category,
            //            Description = "Some simple description " + i + " " + j,
            //            ScreenUrl = "http://www.bugdepotproducts.com/images/no-bugs.png",
            //            Title = "Title " + " " + j,
            //        };

            //        context.Tickets.Add(ticket);

            //        for (int k = 0; k < 10; k++)
            //        {
            //            var comment = new Comment()
            //            {
            //                Content = "Sample comment" + i + " " + j + " " + k,
            //                PostedById = userId,                            
            //            };

            //            ticket.Comments.Add(comment);

            //            context.Comments.Add(comment);
            //        }
            //    }

            //    context.Categories.Add(category);
            //}

            //context.SaveChanges();
        }
    }
}
