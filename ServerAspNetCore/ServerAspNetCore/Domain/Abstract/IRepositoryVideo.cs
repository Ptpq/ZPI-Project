using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerAspNetCore.Domain.Abstract
{
    public interface IRepositoryVideo<TEntity> where TEntity : class
    {
        Task<List<TEntity>> Get();
        Task<List<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> Get(Expression<System.Func<TEntity, bool>> predicate);
        Task<TEntity> Get(int firstIdOfKey, int secondIdOfKey = 0);
        Task<TEntity> GetBy(Expression<System.Func<TEntity, bool>> predicate);
        Task<bool> Add(TEntity entity);
        Task<bool> Delete(TEntity entity);
        Task<bool> Update(TEntity entity);
    }
}
