using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SimpleWebApp.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : User
    {  
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}