using Core.Models;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<Response<List<Product>>> GetProducts(Expression<Func<Product, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<Response<Product>> AddProduct(Product product, CancellationToken cancellationToken = default);
        Task<Response<NoContent>> UpdateProduct(int id, CancellationToken cancellationToken = default);
    }
}
