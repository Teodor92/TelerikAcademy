namespace AirPortSystem.Migrations
{
    using AirPortSystem.Models;
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AirPortSystem.Data.AirPortDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AirPortSystem.Data.AirPortDbContext context)
        {
            context.Flights.AddOrUpdate(
                f => f.AvailableTickets,
                new Flight()
                {
                    AvailableTickets = 50,
                    FlightDate = DateTime.Now.AddDays(1),
                    Price = 400,
                    FromAirPort = "Sofia",
                    ToAirPort = "London"
                });
        }
    }
}