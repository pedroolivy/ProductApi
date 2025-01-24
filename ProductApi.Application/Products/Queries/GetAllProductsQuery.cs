using MediatR;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Products.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
