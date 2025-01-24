using MediatR;
using AutoMapper;
using ProductApi.Application.Dtos;
using ProductApi.Application.Interfaces;
using ProductApi.Application.Products.Queries;
using ProductApi.Application.Products.Commands;

namespace ProductApi.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(
            IMapper mapper, 
            IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var products = await _mediator.Send(new GetAllProductsQuery());
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product =  await _mediator.Send(new GetProductByIdQuery { Id = id});
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllByPage(int pageNumber, int pageSize)
        {
            var products = await _mediator.Send(new GetProductsByPageQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            });

            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<DashboardDto>> GetDashboard()
        {
            return await _mediator.Send(new DashboardQuery());
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
    }
}
