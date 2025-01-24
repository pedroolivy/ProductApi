using MediatR;
using ProductApi.Domain.Entities;

namespace ProductApi.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
