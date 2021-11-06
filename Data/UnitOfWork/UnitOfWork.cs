using Core.Models;
using Core.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public UnitOfWork(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public void Commit()
        {
            var now = DateTimeOffset.Now;
            var userId = 101;
            _context.ChangeTracker.Entries().ToList().ForEach(x =>
            {
                if (x.Entity is IDbObject entity)
                {
                    switch (x.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.Creator = userId;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedDate = now;
                            entity.Modifier = userId;
                            break;
                        default:
                            break;
                    }
                }
            });

            _context.SaveChanges();
        }

        public async Task CommmitAsync(CancellationToken cancellationToken = default)
        {
            var now = DateTimeOffset.Now;
            var userId = 101;
            _context.ChangeTracker.Entries().ToList().ForEach(x =>
            {
                if (x.Entity is IDbObject entity)
                {
                    switch (x.State)
                    {
                        case EntityState.Added:
                            entity.CreatedDate = now;
                            entity.Creator = userId;
                            break;
                        case EntityState.Modified:
                            entity.ModifiedDate = now;
                            entity.Modifier = userId;
                            break;
                        default:
                            break;
                    }
                }
            });

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
