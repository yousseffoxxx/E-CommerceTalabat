using Services.Specifications;
using Shared.ProductModels;

namespace Services
{
    // C# 12.0 Feature
    class ProductService(IUnitOfWork UnitOfWork , IMapper Mapper) : IProductService
    {
        public async Task<IEnumerable<BrandResultDTO>> GetAllBrandsAsync()
        {
            // 1. Retrieve all Brands => unitOfWork
            var brands = await UnitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();
            // 2. Map to brand Result TDO => IMapper
            var brandsResult = Mapper.Map<IEnumerable<BrandResultDTO>>(brands);
            // 3. Return
            return brandsResult;
        }
        public async Task<PaginatedResult<ProductResultDTO>> GetAllProductsAsync(ProductSpecificationsParameters parameters)
        {
            var products = await UnitOfWork.GetRepository<Product, int>()
                .GetAllAsync(new ProductWithBrandAndTypeSpecifications(parameters));
            var productsResult = Mapper.Map<IEnumerable<ProductResultDTO>>(products);
            var count = productsResult.Count();
            var totalCount = await UnitOfWork.GetRepository<Product, int>()
                .CountAsync(new ProductCountSpecifications(parameters));

            var result = new PaginatedResult<ProductResultDTO>
                (parameters.pageIndex,
                count,
                totalCount,
                productsResult);
            return result;
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

            return product is null ? throw new ProductNotFoundException(id) : productResult;
        }
    }
}
