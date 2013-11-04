namespace MusicCatalog.Repos
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using MusicCatalog.Models;
    using System.Data.Entity;

    public class DbAlbumRepository : IRepository<Album>
    {
        private DbContext dbContext;
        private DbSet<Album> entitySet;

        public DbAlbumRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Album>();
        }

        public Album Add(Album item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Album Update(int id, Album item)
        {
            this.dbContext.Entry<Album>(item).CurrentValues.SetValues(item);
            this.dbContext.SaveChanges();
            return item;

        }

        public bool Delete(int id)
        {
            var entity = this.entitySet.Find(id);
            if (entity != null)
            {
                this.entitySet.Remove(entity);
                this.dbContext.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Album item)
        {
            var entity = this.entitySet.Find(item);
            if (entity != null)
            {
                this.entitySet.Remove(entity);
                this.dbContext.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public Album Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Album> All()
        {
            return this.entitySet;
        }

        public IQueryable<Album> Find(Expression<Func<Album, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}
