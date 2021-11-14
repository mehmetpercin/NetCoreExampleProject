using Core.Models;
using Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, ITable, new()
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return (await _dbSet.AddAsync(entity, cancellationToken)).Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddRangeAsync(entities, cancellationToken);
        }

        public async Task<List<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            return filter == null ? await _dbSet.ToListAsync(cancellationToken) : await _dbSet.Where(filter).ToListAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetByFilterWithNoTrackingAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            return filter == null ? await _dbSet.AsNoTracking().ToListAsync(cancellationToken) : await _dbSet.AsNoTracking().Where(filter).ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        public async Task<TEntity> GetSingleValueByFilterAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _dbSet.SingleOrDefaultAsync(filter, cancellationToken);
        }

        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
