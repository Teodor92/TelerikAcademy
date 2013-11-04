namespace MusicCatalog.Repos
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using MusicCatalog.Models;
    using System.Data.Entity;

    public class DbArtistRepository : IRepository<Artist>
    {
        private DbContext dbContext;
        private DbSet<Artist> entitySet;

        public DbArtistRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.entitySet = this.dbContext.Set<Artist>();
        }

        public Artist Add(Artist item)
        {
            this.entitySet.Add(item);
            this.dbContext.SaveChanges();
            return item;
        }

        public Artist Update(int id, Artist item)
        {
            this.dbContext.Entry<Artist>(item).CurrentValues.SetValues(item);
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

        public bool Delete(Artist item)
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

        public Artist Get(int id)
        {
            return this.entitySet.Find(id);
        }

        public IQueryable<Artist> All()
        {
            return this.entitySet;
        }

        public IQueryable<Artist> Find(Expression<Func<Artist, int, bool>> predicate)
        {
            return this.entitySet.Where(predicate);
        }
    }
}
