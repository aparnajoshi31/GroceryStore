using API.Dtos;
using AutoMapper;
using Core.Entities;
using API.Helpers;


namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
            .ForMember(d=>d.ProductCategory, o=> o.MapFrom(s=>s.ProductCategory.Name))
            .ForMember(d =>d.ImageUrl, o =>o.MapFrom<ImageUrlResolver>());
        }
    }
}