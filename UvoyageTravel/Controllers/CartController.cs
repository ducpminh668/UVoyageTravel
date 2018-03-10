using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using UvoyageTravel.Models.Entity;
using UvoyageTravel.Models.Function.EntityFunction;

namespace UvoyageTravel.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult ThanhToan()
        {
            Cart _Cart = (Cart)Session["CartSession"];
            decimal Total = 0;
            List<CartItem> _ListCart = new List<CartItem>();
            if (_Cart != null)
            {
                _ListCart = _Cart.ListCarts.ToList();
                Total = _Cart.ComputeTotalValue().GetValueOrDefault(0m);
            }
            ViewBag.Total = Total;
            return View(_ListCart);
        }

        [HttpPost]
        public ActionResult ThanhToan(FormCollection f)
        {
            DatPhong Order = new DatPhong();
            string hoten = f["hoten"];
            string sodienthoai = f["sodienthoai"];
            string email = f["email"];
            string notes = f["notes"];

            Order.HoTen = hoten;
            Order.Mail = email;
            Order.SoDienThoai = sodienthoai;
            Order.NgayDat = DateTime.Now;
            Order.YeuCauKhac = notes;
            Order.IDPhieuDat = Guid.NewGuid();

            DatPhong myOrder = new DatPhongF().Create(Order);
            // change redirect to CamOnPage
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UpdateCart(int id, FormCollection f)
        {
            PhongKhachSan _Phong = new PhongKhachSanF().FindEnity(id);
            Cart _Cart = (Cart)Session["CartSession"];
            int NewQuantity = int.Parse(f["txtQuantity"].ToString());

            if (_Cart == null)
            {
                _Cart.UpdateItem(_Phong, NewQuantity);
                Session["CartSession"] = _Cart;
            }
            else
            {
                _Cart = new Cart();
                _Cart.AddItem(_Phong, NewQuantity);
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RemoveCartItem(int id)
        {
            PhongKhachSan _Phong = new PhongKhachSanF().FindEnity(id);
            Cart _Cart = (Cart)Session["CartSession"];

            if (_Cart != null)
            {
                _Cart.RemoveItem(_Phong);
                Session["CartSession"] = _Cart;
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult AddItem(int id, string returnURL, FormCollection f)
        {
            PhongKhachSan _Phong = new PhongKhachSanF().FindEnity(id);
            Cart _Cart = (Cart)Session["CartSession"];
            int Quantiy = int.Parse(f["txtQuantity"].ToString());

            if (_Cart == null)
            {
                _Cart = new Cart();
            }
            _Cart.AddItem(_Phong, Quantiy);
            Session["CartSession"] = _Cart;

            if (string.IsNullOrEmpty(returnURL))
            {
                return RedirectToAction("Index", "Home");
            }

            return Redirect(returnURL);
        }
    }
}