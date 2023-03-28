using System;
using System.Collections.Generic;
using System.Text;

using StoneMarket.AccessLayer.Entity;

namespace StoneMarket.Core.Interfaces
{
    public interface IAdmin
    {

        #region For Setting

        void InsertSetting(Setting setting);

        void UpdateSetting(string name, string desc, string keys, string api, string sender, string mail, string password);

        bool ExistsSetting();

        Setting GetSetting();

        #endregion
        #region For Permission

        void InsertPermission(Permission permission);

        void UpdatePermission(int id, string name);

        void DeletePermission(int id);

        List<Permission> GetPermissions();

        Permission GetPermission(int id);

        #endregion

        #region Category

        void InsertCategory(Category category);

        void UpdateCategory(int id, string name, string icon);

        void UpdateSubCategory(int id, int parentid, string name);

        void DeleteCategory(int id);

        Category GetCategory(int id);

        List<Category> GetCategories();

        List<Category> GetSubCategories();

        int? GetCategoryParentId(int id);

        List<Category> GetCategoriesByParentId(int id);

        #endregion

        
    }
}
