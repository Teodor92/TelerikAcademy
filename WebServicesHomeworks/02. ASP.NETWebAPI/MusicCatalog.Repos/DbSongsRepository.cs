using MusicCatalog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlacesDatabase.Repositories
{
    public class DbCategoriesRepository : IRepository<Song>
    {
        private DbContext dbContext;
        private DbSet<Song> entitySet;

        public DbCategoriesRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Song>();
        }

        public Song Add(Song item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Song Update(int id, Song item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Song item)
        {
            throw new NotImplementedException();
        }

        public Song Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Song> All()
        {
            return this.entitySet;
        }

        public IQueryable<Song> Find(System.Linq.Expressions.Expression<Func<Song, int, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
