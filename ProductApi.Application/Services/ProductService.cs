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

        public ProductService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            try
            {
                var products = await _mediator.Send(new GetAllProductsQuery());
                return _mapper.Map<IEnumerable<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao buscar produtos", ex);
            }
        }

        public async Task<ProductDto> GetById(int id)
        {
            try
            {
                var product = await _mediator.Send(new GetProductByIdQuery { Id = id });
                return _mapper.Map<ProductDto>(product);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao buscar produto com ID {id}", ex);
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAllByPage(int pageNumber, int pageSize)
        {
            try
            {
                var products = await _mediator.Send(new GetProductsByPageQuery
                {
                    PageNumber = pageNumber,
                    PageSize = pageSize
                });

                return _mapper.Map<IEnumerable<ProductDto>>(products);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao buscar produtos paginados", ex);
            }
        }

        public async Task<IEnumerable<DashboardDto>> GetDashboard()
        {
            try
            {
                return await _mediator.Send(new DashboardQuery());
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao buscar dados do dashboard", ex);
            }
        }

        public async Task<int> Create(ProductDto productDto)
        {
            try
            {
                var command = _mapper.Map<CreateProductCommand>(productDto);
                return await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao criar produto", ex);
            }
        }

        public async Task Update(ProductDto productDto)
        {
            try
            {
                var command = _mapper.Map<UpdateProductCommand>(productDto);
                await _mediator.Send(command);
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Erro ao atualizar produto", ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _mediator.Send(new DeleteProductCommand { Id = id });
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Erro ao deletar produto com ID {id}", ex);
            }
        }
    }
}
