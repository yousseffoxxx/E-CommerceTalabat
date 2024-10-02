using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstractions
{
    public interface IProductService
    {
        // Get All products
        public Task<IEnumerable<ProductResultDTO>> GetAllProductsAsync(string? sort, int? brandId, int? typeId);
        // Get All Brands
        public Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync();
        // Get All Types
        public Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync();
        // Get Pruduct By Id
        public Task<ProductResultDTO> GetProductByIdAsync(int id);
    }
}