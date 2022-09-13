using Grpc.Net.Client;
using GrpcServer.Contracts;
using Microsoft.AspNetCore.Mvc;
using ProtoBuf.Grpc.Client;

namespace GrpcClient.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7296");
            var client = channel.CreateGrpcService<IProductService>();

            var products = await client.GetAll();
            return View(products);
        }
    }
}
