namespace MusicCatalog.Repos
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    public interface IRepository<T>
    {
        T Add(T item);

        T Update(int id, T item);

        bool Delete(int id);

        bool Delete(T item);

        T Get(int id);

        IQueryable<T> All();

        IQueryable<T> Find(Expression<Func<T, int, bool>> predicate);
    }
}
