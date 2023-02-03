using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MyProject.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbSet { get; set; }
        public GenericRepository(DbContext context)
        {
            _dbSet = context.Set<TEntity>();
            _context = context;
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }
        public virtual void Update(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            var abc = _context.Entry(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }
        public virtual async void Delete(object id)
        {
            TEntity entityToDelete = await _dbSet.FindAsync(id);
            Delete(entityToDelete);
        }
        public virtual void RemoveRange(List<TEntity> entity)
        {
            _context.RemoveRange(entity);
        }
        public virtual void Delete(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
                _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
        }
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true, int offset = 0, int limit = -1)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (include != null) query = include(query);

            if (orderBy != null)
                return orderBy(query);

            //limit = -1: get all data
            if (limit != -1)
            {
                return query.Skip(offset).Take(limit);
            }

            return query;
        }
        public virtual IEnumerable<TEntity> Get(out int count, Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true, int offset = 0, int limit = -1)
        {
            IQueryable<TEntity> query = _dbSet;
            if (!enableTracking) query = query.AsNoTracking();

            if (filter != null)
                query = query.Where(filter);

            if (include != null) query = include(query);

            count = query.Count();

            if (orderBy != null)
                query = orderBy(query);

            //limit = -1: get all data
            if (limit != -1)
            {
                //return query.Skip(offset).Take(limit);
                return query.Skip(offset * limit).Take(limit);
            }
            return query;
        }
    }
}
