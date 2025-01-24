using MediatR;
using ProductApi.Domain.Interfaces;
using ProductApi.Application.Products.Commands;

namespace ProductApi.Application.Products.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);

            if (product == null)
                throw new ArgumentException("Produto não encontrado.");

            await _productRepository.Delete(product);
        }
    }
}
