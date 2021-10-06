using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ADEPT_API.DATABASE.Repositories
{
    public interface IBaseRepository<T> where T : class
    {

        T Get(Guid id);
        IEnumerable<T> GetAll(
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = null
          );

        PagedList<IQueryable<T>, T> GetPaginatedResults(
          int pageIndex,
          int pageSize,
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = null
          );

        T GetFirstOrDefault(
         Expression<Func<T, bool>> filter = null,
         string includeProperties = null
         );

        void Add(T entity);

        void AddOrUpdate(T entity);

        void Remove(Guid id);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        void Save();

        Task SaveAsync();
    }
}
