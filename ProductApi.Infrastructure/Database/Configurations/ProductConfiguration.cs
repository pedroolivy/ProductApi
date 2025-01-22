using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductApi.Domain.Entities;
using ProductApi.Domain.Enums;

namespace ProductApi.Infrastructure.Database.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(p => p.Type)
                .IsRequired()
                .HasConversion(
                    type => type.ToString(), 
                    type => Enum.Parse<ProductType>(type)); 

            builder.OwnsOne(p => p.Price, price =>
            {
                price.Property(p => p.Value)
                     .IsRequired()
                     .HasColumnName("Price")
                     .HasColumnType("decimal(18,2)");
            });
        }
    }
}
