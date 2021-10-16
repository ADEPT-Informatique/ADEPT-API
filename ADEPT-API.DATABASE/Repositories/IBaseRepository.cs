using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ADEPT_API.DATABASE.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        Task<TEntity> GetAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllAsync(
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          IncludeResolver<TEntity> includeResolver = null
          );

        Task<PagedList<IQueryable<TEntity>, TEntity>> GetPaginatedResultsAsync(
          int pageIndex,
          int pageSize,
          Expression<Func<TEntity, bool>> filter = null,
          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
          IncludeResolver<TEntity> includeResolver = null
          );

        Task<TEntity> GetFirstOrDefaultAsync(
         Expression<Func<TEntity, bool>> filter = null,
         IncludeResolver<TEntity> includeResolver = null
         );

        Task AddAsync(TEntity entity);

        void AddOrUpdate(TEntity entity);

        void Remove(Guid id);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entity);

        void Save();

        Task SaveAsync();
    }
}
