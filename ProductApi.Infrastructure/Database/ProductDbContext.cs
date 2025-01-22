using Microsoft.EntityFrameworkCore;
using ProductApi.Domain.Entities;

namespace ProductApi.Infrastructure.Database
{
    public class ProductDbContext : DbContext
    {
        protected ProductDbContext() { }

        public DbSet<Product> Products { get; set; }
    }
}
