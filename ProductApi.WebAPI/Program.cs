using ProductApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProductApi.Infrastructure.Database;
using ProductApi.Infrastructure.Repositories;
using ProductApi.Application.Interfaces;
using ProductApi.Application.Services;
using ProductApi.Application.Mappings;

var builder = WebApplication.CreateBuilder(args);
const string stringConnetion = "DefaultConnection";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductApi.Application.Products.Commands.CreateProductCommand).Assembly));
builder.Services.AddAutoMapper(typeof(ProductProfile));

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString(stringConnetion)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
