using ADEPT_API.DATABASE;
using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Repositories;
using ADEPT_API.DATACONTRACTS.Enums;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace ADEPT_API.Repositories.Internals
{
    internal abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly AdeptContext _context;
        internal DbSet<TEntity> dbSet;

        protected virtual AdeptContext Context { get { return _context; } }

        protected BaseRepository(AdeptContext context)
        {
            _context = context ?? throw new ArgumentNullException($"{nameof(BaseRepository<TEntity>)} was expection a value for {nameof(context)} but received null..");
            this.dbSet = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public void AddOrUpdate(TEntity entity)
        {
            var type = entity.GetType();
            var property = type.GetProperties().FirstOrDefault(x => x.Name == "Id");
            if (property != null && (Guid)property.GetValue(entity) != Guid.Empty)
            {
                dbSet.Update(entity);
            }
            else
            {
                dbSet.Add(entity);
            }
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null, string orderField = null, OrderDirections orderDirection = OrderDirections.Asc, IncludeResolver<TEntity> includeResolver = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeResolver is { })
            {
                query = includeResolver(query);
            }

            if (!string.IsNullOrWhiteSpace(orderField))
            {
                query = query.OrderBy($"{orderField} {orderDirection}");
            }

            return await query.ToListAsync();
        }

        public async Task<PagedList<IQueryable<TEntity>, TEntity>> GetPaginatedResultsAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> filter = null, string orderField = null, OrderDirections orderDirection = OrderDirections.Asc, IncludeResolver<TEntity> includeResolver = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter is { })
            {
                query = query.Where(filter);
            }

            if (includeResolver is { })
            {
                query = includeResolver(query);
            }

            if (!string.IsNullOrWhiteSpace(orderField))
            {
                query = query.OrderBy($"{orderField} {orderDirection}");
            }

            return await query.ToPagedListAsync(pageSize, pageIndex);
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> filter = null, IncludeResolver<TEntity> includeResolver = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter is { })
            {
                query = query.Where(filter);
            }

            if (includeResolver is { })
            {
                query = includeResolver(query);
            }

            return await query.FirstOrDefaultAsync();
        }

        public void Remove(Guid id)
        {
            TEntity entity = dbSet.Find(id);
            Remove(entity);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entity)
        {
            dbSet.RemoveRange(entity);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

