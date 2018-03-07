using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UvoyageTravel.Models.Entity;
using UvoyageTravel.Models.Function.EntityFunction;

namespace UvoyageTravel.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult DatPhong(int id = 1)
        {
            KhachSan ks = new KhachSanF().FindEnity(id);
            if(ks != null)
            {
                ViewBag.ListPhong = new PhongKhachSanF().ListRoomsByHotelId(ks);
            }
            return View(ks);
        }
    }
}