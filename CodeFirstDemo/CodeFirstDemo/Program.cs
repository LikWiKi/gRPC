using GrpcServer.Data;
using GrpcServer.Service;
using Microsoft.EntityFrameworkCore;
using ProtoBuf.Grpc.Server;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("AppDbContext")
    ));
builder.Services.AddCodeFirstGrpc();

var app = builder.Build();

app.MapGrpcService<ProductService>();
app.MapGet("/", () => "Hello World!");

app.Run();
