using Grpc.Core;
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

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
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

            TempData["result"] = "Add product success!!!";

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
            try
            {
                var channel = GrpcChannel.ForAddress("https://localhost:7092");
                var client = new ProductCRUD.ProductCRUDClient(channel);

                product.CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dobCreate, DateTimeKind.Utc));
                product.UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dobUpdate, DateTimeKind.Utc));
                client.Update(product);
            }
            catch (Exception)
            {
                TempData["result"] = "Edit product failed. Please try again!!!";
                return RedirectToAction("Index");
            }
            TempData["result"] = "Edit product success!!!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new ProductCRUD.ProductCRUDClient(channel);
            var product = new ProductById();
            product.Id = Convert.ToInt32(id);
            client.Delete(product);
            TempData["result"] = "Delete product success!!!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var clientProduct = new ProductCRUD.ProductCRUDClient(channel);

            var productDetail = new ProductById();
            productDetail.Id = Convert.ToInt32(id);
            var listOfProductDetail = clientProduct.GetAllProductDetailByProductId(productDetail);
            var listOfProduct = clientProduct.GetAll(new Empty { }).Items;

            var findById = new ProductById();
            findById.Id = Convert.ToInt32(id);
            var product = clientProduct.GetById(findById);

            if (listOfProductDetail.Items.Count == 0)
            {
                TempData["result"] = "No product detail in product!!!";
                return RedirectToAction("Index");
            }
            ViewData["Product"] = product;
            ViewData["Products"] = listOfProduct;
            ViewData["ProductId"] = int.Parse(id);

            return View(listOfProductDetail);
        }
    }
}
