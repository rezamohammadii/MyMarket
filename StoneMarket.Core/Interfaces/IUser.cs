using System;
using System.Collections.Generic;
using System.Text;

using StoneMarket.AccessLayer.Entity;

namespace StoneMarket.Core.Interfaces
{
    public interface IUser
    {
        bool ExistsPermission(int permissionID, int roleID);
        int GetUserRole(string username);
        string GetUserRoleName(string username);
        string GetAdminName(string username);
        Store GetUserStore(string username);
        bool ExistsMailActivate(string username, string code);
        bool ExistsMobileActivate(string username, string code);
        void ActiveMailAddress(string mailAddress);
        void ActiveMobileNumber(string mobileNumber);
      //  Setting GetSetting();
    }
}
