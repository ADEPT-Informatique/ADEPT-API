using ADEPT_API.DATABASE.Context;
using ADEPT_API.DATABASE.Models.Markers;
using ADEPT_API.DATABASE.Repositories;
using Microsoft.EntityFrameworkCore;
using Sakura.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ADEPT_API.Repositories.Internals
{
    internal abstract class BaseRepository<T> : IBaseRepository<T> where T : class, IBaseModel
    {
        protected readonly AdeptContext _context;
        internal DbSet<T> dbSet;

        protected virtual AdeptContext Context { get { return _context; } }

        protected BaseRepository(AdeptContext pContext)
        {
            _context = pContext ?? throw new ArgumentNullException($"{nameof(BaseRepository<T>)} was expection a value for {nameof(pContext)} but received null..");
            this.dbSet = _context.Set<T>();
        }

        public async void Add(T entity)
        {
           await dbSet.AddAsync(entity);
        }

        public void AddOrUpdate(T entity)
        {
            if (entity.Id != Guid.Empty)
            {
                dbSet.Update(entity);
            }
            else
            {
                dbSet.Add(entity);
            }
        }

        public async Task<T> Get(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            return await query.ToListAsync();
        }

        public async Task<PagedList<IQueryable<T>, T>> GetPaginatedResults(int pageIndex, int pageSize, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter is { })
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.ToPagedListAsync(pageSize, pageIndex);
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }

            return await query.FirstOrDefaultAsync();
        }

        public void Remove(Guid id)
        {
            T entity = dbSet.Find(id);
            Remove(entity);
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
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

