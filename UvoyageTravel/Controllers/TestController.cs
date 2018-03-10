using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UvoyageTravel.Models.Entity;

namespace UvoyageTravel.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            UvoyageDBContext db = new UvoyageDBContext();
            List<PhongKhachSan> ListPhong = db.PhongKhachSans.ToList();
            return View(ListPhong);
        }
    }
}