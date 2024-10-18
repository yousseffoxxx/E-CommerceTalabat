using Domain.Contracts;
using Domain.Entities.ProductEntities;
using Shared;

namespace Services.Specifications
{
    public class ProductWithBrandAndTypeSpecifications : Specifications<Product>
    {
        // Use to retrieve Id
        public ProductWithBrandAndTypeSpecifications(int id) 
            : base(product => product.Id == id)
        {
            AddInclude(Product => Product.ProductBrand);
            AddInclude(product => product.ProductType);
        }

        // use to get All Products
        public ProductWithBrandAndTypeSpecifications(ProductSpecificationsParameters parameters)
            : base(product =>
            (!parameters.BrandId.HasValue || product.BrandId == parameters.BrandId.Value) &&
            (!parameters.TypeId.HasValue || product.TypeId == parameters.TypeId.Value) &&
            (string.IsNullOrWhiteSpace(parameters.Search) || product.Name.ToLower().Contains(parameters.Search.ToLower().Trim())))
        {
            AddInclude(Product => Product.ProductBrand);
            AddInclude(product => product.ProductType);

            ApplyPagination(parameters.pageIndex , parameters.pageSize);

            if (parameters.Sort is not null)
            {
                switch (parameters.Sort)
                {
                    case ProductSortingOptions.NameDesc:
                            SetOrderByDescending(p => p.Name);
                        break;
                    case ProductSortingOptions.NameAsc:
                            SetOrderBy(p => p.Name);
                        break;
                    case ProductSortingOptions.PriceDesc:
                            SetOrderByDescending(p => p.Price);
                        break;
                    case ProductSortingOptions.PriceAsc:
                            SetOrderBy(p => p.Price);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}