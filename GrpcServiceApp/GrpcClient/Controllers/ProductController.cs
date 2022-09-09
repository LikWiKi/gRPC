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

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProductCRUD.ProductCRUDClient(channel);

            var findById = new ProductFilter();
            findById.Id = Convert.ToInt32(id);
            var product = client.GetById(findById);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product, DateTime dob)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProductCRUD.ProductCRUDClient(channel);
            product.DateCreated = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dob, DateTimeKind.Utc));
            client.Update(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProductCRUD.ProductCRUDClient(channel);

            var findById = new ProductFilter();
            findById.Id = Convert.ToInt32(id);
            var product = client.GetById(findById);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new ProductCRUD.ProductCRUDClient(channel);
            var findById = new ProductFilter();
            findById.Id = Convert.ToInt32(product.Id);
            client.Delete(findById);
            return RedirectToAction("Index");
        }
    }
}
