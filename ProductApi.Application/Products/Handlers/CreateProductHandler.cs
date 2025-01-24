using MediatR;
using ProductApi.Domain.Enums;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Interfaces;
using ProductApi.Domain.ValueObjects;
using ProductApi.Application.Products.Commands;

namespace ProductApi.Application.Products.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Name,
                (ProductType)request.Type,
                Price.Create(request.Price)
            );

            await _productRepository.Add(product);
            return product.Id;
        }
    }
}
