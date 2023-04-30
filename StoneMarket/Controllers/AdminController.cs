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

        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {

            _admin.DeleteCategory(id);

            //  ViewBag.SeoTitle = model.Title;
            ViewBag.Ok = true;
            return RedirectToAction(nameof(Category));           
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
            Console.WriteLine(product.ProductGalleries.Count());
            ViewBag.Ok = false;
            if (product == null) return View();
            return View(product);
        }

        [HttpPost]
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

        [HttpPost]
        public IActionResult DeleteProduct(string pCode)
        {
            _admin.DeleteProduct(pCode);
            ViewBag.Ok = true;
            return RedirectToAction(nameof(Products));
        }

        [HttpPost]
        public bool DeletePicture(List<int> id)
        {
            return true;
        }

        public IActionResult Redirection()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Redirection(Redirection redirection)
        {
            _db.Redirections.Add(redirection);
            _db.SaveChanges();
            return RedirectToAction(nameof(Redirection));
        }

        public IActionResult DeleteRedirection(int id)
        {

            var row = _db.Redirections.Find(id);
            if (row == null) return BadRequest();

            _db.Redirections.Remove(row);
            _db.SaveChanges();

            ViewBag.Ok = true;
            return RedirectToAction(nameof(Redirection));
        }


        public IActionResult UploaderImage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploaderImage(UploaderViewModel model)
        {

            string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
            Console.WriteLine(uploadsFolder);
            string uniqueFileName = CodeFactory.UploadedFile(model.Picture, uploadsFolder);
            Uploader uploader = new Uploader();
            uploader.Name = model.Name;
            uploader.ImgAddress = uniqueFileName;
            _db.Uploaders.Add(uploader);
            _db.SaveChanges();
            return RedirectToAction(nameof(UploaderImage));
        }
    }
}
