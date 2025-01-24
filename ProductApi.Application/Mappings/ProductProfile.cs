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
            //Aqui converte dto em command 
            CreateMap<ProductDto, CreateProductCommand>();

            //Aqui faz o inverso 
            CreateMap<Product, ProductDto>()
              .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (int)src.Type))
              .ReverseMap();
        }
    }
}
