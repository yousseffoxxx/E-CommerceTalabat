using Domain.Contracts;
using Domain.Entities;

namespace Services.Specifications
{
    public class ProductWithBrandAndTypeSpecifications : Specifications<Product>
    {
        // Use to retrieve Id
        public ProductWithBrandAndTypeSpecifications(int id) 
            : base(product => product.id == id)
        {
            AddInclude(Product => Product.ProductBrand);
            AddInclude(product => product.ProductType);
        }

        // use to get All Products
        public ProductWithBrandAndTypeSpecifications(string? sort, int? brandId, int? typeId)
            : base(product =>
            (!brandId.HasValue || product.BrandId == brandId.Value) &&
            (!typeId.HasValue || product.TypeId == typeId.Value))
        {
            AddInclude(Product => Product.ProductBrand);
            AddInclude(product => product.ProductType);

            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort.ToLower().Trim())
                {
                    case "pricedesc":
                            SetOrderByDescending(p => p.Price);
                        break;
                    case "priceasc":
                            SetOrderBy(p => p.Price);
                        break;
                    case "namedesc":
                            SetOrderByDescending(p => p.Name);
                        break;
                    default:
                        SetOrderBy(p => p.Name);
                        break;
                }
            }
        }
    }
}