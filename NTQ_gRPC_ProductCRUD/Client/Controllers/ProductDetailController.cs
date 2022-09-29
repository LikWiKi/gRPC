using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Client.Controllers
{
    public class ProductDetailController : Controller
    {
        public IActionResult Index()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new ProductDetailCRUD.ProductDetailCRUDClient(channel);

            var productDetails = client.GetAll(new Empty());
            return View(productDetails);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new ProductCRUD.ProductCRUDClient(channel);

            var listOfProduct = client.GetAll(new Empty()).Items;
            ViewData["Products"] = listOfProduct;
            return View();
        }

        [HttpPost]
        public IActionResult Create(string price,
                                    string color,
                                    DateTime startingDate,
                                    DateTime closingDate,
                                    string madeBy,
                                    int productId)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new ProductDetailCRUD.ProductDetailCRUDClient(channel);

            client.Create(new ProductDetail()
            {
                Price = price,
                Color = color,
                StartingDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(startingDate, DateTimeKind.Utc)),
                ClosingDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(closingDate, DateTimeKind.Utc)),
                MadeBy = madeBy,
                ProductId = productId,
                CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc)),
                UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc))
            });
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var clientProductDetail = new ProductDetailCRUD.ProductDetailCRUDClient(channel);
            var clientProduct= new ProductCRUD.ProductCRUDClient(channel);

            var productDetail = new ProductDetailById();
            productDetail.Id = Convert.ToInt32(id);
            var productFind = clientProductDetail.GetById(productDetail);

            var listOfProduct = clientProduct.GetAll(new Empty()).Items;
            ViewData["listOfProduct"] = listOfProduct;

            return View(productFind);
        }

        [HttpPost]
        public IActionResult Edit(ProductDetail productDetail, DateTime dobCreate, DateTime dobUpdate, DateTime dobStart, DateTime dobClose)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new ProductDetailCRUD.ProductDetailCRUDClient(channel);

            productDetail.StartingDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dobStart, DateTimeKind.Utc));
            productDetail.ClosingDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dobClose, DateTimeKind.Utc));

            productDetail.CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dobCreate, DateTimeKind.Utc));
            productDetail.UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dobUpdate, DateTimeKind.Utc));
            client.Update(productDetail);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new ProductDetailCRUD.ProductDetailCRUDClient(channel);
            var productDetail = new ProductDetailById();
            productDetail.Id = Convert.ToInt32(id)
;
            client.Delete(productDetail);
            return RedirectToAction("Index");
        }
    }
}
