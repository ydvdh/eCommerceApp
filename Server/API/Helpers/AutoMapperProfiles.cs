using API.DTOs;
using AutoMapper;
using Core.Entities;

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
        }
    }
}
