using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoneMarket.AccessLayer.Entity;
using StoneMarket.AccessLayer.Context;
using StoneMarket.Core.ViewModels;
using StoneMarket.Core.Interfaces;

namespace StoneMarket.Controllers
{ 
    public class AdminController : Controller
    {
        private StoneMarketContext _db;
        private IAccount _acc;
        private IAdmin _admin;
        public AdminController(StoneMarketContext db, IAccount acc, IAdmin  admin)
        {
            _db = db;
            _acc = acc;
            _admin = admin;
        }
        // GET: AdminController
        public IActionResult Dashboard()
        {

            return View();
        }
        
        public IActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user =  _acc.LoginUser(model.Mobile, model.Password);
                if (user != null) return RedirectToAction(nameof(Dashboard));
            }
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
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(CategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                _admin.InsertCategory(model);
            }
            return View();
        }


        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
