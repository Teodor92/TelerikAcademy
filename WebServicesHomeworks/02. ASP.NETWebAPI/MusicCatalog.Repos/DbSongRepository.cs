namespace MusicCatalog.Repos
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using MusicCatalog.Models;

    public class DbSongRepository : IRepository<Song>
    {
        private DbContext dbContext;
        private DbSet<Song> entitySet;

        public DbSongRepository(DbContext dbContext)
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
            this.dbContext.Entry<Song>(item).CurrentValues.SetValues(item);
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

        public bool Delete(Song item)
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
            return this.entitySet.Where(predicate);
        }
    }
}
