using MediatR;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Interfaces;
using ProductApi.Application.Products.Queries;

namespace ProductApi.Application.Products.Handlers
{
    public class GetProductsByPageHandler : IRequestHandler<GetProductsByPageQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByPageHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsByPageQuery request, CancellationToken cancellationToken)
        {
            if (request.PageNumber < 1 || request.PageSize < 1)
                throw new ArgumentException("Número da página e tamanho devem ser maiores que zero.");

            return await _productRepository.GetAllByPage(request.PageNumber, request.PageSize);
        }
    }
}
