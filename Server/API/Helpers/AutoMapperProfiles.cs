using API.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.OrderAggregate;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(b => b.ProductBrand, opt => opt.MapFrom(p => p.ProductBrand.Name))
                .ForMember(b => b.ProductType, opt => opt.MapFrom(p => p.ProductType.Name))
                .ForMember(b => b.PictureUrl, opt => opt.MapFrom<ProductUrlResolver>());

            CreateMap<Core.Entities.Identity.Address, AddressDto>().ReverseMap();
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>();
            CreateMap<AddressDto, Core.Entities.OrderAggregate.Address >();
            
            CreateMap<Order, OrderToReturnDto>()
                .ForMember(d=>d.DeliveryMethod, o=>o.MapFrom(o=>o.DeliveryMethod.ShortName))
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(o => o.DeliveryMethod.Price));
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.Id, i => i.MapFrom(o => o.ItemOrdered.ProductItemId))
                .ForMember(d => d.ProductName, o => o.MapFrom(o => o.ItemOrdered.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(o => o.ItemOrdered.ProductUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemUrlResolver>());
        }
    }
}
