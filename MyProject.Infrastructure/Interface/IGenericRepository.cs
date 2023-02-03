using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entityToUpdate);
        void Delete(object id);
        void RemoveRange(List<TEntity> entity);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true, int offset = 0, int limit = -1);
        IEnumerable<TEntity> Get(out int count, Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null,
            bool enableTracking = true, int offset = 0, int limit = -1);
    }
}
