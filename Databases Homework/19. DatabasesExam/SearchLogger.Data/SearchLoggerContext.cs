using System;
using System.Data.Entity;
using System.Linq;
using SearchLogger.Model;

namespace SearchLogger.Data
{
    public class SearchLoggerEntities : DbContext
    {
        public SearchLoggerEntities()
            : base("Logs")
        {
        }

        public DbSet<SearchLog> SearchLogs { get; set; }
    }
}
