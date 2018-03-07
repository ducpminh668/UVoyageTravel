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

        public Account Login(string username, string password)
        {
            var result = db.Users.Where(a =>
                a.Username.Equals(username) &&
                a.Password.Equals(password)).FirstOrDefault();
            Account t = null;

            if (result != null)
            {
                t = new Account();
                t.username = result.Username;
                t.password = result.Password;
                t.Roles = (from a in db.Roles
                           join b in db.UserInRoles
                           on a.ID equals b.ID_Role
                           where (a.RoleName != null && b.Username.Equals(username))
                           select a.RoleName).ToList();
            }
            return t;
        }
    }
}