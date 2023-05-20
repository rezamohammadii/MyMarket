using Microsoft.AspNetCore.Mvc;

namespace StoneMarket.Controllers
{
    public class ProductController : Controller
    {

        [Route("product-list/{id}")]
        public IActionResult ProductList(int id)
        {
            return View();
        }
    }
}
