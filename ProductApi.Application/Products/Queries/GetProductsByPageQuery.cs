using MediatR;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Products.Queries
{
    public class GetProductsByPageQuery : IRequest<IEnumerable<Product>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
