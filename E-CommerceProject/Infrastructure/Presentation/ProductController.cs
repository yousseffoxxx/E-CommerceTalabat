using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Shared;
using Shared.ErrorModels;
using System.Net;
namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductsController(IServiceManager ServiceManager) : ApiController
    {
        [HttpGet]
        public async Task<ActionResult<PaginatedResult<ProductResultDTO>>> GetAllProducts([FromQuery]ProductSpecificationsParameters parameters)
        {
            var products = await ServiceManager.ProductService.GetAllProductsAsync(parameters);
            return Ok(products);
        }
        
        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDTO>>> GetAllBrands()
        {
            var brands = await ServiceManager.ProductService.GetAllBrandsAsync();
            return Ok(brands);
        }
        
        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResultDTO>>> GetAllTypes()
        {
            var types = await ServiceManager.ProductService.GetAllTypesAsync();
            return Ok(types);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductResultDTO>> GetProduct(int id)
        {
            var product = await ServiceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }
    }
}