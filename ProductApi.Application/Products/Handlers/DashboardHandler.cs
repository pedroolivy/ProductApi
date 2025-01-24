using MediatR;
using ProductApi.Application.Dtos;
using ProductApi.Domain.Interfaces;
using ProductApi.Application.Products.Queries;

namespace ProductApi.Application.Products.Handlers
{
    public class DashboardHandler : IRequestHandler<DashboardQuery, IEnumerable<DashboardDto>>
    {
        private readonly IProductRepository _productRepository;

        public DashboardHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<DashboardDto>> Handle(DashboardQuery request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetDashboardData();
            return result.Select(r => new DashboardDto
            {
                Type = r.Type,
                TotalQuantity = r.TotalQuantity,
                AveragePrice = r.AveragePrice
            });
        }
    }
}
