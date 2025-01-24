using Moq;
using ProductApi.Application.Dtos;
using ProductApi.Application.Products.Queries;
using ProductApi.Application.Services;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Enums;
using ProductApi.Domain.Interfaces;
using ProductApi.Domain.ValueObjects;

namespace ProductApi.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<MediatR.IMediator> _mockMediator;
        private readonly ProductService _service;

        public ProductServiceTests()
        {
            _mockMediator = new Mock<MediatR.IMediator>();
            var mockMapper = new Mock<AutoMapper.IMapper>();
            mockMapper.Setup(mapper => mapper.Map<ProductDto>(It.IsAny<Product>()))
                      .Returns((Product src) => new ProductDto
                      {
                          Id = src.Id,
                          Name = src.Name,
                          Price = src.Price.Value,
                          Type = (int)src.Type
                      });

            _service = new ProductService(mockMapper.Object, _mockMediator.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnProduct_WhenProductExists()
        {
            var productId = 1;
            var product = CreateProduct(productId, "Test Product", ProductType.Material, 100.50m);

            _mockMediator
                .Setup(mediator => mediator.Send(It.IsAny<GetProductByIdQuery>(), default))
                .ReturnsAsync(product);

            var result = await _service.GetById(productId);

            Assert.NotNull(result);
            Assert.Equal(productId, result.Id);
            Assert.Equal("Test Product", result.Name);
            Assert.Equal(100.50m, result.Price);
            Assert.Equal((int)ProductType.Material, result.Type);
        }

        

        private Product CreateProduct(int id, string name, ProductType type, decimal priceValue)
        {
            var price = Price.Create(priceValue);
            var product = new Product(name, type, price);
            typeof(Product).GetProperty("Id").SetValue(product, id);

            return product;
        }
    }
}
