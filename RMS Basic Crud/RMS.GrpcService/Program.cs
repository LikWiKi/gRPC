using Microsoft.EntityFrameworkCore;
using RMS.GrpcService.Context;
using RMS.GrpcService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGrpcService<UserService>();

app.MapGet("/", () => "Welcome to RMS");

app.Run();
