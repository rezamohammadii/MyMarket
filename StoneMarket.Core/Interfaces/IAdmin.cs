using System;
using System.Collections.Generic;
using System.Text;

using StoneMarket.AccessLayer.Entity;
using StoneMarket.Core.ViewModels;

namespace StoneMarket.Core.Interfaces
{
    public interface IAdmin
    {

        #region For Setting

        void InsertSetting(Setting setting);

        void UpdateSetting(string name, string desc, string keys, string api, string sender, string mail, string password);

        bool ExistsSetting();

        Setting GetSetting();

        List<Redirection> Redirections();

        #endregion
        #region For Permission

        void InsertPermission(Permission permission);

        void UpdatePermission(int id, string name);

        void DeletePermission(int id);

        List<Permission> GetPermissions();

        Permission GetPermission(int id);

        #endregion

        #region Category

        void InsertCategory(CategoryViewModel category, string uniqueFileName);

        void UpdateCategory(CategoryViewModel category);

        void UpdateSubCategory(int id, int parentid, string name);

        void DeleteCategory(int id);

        Category GetCategory(int id);

        List<Category> GetCategories();

        List<Category> GetSubCategories();

        int? GetCategoryParentId(int id);

        List<Category> GetCategoriesByParentId(int id);

        #endregion

        #region Products
        List<Product> GetProducts();
        Product GetProduct(string pCode);

        void InsertProduct(ProductViewModel product, List<string> path);
        bool EditProduct(ProductViewModel product, List<string> path);
        void DeleteProduct(string pcode);
        #endregion
    }
}
