using AutoMapper;
using Domain.Contracts;
using Domain.Entities;
using Services.Abstractions;
using Services.Specifications;
using Shared;

namespace Services
{
    // C# 12.0 Feature
    class ProductService(IUnitOfWork UnitOfWork , IMapper Mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync()
        {
            // 1. Retrieve all Brands => unitofwork
            var brands = await UnitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            // 2. Map to brand Result TDO => IMapper
            var brandsResult = Mapper.Map<IEnumerable<BrandResultDTO>>(brands);
            // 3. Return
            return brandsResult;
        }
        public async Task<IEnumerable<ProductResultDTO>> GetAllProductsAsync(string? sort, int? brandId, int? typeId)
        {
            var products = await UnitOfWork.GetRepository<Product, int>()
                .GetAllAsync(new ProductWithBrandAndTypeSpecifications(sort, brandId, typeId));
            var productsResult = Mapper.Map<IEnumerable<ProductResultDTO>>(products);
            return productsResult;
        }
        public async Task<IEnumerable<TypeResultDTO>> GetAllTypesAsync()
        {
            var types = await UnitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var typesResult = Mapper.Map<IEnumerable<TypeResultDTO>>(types);
            return typesResult;
        }
        public async Task<ProductResultDTO> GetProductByIdAsync(int id)
        {
            var product = await UnitOfWork.GetRepository<Product, int>()
                .GetAsync(new ProductWithBrandAndTypeSpecifications(id));
            var productResult = Mapper.Map<ProductResultDTO>(product);
            return productResult;
        }
    }
}
