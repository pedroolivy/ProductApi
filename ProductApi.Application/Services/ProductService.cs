using MediatR;
using AutoMapper;
using ProductApi.Domain.Interfaces;
using ProductApi.Application.Interfaces;
using ProductApi.Application.Dtos;
using ProductApi.Application.Products.Commands;
using ProductApi.Application.Products.Queries;

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
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _productRepository = productRepository; 
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product =  await _mediator.Send(new GetProductByIdQuery { Id = id});
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<int> Create(ProductDto productDto)
        {
            var command = _mapper.Map<CreateProductCommand>(productDto);
            return await _mediator.Send(command);
        }

        public async Task Update(ProductDto productDto)
        {
            var command = _mapper.Map<UpdateProductCommand>(productDto);
            await _mediator.Send(command);
        }

        public async Task Delete(int id)
        {
            await _mediator.Send(new DeleteProductCommand { Id = id });
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
