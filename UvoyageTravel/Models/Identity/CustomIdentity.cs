using System.Collections.Generic;
using System.Linq;
using UvoyageTravel.Models.Entity;

namespace UvoyageTravel.Models.Identity
{
    public class CustomIdentity
    {
        private UvoyageDBContext db = new UvoyageDBContext();

        public List<string> lstQuyenByUsername(string username)
        {
            return (from UserInRole in db.UserInRoles
                    join Role in db.Roles
                    on UserInRole.ID_Role equals Role.ID
                    where UserInRole.Username == username
                    select Role.RoleName).ToList();
        }

        public Account Login(string username, string passsword)
        {
            User usr = db.Users.Where(u => u.Username.Equals(username) && u.Password.Equals(passsword)).FirstOrDefault();
            Account _Account = null;
            if(usr != null)
            {
                _Account = new Account();
                _Account.username = username;
                _Account.password = passsword;
                _Account.Roles = lstQuyenByUsername(username);
            }
            return _Account;
        }
    }
}