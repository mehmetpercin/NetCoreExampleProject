using AutoMapper;
using Business.Interfaces;
using Core.Models;
using Core.UnitOfWork;
using Data.Interfaces;
using Entities.Concrete;
using Entities.Dtos;
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
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _mapper = mapper;
        }


        public async Task<Response<List<ProductListDto>>> GetProducts(Expression<Func<Product, bool>> filter = null, CancellationToken cancellationToken = default)
        {
            var products = await _productRepository.GetByFilterWithNoTrackingAsync(filter, cancellationToken);
            var result = _mapper.Map<List<ProductListDto>>(products);
            return Response<List<ProductListDto>>.Success(result, 200);
        }

        public async Task<Response<ProductListDto>> AddProduct(ProductAddDto productDto, CancellationToken cancellationToken = default)
        {
            var product = _mapper.Map<Product>(productDto);
            var addedData = await _productRepository.AddAsync(product, cancellationToken);
            await _unitOfWork.CommmitAsync(cancellationToken);

            var result = _mapper.Map<ProductListDto>(addedData);
            return Response<ProductListDto>.Success(result, 201);
        }

        public async Task<Response<NoContent>> UpdateProduct(ProductUpdateDto productDto, CancellationToken cancellationToken = default)
        {
            var data = await _productRepository.GetByIdAsync(productDto.Id, cancellationToken);
            if (data == null)
                return Response<NoContent>.Fail("Data Not Found", 404);

            _mapper.Map(productDto, data);
            _productRepository.Update(data);
            await _unitOfWork.CommmitAsync(cancellationToken);
            return Response<NoContent>.Success(200);
        }

        public async Task<Response<NoContent>> DeleteProduct(int id, CancellationToken cancellationToken = default)
        {
            var data = await _productRepository.GetByIdAsync(id, cancellationToken);
            if (data == null)
                return Response<NoContent>.Fail("Data Not Found", 404);
            _productRepository.Remove(data);
            await _unitOfWork.CommmitAsync(cancellationToken);
            return Response<NoContent>.Success(200);
        }
    }
}
