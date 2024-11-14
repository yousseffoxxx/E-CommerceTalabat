using Shared.BasketModels;

namespace Services.Mapping_Profiles
{
    internal class BasketProfile : Profile
    {
        public BasketProfile() 
        {
            CreateMap<CustomerBasket , BasketDTO>().ReverseMap();

            CreateMap<BasketItem, BasketItemDTO>().ReverseMap();
        }
    }
}