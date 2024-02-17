using Gesco_Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Gesco_DataAccess
{
    public class GlobalRepositoryImpl<T> : IGlobalRepository<T> where T : class
    {
        private readonly GescoDbContext _myContext = new GescoDbContext();
        public void Add(params T[] items)
        {
            foreach (T item in items)
            {
                _myContext.Entry(item).State = EntityState.Added;
            }
            _myContext.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> myQuery = _myContext.Set<T>();

            foreach (var property in navigationProperties)
            {
                myQuery = myQuery.Include<T, object>(property);
            }
            return myQuery.ToList();
        }

        public IList<T> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = _myContext.Set<T>();

            foreach (var property in navigationProperties)
            {
                query = query.Include<T, object>(property);
            }
            return query.Where(where).ToList<T>();
        }

        public T GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> query = _myContext.Set<T>();

            foreach (var property in navigationProperties)
            {
                query = query.Include<T, object>(property);
            }
            return query.Where(where).FirstOrDefault();
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _myContext.Entry(item).State = EntityState.Deleted;
            }
            _myContext.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _myContext.Entry(item).State = EntityState.Modified;
            }
            _myContext.SaveChanges();
        }
    }
}