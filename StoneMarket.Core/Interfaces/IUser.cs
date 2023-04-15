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
      //  Setting GetSetting();
    }
}
