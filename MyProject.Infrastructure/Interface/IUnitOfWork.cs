using Microsoft.EntityFrameworkCore;
using MyProject.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Infrastructure.Interface
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        Task<bool> CommitAsync();
        void Commit();
        void Dispose();
        GenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
