using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using AirPortSystem.Models;

namespace AirPortSystem.Data
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    // You can inherit the base IdentityContext and add your application custom DbSets
    public class AirPortDbContext : IdentityDbContext<AirPortUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public AirPortDbContext() : base("AirPortDbConnection")
        {
        }

        public DbSet<Log> Logs { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<Ticket> Tickets { get; set; }
    }
}