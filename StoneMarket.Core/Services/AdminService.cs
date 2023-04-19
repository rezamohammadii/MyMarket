using System;
using System.Collections.Generic;
using System.Text;

using StoneMarket.AccessLayer.Context;
using StoneMarket.AccessLayer.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using StoneMarket.Core.Interfaces;
using StoneMarket.Core.ViewModels;
using StoneMarket.Core.Classes;

namespace StoneMarket.Core.Services
{
    public class AdminService : IAdmin
    {
        private StoneMarketContext _context;

        public AdminService(StoneMarketContext context)
        {
            _context = context;
        }
        public bool ExistsSetting()
        {
            Setting setting = _context.Settings.FirstOrDefault()!;

            if (setting == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Setting GetSetting()
        {
            return _context.Settings.FirstOrDefault();
        }
        public void InsertSetting(Setting setting)
        {
            _context.Settings.Add(setting);
            _context.SaveChanges();
        }
        public void UpdateSetting(string name, string desc, string keys, string api, string sender, string mail, string password)
        {
            Setting setting = _context.Settings.FirstOrDefault()!;

            setting.SiteName = name;
            setting.SiteDesc = desc;
            setting.SiteKeys = keys;
            setting.SmsApi = api;
            setting.SmsSender = sender;
            setting.MailAddress = mail;
            setting.MailPassword = password;

            _context.SaveChanges();
        }
        public void DeleteCategory(int id)
        {
            Category category = _context.Categories.Find(id)!;

            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

       
        public void DeletePermission(int id)
        {
            Permission permission = _context.Permissions.Find(id)!;

            _context.Permissions.Remove(permission);
            _context.SaveChanges();
        }


        public List<Category> GetCategories()
        {
            try
            {
                return _context.Categories.Where(c => c.ParentId == null).ToList();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw;
            }
            
        }

        public List<Category> GetCategoriesByParentId(int id)
        {
            return _context.Categories.Include(c => c.Parent).Where(c => c.ParentId == id).ToList();
        }

        public Category GetCategory(int id)
        {
            return _context.Categories.Include(c => c.Parent).FirstOrDefault(c => c.Id == id);
        }

        public int? GetCategoryParentId(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id)!.ParentId;
        }
        public int? GetCategoryParentId(string Name)
        {
            return _context.Categories.FirstOrDefault(c => c.Name == Name)!.ParentId;
        }

        public Permission GetPermission(int id)
        {
            return _context.Permissions.Find(id);
        }

        public List<Permission> GetPermissions()
        {
            return _context.Permissions.OrderBy(p => p.Name).ToList();
        }


        public List<Category> GetSubCategories()
        {
            return _context.Categories.ToList();
        }

        public void InsertCategory(CategoryViewModel category, string uniqueFileName)
        {

            Category getCategory = GetCategory(category.Id);

            if (getCategory != null)
            {
                getCategory.Picture = uniqueFileName;
                getCategory.Name = category.Name;
                getCategory.ParentId = int.Parse(category.ParentId!);
                getCategory.Description = category.Description;
                getCategory.MoreDescription = category.MoreDescription;
                getCategory.SeoDescrption = category.SeoDescrption;
                getCategory.SeoTitle = category.SeoTitle;
                getCategory.Title = category.Title;
            }
            else
            {
                Category cat = new Category()
                {
                    Picture = uniqueFileName,
                    Name = category.Name,
                    ParentId = int.Parse(category.ParentId!),
                    Description = category.Description,
                    MoreDescription = category.MoreDescription,
                    SeoDescrption = category.SeoDescrption,
                    SeoTitle = category.SeoTitle,
                    Title = category.Title,
                };
                _context.Categories.Add(cat);
            }
            _context.SaveChanges();
        }

        public void InsertPermission(Permission permission)
        {
            _context.Permissions.Add(permission);
            _context.SaveChanges();
        }

      
        public void UpdateCategory(CategoryViewModel model)
        {

            //category.Name = model.Name;
            //category.Picture = uniqueFileName;

            //_context.SaveChanges();
        }

       
        public void UpdatePermission(int id, string name)
        {
            Permission permission = _context.Permissions.Find(id)!;

            permission.Name = name;

            _context.SaveChanges();
        }

        public void UpdateSubCategory(int id, int parentid, string name)
        {
            Category category = _context.Categories.Find(id)!;

            category.Name = name;
            category.ParentId = parentid;

            _context.SaveChanges();
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Include(c=>c.Category).ToList();
        }

        public void InsertProduct(ProductViewModel model, List<string> paths)
        {
            Product product = new Product();
            product.BrandId = model.BrandId;
            product.SeoTitle = model.SeoTitle;
            product.DeletePrice = model.DeletePrice;
            product.Name = model.Name;
            product.Color = model.Color;
            product.CategoryId = model.CategoryId;
            product.Date = CodeFactory.PersianDate();
            product.Description = model.Description;
            product.Weight = model.Weight;
            product.Size = model.Size;
            product.Price = model.Price;
            product.NotShow = model.NotShow;
            product.SeoDescrption = model.SeoDescrption;
            product.Material = model.Material;
            product.ProductCode = CodeFactory.RandomString();

            foreach (var item in paths)
            {
                ProductGallery productGallery = new ProductGallery();
                productGallery.ProductCode = product.ProductCode;
                productGallery.Img = item;
                _context.ProductGalleries.Add(productGallery);
            }
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public bool EditProduct(ProductViewModel model, List<string> paths)
        {
            try
            {
                var product = _context.Products.Include(p => p.ProductGalleries).Where(p => p.ProductCode == model.ProductCode).SingleOrDefault();
                product.BrandId = model.BrandId;
                product.SeoTitle = model.SeoTitle;
                product.DeletePrice = model.DeletePrice;
                product.Name = model.Name;
                product.Color = model.Color;
                product.CategoryId = model.CategoryId;
                product.Date = CodeFactory.PersianDate();
                product.Description = model.Description;
                product.Weight = model.Weight;
                product.Size = model.Size;
                product.Price = model.Price;
                product.NotShow = model.NotShow;
                product.SeoDescrption = model.SeoDescrption;
                product.Material = model.Material;
                product.ProductCode = CodeFactory.RandomString();

                foreach (var item in product.ProductGalleries!)
                {
                    foreach (var path in paths)
                    {
                        item.Img = path;
                    }
                }
                _context.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
            
        }

        public void DeleteProduct(string pcdoe)
        {

            Product product = _context.Products.Find(pcdoe)!;

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public Product GetProduct(string pCode)
        {
            var product =  _context.Products.Where(x => x.ProductCode == pCode).Include(x => x.ProductGalleries).SingleOrDefault();
            var productPic = _context.ProductGalleries.Where(x => x.ProductCode == pCode).ToList();
            product!.ProductGalleries = productPic;
            return product;
        }

        public List<Redirection> Redirections()
        {
            return _context.Redirections.ToList();
        }
    }
}
