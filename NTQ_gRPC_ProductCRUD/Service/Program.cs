using Microsoft.EntityFrameworkCore;
using Service.Models;
using Service.Repository;
using Service.Repository.Category;
using Service.Repository.Product;
using Service.Repository.ProductDetail;
using Service.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Additional configuration is required to successfully run gRPC on macOS.
// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddDbContext<NTQTRAININGContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("AppDbContext")
    ));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductDetailRepository, ProductDetailRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<CategoryService>();
app.MapGrpcService<ProductService>();
app.MapGrpcService<ProductDetailService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
