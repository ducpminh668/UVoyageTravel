using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using UvoyageTravel.Models.Entity;

namespace UvoyageTravel.Models.Identity
{
    public class CustomPrincipal : IPrincipal
    {
        private Account _Account;
        public CustomPrincipal (Account Account)
        {
            this._Account = Account;
            this.Identity = new GenericIdentity(Account.username);
        }
        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {

            var roles = role.Split(new char[] { ',' });
            UvoyageDBContext db = new UvoyageDBContext();
            string username = (HttpContext.Current.Session["DangNhap"] as User).Username;
            bool kq = (from UserInRole in db.UserInRoles
                       join Role in db.Roles
                       on UserInRole.ID_Role equals Role.ID
                       where UserInRole.Username == username
                       select Role.RoleName).Any(r => roles.Contains(r));


            return kq; 
        }

         
    }
}