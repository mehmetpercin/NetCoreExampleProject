using Business.Interfaces;
using Core.Extentions;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await _productService.GetProducts(cancellationToken: cancellationToken));
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductAddDto productDto, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await _productService.AddProduct(productDto, cancellationToken: cancellationToken));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto productDto, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await _productService.UpdateProduct(productDto, cancellationToken: cancellationToken));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken = default)
        {
            return CreateActionResultInstance(await _productService.DeleteProduct(id, cancellationToken: cancellationToken));
        }
    }
}
