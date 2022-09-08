using Grpc.Net.Client;
using GrpcServiceApp;
using Microsoft.AspNetCore.Mvc;

namespace GrpcClient.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProductCRUD.ProductCRUDClient(channel);
            var products = client.GetAll(new Empty());
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, float price, int stock, string description, int color, int size, DateTime dateCreated)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProductCRUD.ProductCRUDClient(channel);

            Empty res = client.Create(new Product()
            {
                 Name = name,
                 Price = price,
                 Stock = stock,
                 Description = description,
                 Color = color,
                 Size = size,
                 DateCreated = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dateCreated, DateTimeKind.Utc))
            });
            return RedirectToAction("Index");
        }
    }
}
