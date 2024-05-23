using Microsoft.EntityFrameworkCore.Storage;
using System.Security.Principal;

namespace DocumentSystem.Core.Contract
{
    public interface IUnitOfWork
    {
        IDbContextTransaction BeginTransaction();

        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}
