using Microsoft.AspNetCore.Mvc;

namespace StoneMarket.Controllers
{
    public class ProductController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
