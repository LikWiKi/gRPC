using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Service;

namespace Client.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new CategoryCRUD.CategoryCRUDClient(channel);
            var categories = client.GetAll(new Empty());
            if (TempData["result"] != null)
            {
                ViewBag.SuccessMsg = TempData["result"];
            }
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, string tagName, bool active, DateTime createDate, DateTime updateDate)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new CategoryCRUD.CategoryCRUDClient(channel);

            client.Create(new Category()
            {
                Name = name,
                TagName = tagName,
                Active = active,
                CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(createDate, DateTimeKind.Utc)),
                UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(updateDate, DateTimeKind.Utc))
            });
            TempData["result"] = "Add category success!!!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new CategoryCRUD.CategoryCRUDClient(channel);

            var findById = new CategoryById();
            findById.Id = Convert.ToInt32(id);
            var category = client.GetById(findById);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category, DateTime dobCreate, DateTime dobUpdate)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new CategoryCRUD.CategoryCRUDClient(channel);

            category.CreatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dobCreate, DateTimeKind.Utc));
            category.UpdatedDate = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(DateTime.SpecifyKind(dobUpdate, DateTimeKind.Utc));
            client.Update(category);
            TempData["result"] = "Edit category success!!!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new CategoryCRUD.CategoryCRUDClient(channel);
            var category = new CategoryById();
            category.Id = Convert.ToInt32(id);

            var totalOfCategoryBefore = client.GetAll(new Empty { });
            client.Delete(category);
            var totalOfCategoryLater = client.GetAll(new Empty { });
            if(totalOfCategoryLater.Items.Count == totalOfCategoryBefore.Items.Count)
            {
                TempData["result"] = "Can not delete this category because this category contains the product!!!";
                return RedirectToAction("Index");
            }

            TempData["result"] = "Delete category success!!!";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(string id)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:7092");
            var client = new CategoryCRUD.CategoryCRUDClient(channel);
            var category = new CategoryById();
            category.Id = Convert.ToInt32(id);
            var listOfProduct = client.GetAllProductByCategoryId(category);

            var listOfCategory = client.GetAll(new Empty()).Items;
            if(listOfProduct.Items.Count == 0)
            {
                TempData["result"] = "No products in category!!!";
                return RedirectToAction("Index");
            }
            ViewData["Categories"] = listOfCategory;
            ViewData["CategoryId"] = int.Parse(id);

            return View(listOfProduct);
        }
    }
}
