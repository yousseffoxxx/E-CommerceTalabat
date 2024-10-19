namespace Services.Mapping_Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResultDTO>()
                .ForMember(d => d.BrandName, options => options
                    .MapFrom(s => s.ProductBrand.Name))
                .ForMember(d => d.TypeName, options => options
                    .MapFrom(s => s.ProductType.Name))
                .ForMember(d => d.PictureUrl, options => options
                    .MapFrom<PictureUrlResolver>());

            CreateMap<ProductBrand , BrandResultDTO>();
            CreateMap<ProductType , TypeResultDTO>();
        }
    }
}
