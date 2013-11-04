namespace JusTeeth.Data
{
    using System.Data.Entity;
    using JusTeeth.Models;

    /// <summary>
    ///     This interface is not necessary
    /// </summary>
    public interface IDbContext
    {
        DbSet<Place> Places { get; set; }

        DbSet<Feedback> Feedbacks { get; set; }

        DbSet<HungryGroup> HungryGroups { get; set; }

        DbSet<Department> Departments { get; set; }

        DbSet<Workplace> Workplaces { get; set; }

        DbSet<Image> Images { get; set; } 
    }
}
