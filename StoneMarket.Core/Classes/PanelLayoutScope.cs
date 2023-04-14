using System;
using System.Collections.Generic;
using System.Text;

using StoneMarket.AccessLayer.Entity;

using StoneMarket.Core.Interfaces;
using StoneMarket.Core.Services;

namespace StoneMarket.Core.Classes
{
    public class PanelLayoutScope
    {
        private IUser _user;
        private IAdmin _admin;
        //private IStore _store;

        public PanelLayoutScope(IUser user, IAdmin admin)//, IStore store)
        {
            _user = user;
            _admin = admin;
           // _store = store;
        }

        public string GetUserRoleName(string username)
        {
            return _user.GetUserRoleName(username);
        }
        public string GetAdminName(string username)
        {
            return _user.GetAdminName(username);
        }
        public List<Category> Categories()
        {
            return _admin.GetSubCategories();
        }

    }
}
