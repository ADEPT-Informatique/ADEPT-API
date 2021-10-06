using ADEPT_API.DATABASE.Context;
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
    internal abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly AdeptContext _context;
        internal DbSet<T> dbSet;

        protected virtual AdeptContext Context { get { return _context; } }

        protected BaseRepository(AdeptContext pContext)
        {
            _context = pContext ?? throw new ArgumentNullException($"{nameof(BaseRepository<T>)} was expection a value for {nameof(pContext)} but received null..");
            this.dbSet = _context.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void AddOrUpdate(T entity)
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

        public T Get(Guid id)
        {
            return dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
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
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public PagedList<IQueryable<T>, T> GetPaginatedResults(int pageIndex, int pageSize, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = null)
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

            return query.ToPagedList(pageSize, pageIndex);
        }

        public T GetFirstOrDefault(Expression<Func<T, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            if (query.FirstOrDefault() == null)
                return null;

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

            return query.FirstOrDefault();
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

