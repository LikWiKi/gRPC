using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Client.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var clientProduct = new ProductCRUD.ProductCRUDClient(channel);
            var clientCategory = new CategoryCRUD.CategoryCRUDClient(channel);

            var products = clientProduct.GetAll(new Empty());
            var listOfCategory = clientCategory.GetAll(new Empty()).Items;
            ViewData["DisplayCategory"] = listOfCategory;
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new CategoryCRUD.CategoryCRUDClient(channel);
            var listOfCategory = client.GetAll(new Empty()).Items;
            ViewData["Categories"] = listOfCategory;
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, 
                                    string tagName, 
                                    bool active, 
                                    int categoryId, 
                                    DateTime createDate, 
                                    DateTime updateDate)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new ProductCRUD.ProductCRUDClient(channel);

            client.Create(new Product()
            {
                Name = name,
                TagName = tagName,
                Active = active,
                CategoryId = categoryId,
                CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(createDate, DateTimeKind.Utc)),
                UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(updateDate, DateTimeKind.Utc))
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var clientProduct = new ProductCRUD.ProductCRUDClient(channel);
            var clientCategory = new CategoryCRUD.CategoryCRUDClient(channel);

            var findById = new ProductById();
            findById.Id = Convert.ToInt32(id);
            var product = clientProduct.GetById(findById);

            var listOfCategory = clientCategory.GetAll(new Empty()).Items;
            ViewData["listOfCategory"] = listOfCategory;

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product, DateTime dobCreate, DateTime dobUpdate)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new ProductCRUD.ProductCRUDClient(channel);

            product.CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dobCreate, DateTimeKind.Utc));
            product.UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dobUpdate, DateTimeKind.Utc));
            client.Update(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new ProductCRUD.ProductCRUDClient(channel);
            var product = new ProductById();
            product.Id = Convert.ToInt32(id)
;
            client.Delete(product);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var clientProductDetail = new ProductDetailCRUD.ProductDetailCRUDClient(channel);
            var clientProduct = new ProductCRUD.ProductCRUDClient(channel);

            ViewData["ListOfProduct"] = clientProduct.GetAll(new Empty()).Items;
            ViewData["ProductId"] = int.Parse(id);

            var findById= new ProductDetailById();
            //findById.Id = Convert.ToInt32(id);

            var listOfProductDetail = clientProductDetail.GetAll(new Empty()).Items;
            foreach(var item in listOfProductDetail)
            {
                if(item.ProductId == int.Parse(id))
                {
                    findById.Id = item.Id;
                }
            }
            var productDetail = clientProductDetail.GetById(findById);
            if (productDetail == null)
                return NotFound();

            return View(productDetail);
        }
    }
}
