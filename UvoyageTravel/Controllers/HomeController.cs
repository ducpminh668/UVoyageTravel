using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UvoyageTravel.Models.Entity;
using UvoyageTravel.Models.Function.EntityFunction;

namespace UvoyageTravel.Controllers
{

    public class HomeController : Controller
    {
        UvoyageDBContext db = new UvoyageDBContext();
        public ActionResult Index()
        {
            //lấy ảnh chuyền sang slide
            ViewBag.Slides = db.Slides;
            ViewBag.Cities = db.ThanhPhoes.ToList();
            return View();
        }

        public ActionResult DanhSachKhachSan(string id)
        {
            List<KhachSan> KhachSans = new KhachSanF().KhachSanByCity(id).ToList();

            return View(KhachSans);
        }
        
    }
}