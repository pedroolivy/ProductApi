using MediatR;
using AutoMapper;
using ProductApi.Domain.Interfaces;
using ProductApi.Application.Interfaces;
using ProductApi.Application.Dtos;
using ProductApi.Application.Products.Commands;

namespace ProductApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IProductRepository _productRepository;

        public ProductService(
            IMapper mapper, 
            IMediator mediator, 
            IProductRepository rroductRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _productRepository = rroductRepository;
        }

        public Task<ProductDto> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Create(ProductDto productDto)
        {
            var command = _mapper.Map<CreateProductCommand>(productDto);
            return await _mediator.Send(command);
        }

        public Task Update(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(ProductDto productDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllByPage(int pageNumber, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task AddAll(IEnumerable<ProductDto> products)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAll(IEnumerable<ProductDto> products)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAll(IEnumerable<ProductDto> products)
        {
            throw new NotImplementedException();
        }
    }
}
