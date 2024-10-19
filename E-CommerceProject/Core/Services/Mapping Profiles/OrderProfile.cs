using AutoMapper;
using Domain.Entities.OrderEntities;
using Shared.OrderModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapping_Profiles
{
    internal class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderAddress,AddressDTO>().ReverseMap();

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(d => d.ProductId,
                options => options.MapFrom(s => s.Product.ProductId))

                .ForMember(d => d.ProductName,
                options => options.MapFrom(s => s.Product.ProductName))
                
                .ForMember(d => d.PictureUrl,
                options => options.MapFrom(s => s.Product.PictureUrl));

            CreateMap<Order, OrderResult>()
                .ForMember(d => d.PaymentStatus,
                options => options.MapFrom(s => s.ToString()))
                
                .ForMember(d => d.DeliveryMethod,
                options => options.MapFrom(s => s.DeliveryMethod.ShortName))
                
                .ForMember(d => d.Total,
                options => options.MapFrom(s => s.SubTotal + s.DeliveryMethod.Price));

            CreateMap<DeliveryMethod, DeliveryMethodResult>();
        }
    }
}
