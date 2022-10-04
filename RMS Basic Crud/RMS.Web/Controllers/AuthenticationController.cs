using Microsoft.AspNetCore.Mvc;

namespace RMS.Web.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
