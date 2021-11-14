using Core.Models;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductService
    {
        Task<Response<List<ProductListDto>>> GetProducts(CancellationToken cancellationToken = default);
        Task<Response<ProductListDto>> AddProduct(ProductAddDto productDto, CancellationToken cancellationToken = default);
        Task<Response<NoContent>> UpdateProduct(ProductUpdateDto productDto, CancellationToken cancellationToken = default);
        Task<Response<NoContent>> DeleteProduct(int id, CancellationToken cancellationToken = default);
    }
}
