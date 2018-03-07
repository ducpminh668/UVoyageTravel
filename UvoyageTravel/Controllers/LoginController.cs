using System.Web.Mvc;
using UvoyageTravel.Models.Entity;
using UvoyageTravel.Models.Function.EntityFunction;

namespace UvoyageTravel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User User)
        {
            Account Account = new UserF().Login(User.Username, User.Password);
            if(Account == null)
            {
                return View();
            }
            Session["DangNhap"] = Account;
            if (Account.Roles.Contains("Admin"))
            {
                return RedirectToAction("Index", "Home", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}