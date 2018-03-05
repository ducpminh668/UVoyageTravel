using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UvoyageTravel.Models.Entity;

namespace UvoyageTravel.Controllers
{

    public class HomeController : Controller
    {
        UvoyageDBContext db = new UvoyageDBContext();
        public ActionResult Index()
        {
            //lấy ảnh chuyền sang slide
            ViewBag.Slides = db.Slides;

            return View();
        }
    }
}