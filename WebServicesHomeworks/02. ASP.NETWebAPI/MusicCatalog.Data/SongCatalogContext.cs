using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicCatalog.Models;

namespace MusicCatalog.Data
{
    public class SongCatalogContext : DbContext
    {
        public SongCatalogContext()
            : base("MusicCatalog")
        {
        }

        //public SongCatalogContext(string nameOrConnectionString)
        //    : base(nameOrConnectionString)
        //{
        //}

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Song> Songs { get; set; }

    }
}
