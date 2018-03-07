using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UvoyageTravel.Models.Entity;

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
            
            //Change Return Redirec
            return View();
        }
        
    }
}