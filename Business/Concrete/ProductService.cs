using Business.Interfaces;
using Core.Models;
using Core.UnitOfWork;
using Data.Interfaces;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }


        public async Task<Response<List<Product>>> GetProducts(Expression<Func<Product, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            return Response<List<Product>>.Success(await _productRepository.GetByFilterWithNoTrackingAsync(filter, cancellationToken), 200);
        }

        public async Task<Response<Product>> AddProduct(Product product, CancellationToken cancellationToken = default)
        {
            var addedData = await _productRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.CommmitAsync(cancellationToken);
            return Response<Product>.Success(addedData, 200);
        }

        public async Task<Response<NoContent>> UpdateProduct(int id, CancellationToken cancellationToken = default)
        {
            var data = await _productRepository.GetByIdAsync(id, cancellationToken);
            data.Name = "Product2";
            _productRepository.Update(data);
            await _unitOfWork.CommmitAsync(cancellationToken);
            return Response<NoContent>.Success(204);
        }
    }
}
