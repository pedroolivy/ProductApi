using MediatR;

namespace ProductApi.Application.Products.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public decimal Price { get; set; }
    }
}
