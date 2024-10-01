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
        public ProductWithBrandAndTypeSpecifications() : base(null)
        {
            AddInclude(Product => Product.ProductBrand);
            AddInclude(product => product.ProductType);

        }
    }
}
