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
            var ks = new KhachSanF().FindEnity(id);
            if(ks != null)
            {
                ViewBag.ListPhong = new PhongKhachSanF().ListRoomsByHotelId(ks).ToList();
            }
            return View(ks); 
        }

        [HttpPost]
        public JsonResult DatPhong(List<CartAjax> listCart)
        {
            Cart Cart = new Cart();
            foreach(CartAjax item in listCart)
            {
                PhongKhachSan phong = new PhongKhachSanF().FindEnity(item.id);
                Cart.AddItem(phong, item.quantity);
            }
            Session["CartSession"] = Cart;
            return Json(new { status = 200, data = "oke"}, JsonRequestBehavior.AllowGet);
        }
    }
}