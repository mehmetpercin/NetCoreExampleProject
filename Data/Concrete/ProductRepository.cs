using Data.Interfaces;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Data.Concrete
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Product>> GetProductsByCreator(int creatorId, CancellationToken cancellationToken)
        {
            return await _context.Products.Where(x => x.Creator == creatorId).ToListAsync(cancellationToken);
        }
    }
}
