using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoneMarket.AccessLayer.Entity;
using StoneMarket.AccessLayer.Context;
using StoneMarket.Core.ViewModels;
using StoneMarket.Core.Interfaces;
using StoneMarket.Core.Classes;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace StoneMarket.Controllers
{ 
    [Authorize]
    public class AdminController : Controller
    {
        private StoneMarketContext _db;
        private readonly IWebHostEnvironment webHostEnvironment;
        private IAccount _acc;
        private IAdmin _admin;
        public AdminController(StoneMarketContext db, IAccount acc, IAdmin admin, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _acc = acc;
            _admin = admin;
            this.webHostEnvironment = webHostEnvironment;
        }
        // GET: AdminController
        public IActionResult Dashboard()
        
        {

            return View();
        }
       
        public IActionResult Category()
        {
            List<Category> categories = _admin.GetSubCategories();
            if (categories.Count == 0) return View();
            return View(categories);
        }
        public IActionResult AddCategory()
        {
            ViewBag.Ok = false;

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddCategory([FromForm] CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {

                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = CodeFactory.UploadedFile(model.Picture, uploadsFolder);

                _admin.InsertCategory(model, uniqueFileName);

                //  ViewBag.SeoTitle = model.Title;
                ViewBag.Ok = true;
            }
            return View();
        }

        public IActionResult EditCategory(int id)
        {
            Category categorie = _admin.GetCategory(id);
            ViewBag.Ok = false;
            if (categorie == null) return View();
            return View(categorie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = "";
                if (model.Picture != null)
                {
                     uniqueFileName = CodeFactory.UploadedFile(model.Picture, uploadsFolder);

                }

                _admin.InsertCategory(model, uniqueFileName);

                //  ViewBag.SeoTitle = model.Title;
                ViewBag.Ok = true;
                return RedirectToAction(nameof(Category));
            }
           return View(model);
        }


        public IActionResult Products()
        {
            List<Product> products = _admin.GetProducts();
            return View(products);
        }

        public IActionResult AddProduct()
        {

            ViewBag.Ok = false;
            return View();
        }


        [HttpPost]
        public IActionResult AddProduct(ProductViewModel model)
        {

            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            string uniqueFileName = "";
            List<string> paths = new List<string>();
            if (model.Pictures.Count != 0)
            {
                foreach (var item in model.Pictures)
                {
                    uniqueFileName = CodeFactory.UploadedFile(item, uploadsFolder);
                    paths.Add(uniqueFileName);
                }
            }
            _admin.InsertProduct(model, paths);
            ViewBag.Ok = true;
            return View();
        }

        public IActionResult EditProduct(string pCode)
        {
            Product product = _admin.GetProduct(pCode);
            ViewBag.Ok = false;
            if (product == null) return View();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCategory(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                string uniqueFileName = "";
                List<string> paths = new List<string>();
                if (model.Pictures.Count != 0)
                {
                    foreach (var item in model.Pictures)
                    {
                        uniqueFileName = CodeFactory.UploadedFile(item, uploadsFolder);
                        paths.Add(uniqueFileName);
                    }
                }

                _admin.EditProduct(model, paths);

                //  ViewBag.SeoTitle = model.Title;
                ViewBag.Ok = true;
                return RedirectToAction(nameof(Category));
            }
            return View(model);
        }
    }
}
