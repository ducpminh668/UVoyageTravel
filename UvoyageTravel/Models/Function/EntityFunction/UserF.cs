using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UvoyageTravel.Models.Entity;

namespace UvoyageTravel.Models.Function.EntityFunction
{
    public class UserF
    {
        private UvoyageDBContext db = new UvoyageDBContext();
        public List<Account> getAllUserAndRoles()
        {
            List<Account> Accounts = new List<Account>();
            var getAllAccount = (from User in db.Users
                             join UserInRoles in db.UserInRoles on User.Username equals UserInRoles.Username
                             join Role in db.Roles on UserInRoles.ID_Role equals Role.ID
                             select new
                             {
                                 User.Username,
                                 Role.RoleName
                             } into viewRole
                             group viewRole.RoleName by viewRole.Username);

            foreach (var item in getAllAccount)
            {
                Account acc = new Account();
                acc.username = item.Key;
                acc.Roles = item.ToList();
                Accounts.Add(acc);
            }
            return Accounts;
        }
    }
}