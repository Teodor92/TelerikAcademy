namespace Students.Repos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class InMemoryReposiotry<T> : IRepository<T> where T : class
    {
        public readonly List<T> entities = new List<T>();

        public T Add(T item)
        {
            this.entities.Add(item);
            return item;
        }

        public T Update(int id, T item)
        {
            this.entities[id] = item;
            return item;
        }

        public bool Delete(int id)
        {
            this.entities.RemoveAt(id);
            return true;
        }

        public bool Delete(T item)
        {
            this.entities.RemoveAll(x => x == item);
            return true;
        }

        public T Get(int id)
        {
            return this.entities[id];
        }

        public IQueryable<T> All()
        {
            return this.entities.AsQueryable();
        }

        //public IQueryable<T> Find(Expression<Func<T, int, bool>> predicate)
        //{
        //    //return this.localRepo.Where(predicate);
        //    throw new NotImplementedException();
        //}
    }
}
