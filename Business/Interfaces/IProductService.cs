using Core.Models;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<Response<List<ProductListDto>>> GetProducts(Expression<Func<Product, bool>> filter = null, CancellationToken cancellationToken = default);
        Task<Response<ProductListDto>> AddProduct(ProductAddDto productDto, CancellationToken cancellationToken = default);
        Task<Response<NoContent>> UpdateProduct(ProductUpdateDto productDto, CancellationToken cancellationToken = default);
        Task<Response<NoContent>> DeleteProduct(int id, CancellationToken cancellationToken = default);
    }
}
