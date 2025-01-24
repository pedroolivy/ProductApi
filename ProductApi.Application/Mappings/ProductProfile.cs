using AutoMapper;
using ProductApi.Application.Dtos;
using ProductApi.Application.Products.Commands;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            CreateMap<ProductDto, CreateProductCommand>();
            CreateMap<ProductDto, UpdateProductCommand>();

            CreateMap<Product, ProductDto>()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type)) 
               .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price.Value)) 
               .ReverseMap()
               .ForPath(dest => dest.Price.Value, opt => opt.MapFrom(src => src.Price)); 
        }
    }
}
