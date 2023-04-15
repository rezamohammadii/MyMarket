using System;
using System.Collections.Generic;
using System.Text;

using System.Linq;
using Microsoft.EntityFrameworkCore;

using StoneMarket.AccessLayer.Context;
using StoneMarket.AccessLayer.Entity;

using StoneMarket.Core.Interfaces;

namespace StoneMarket.Core.Services
{
    public class UserService : IUser
    {
        private StoneMarketContext _context;

        public UserService(StoneMarketContext context)
        {
            _context = context;
        }

        public bool ExistsMobileActivate(string username, string code)
        {
            return _context.Users.Any(u => u.Mobile == username && u.ActiveCode == code);
        }

        public bool ExistsPermission(int permissionID, int roleID)
        {
            return _context.RolePermissions.Any(r => r.RoleId == roleID && r.PermissionId == permissionID);
        }

        public int GetUserRole(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Mobile == username).RoleId;
        }

        public string GetUserRoleName(string username)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.Mobile == username)?.Role.Name;
        }

        public string GetAdminName(string username)
        {
            return _context.Users.Where(r=>r.Mobile == username).FirstOrDefault()?.FullName;
        }
    }
}
