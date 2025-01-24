using ProductApi.Domain.Entities;
using ProductApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProductApi.Infrastructure.Database;

namespace ProductApi.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }

        #region operacoesBasicas

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task Add(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        #endregion

        #region operacoesFormatadas

        public async Task<IEnumerable<Product>> GetAllByPage(int pageNumber, int pageSize)
        {
            return await _context.Products
                .AsNoTracking()
                .OrderBy(p => p.Id)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<(string Type, int TotalQuantity, decimal AveragePrice)>> GetDashboardData()
        {
            var result = await _context.Products
                .GroupBy(p => p.Type)
                .Select(g => new
                {
                    Type = g.Key.ToString(), 
                    TotalQuantity = g.Count(),
                    AveragePrice = g.Average(p => p.Price.Value) 
                })
                .ToListAsync();

            return result.Select(r => (r.Type, r.TotalQuantity, r.AveragePrice));
        }

        //Aqui se encontra métodos que poderiam ser utilizados futuramente
        public async Task AddAll(IEnumerable<Product> products)
        {
            const int batchSize = 1000;

            foreach (var batch in products.Chunk(batchSize))
            {
                await _context.Products.AddRangeAsync(batch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveAll(IEnumerable<Product> products)
        {
            const int batchSize = 1000;

            foreach (var batch in products.Chunk(batchSize))
            {
                _context.Products.RemoveRange(batch);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAll(IEnumerable<Product> products)
        {
            const int batchSize = 1000;

            foreach (var batch in products.Chunk(batchSize))
            {
                _context.Products.UpdateRange(batch);
                await _context.SaveChangesAsync();
            }
        }

        #endregion
    }
}
