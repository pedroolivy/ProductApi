using MediatR;

namespace ProductApi.Application.Products.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Type { get; set; }
        public decimal Price { get; set; }
    }
}
