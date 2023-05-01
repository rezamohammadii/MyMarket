using Microsoft.AspNetCore.Mvc;

namespace StoneMarket.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
