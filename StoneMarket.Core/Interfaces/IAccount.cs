using System;
using System.Collections.Generic;
using System.Text;

using StoneMarket.AccessLayer.Entity;

namespace StoneMarket.Core.Interfaces
{
    public interface IAccount
    {
        bool ExistsMobileNumber(string mobileNumber);

        void AddUser(User user);

        int GetMaxRole();

        int GetStoreRole();

        int GetUserId(string mobileNumber);

        bool ActivateUser(string code);

        User LoginUser(string mobileNumber, string password);

        bool ResetPassword(string code, string password);

        string GetUserActiveCode(string mobileNumber);

        void UpdateUserRole(string mobileNumber);
    }
}
