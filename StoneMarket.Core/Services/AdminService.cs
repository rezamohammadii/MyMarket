using System;
using System.Collections.Generic;
using System.Text;

using StoneMarket.AccessLayer.Context;
using StoneMarket.AccessLayer.Entity;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using StoneMarket.Core.Interfaces;

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
            Permission permission = _context.Permissions.Find(id);

            _context.Permissions.Remove(permission);
            _context.SaveChanges();
        }



        public List<Store> GetActiveStores()
        {
            return _context.Stores.Include(s => s.User).Where(s => s.MobileActivate == true && s.MailActivate == true).OrderByDescending(s => s.UserId).ToList();
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.Where(c => c.ParentId == null).ToList();
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
            return _context.Categories.FirstOrDefault(c => c.Id == id).ParentId;
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

        public void InsertCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void InsertPermission(Permission permission)
        {
            _context.Permissions.Add(permission);
            _context.SaveChanges();
        }

       

        public void RemoveProduct(int id)
        {
            Product product = _context.Products.Find(id);

            _context.Products.Remove(product);
            _context.SaveChanges();
        }

      

        public void UpdateCategory(int id, string name, string icon)
        {
            Category category = _context.Categories.Find(id);

            category.Name = name;
            category.Icon = icon;

            _context.SaveChanges();
        }

       
        public void UpdatePermission(int id, string name)
        {
            Permission permission = _context.Permissions.Find(id);

            permission.Name = name;

            _context.SaveChanges();
        }

 
        public void UpdateStoreCategory(int id, bool isactive, string desc)
        {
            StoreCategory storeCategory = _context.StoreCategories.Find(id);

            storeCategory.IsActive = isactive;
            storeCategory.Desc = desc;

            _context.SaveChanges();
        }

        public void UpdateSubCategory(int id, int parentid, string name)
        {
            Category category = _context.Categories.Find(id);

            category.Name = name;
            category.ParentId = parentid;

            _context.SaveChanges();
        }
    }
}
