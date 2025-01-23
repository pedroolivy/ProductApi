using ProductApi.Domain.Entities;

namespace ProductApi.Domain.Interfaces
{
    public interface IProductRepository
    {
        
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetAll();
        Task AddAll(IEnumerable<Product> products);
        Task RemoveAll(IEnumerable<Product> products);
        Task UpdateAll(IEnumerable<Product> products);
        Task<IEnumerable<Product>> GetAllByPage(int pageNumber, int pageSize);
    }
}