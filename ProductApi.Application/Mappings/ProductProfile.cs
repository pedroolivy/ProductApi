using AutoMapper;
using ProductApi.Application.Dtos;
using ProductApi.Application.Products.Commands;
using ProductApi.Domain.Entities;
using ProductApi.Domain.ValueObjects;

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
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => Price.Create(src.Price)));
        }
    }
}
