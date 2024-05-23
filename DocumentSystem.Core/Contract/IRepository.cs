using System.Collections.Generic;
using System.Security.Principal;

namespace DocumentSystem.Core.Contract
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Create(TEntity entity);

        TEntity Delete(TEntity entity);

        TEntity Update(TEntity entity);

        IQueryable<TEntity> AsQueryable();
    }
}
