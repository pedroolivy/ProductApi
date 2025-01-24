using MediatR;
using ProductApi.Domain.Interfaces;
using ProductApi.Domain.Entities;
using ProductApi.Application.Products.Queries;

namespace ProductApi.Application.Products.Handlers
{
    internal class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByIdHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetById(request.Id);

            if(product == null)
                throw new ArgumentException("Produto não encontrado");

            return product;
        }
    }
}
