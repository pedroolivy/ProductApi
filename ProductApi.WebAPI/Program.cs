using ProductApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using ProductApi.Infrastructure.Database;
using ProductApi.Infrastructure.Repositories;
using ProductApi.Application.Interfaces;
using ProductApi.Application.Services;
using ProductApi.Application.Mappings;
using Microsoft.AspNetCore.Authentication;
using ProductApi.WebAPI.Authentication;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
const string stringConnetion = "DefaultConnection";

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

//Configura��o para autentica��o: 
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "basic",
        Description = "Insira o usu�rio e senha no formato Basic (admin:password)"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Basic"
                }
            },
            Array.Empty<string>()
        }
    });
});

//Configura��o para o autoMapper:
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ProductApi.Application.Products.Commands.CreateProductCommand).Assembly));
builder.Services.AddAutoMapper(typeof(ProductProfile));

//Inje��es para o servi�o e o reposit�rio
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

//configura��o para conex�o com banco
builder.Services.AddDbContext<ProductDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString(stringConnetion)));

//Configura��es para a autentica��o
builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();

var port = Environment.GetEnvironmentVariable("PORT") ?? "5238";
app.Urls.Add($"http://0.0.0.0:{port}");

// Aplica as migrations automaticamente no startup (ambiente de produ��o)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ProductDbContext>();
    db.Database.Migrate();
}


app.Run();