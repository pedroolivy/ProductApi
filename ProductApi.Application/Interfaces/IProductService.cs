using ProductApi.Application.Dtos;

namespace ProductApi.Application.Interfaces
{
    public interface IProductService
    {
        Task<int> Create(ProductDto productDto);
        Task Update(ProductDto productDto);
        Task Delete(int id);
        Task<ProductDto> GetById(int id);
        Task<IEnumerable<ProductDto>> GetAll();
        Task AddAll(IEnumerable<ProductDto> products);
        Task UpdateAll(IEnumerable<ProductDto> products);
        Task RemoveAll(IEnumerable<ProductDto> products);
        Task<IEnumerable<ProductDto>> GetAllByPage(int pageNumber, int pageSize);
    }
}
