using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class, ITable, new()
    {
        Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<TEntity> GetSingleValueByFilterAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
        Task<List<TEntity>> GetByFilterWithNoTrackingAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default);
        TEntity Update(TEntity entity);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
