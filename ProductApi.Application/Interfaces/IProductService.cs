using ProductApi.Application.Dtos;

namespace ProductApi.Application.Interfaces
{
    public interface IProductService
    {
        Task Delete(int id);
        Task<ProductDto> GetById(int id);
        Task Update(ProductDto productDto);
        Task<IEnumerable<ProductDto>> GetAll();
        Task<int> Create(ProductDto productDto);
        Task<IEnumerable<DashboardDto>> GetDashboard();
        Task<IEnumerable<ProductDto>> GetAllByPage(int pageNumber, int pageSize);
    }
}
