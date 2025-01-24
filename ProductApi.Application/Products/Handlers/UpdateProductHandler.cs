using MediatR;
using ProductApi.Domain.Interfaces;
using ProductApi.Domain.ValueObjects;
using ProductApi.Application.Products.Commands;

namespace ProductApi.Application.Products.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);

            if (product == null)
                throw new ArgumentException("Produto não encontrado");

            product.Update(
                request.Name,
                (Domain.Enums.ProductType)request.Type,
                Price.Create(request.Price)
            );

            await _productRepository.Update(product);
        }
    }
}
