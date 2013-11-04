namespace BloggingSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using BloggingSystem.Models;

    public class BloggingSystemContext : DbContext
    {
        public BloggingSystemContext()
            : base("BloggingSystemDb")
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
