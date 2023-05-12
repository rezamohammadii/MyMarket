using Microsoft.AspNetCore.Mvc;

namespace StoneMarket.Controllers
{
    public class ProductController : Controller
    {
        [Route("ProductList")]
        public IActionResult ProductList()
        {
            return View();
        }
    }
}
