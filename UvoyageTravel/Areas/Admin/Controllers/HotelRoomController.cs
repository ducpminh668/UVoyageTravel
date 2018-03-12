using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UvoyageTravel.Models.Entity;

namespace UvoyageTravel.Areas.Admin.Controllers
{
    public class HotelRoomController : Controller
    {
        private UvoyageDBContext db = new UvoyageDBContext();

        // GET: Admin/HotelRoom
        public ActionResult Index()
        {
            return View(db.PhongKhachSans.ToList());
        }

        // GET: Admin/HotelRoom/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongKhachSan phongKhachSan = db.PhongKhachSans.Find(id);
            if (phongKhachSan == null)
            {
                return HttpNotFound();
            }
            return View(phongKhachSan);
        }

        // GET: Admin/HotelRoom/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/HotelRoom/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenPhong,DienTich,ToiDa,DichVuHuyPhong,GiaTien,GomBuaAn,Img,MoTa,KhachSan_ID")] PhongKhachSan phongKhachSan)
        {
            if (ModelState.IsValid)
            {
                db.PhongKhachSans.Add(phongKhachSan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(phongKhachSan);
        }

        // GET: Admin/HotelRoom/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongKhachSan phongKhachSan = db.PhongKhachSans.Find(id);
            if (phongKhachSan == null)
            {
                return HttpNotFound();
            }
            return View(phongKhachSan);
        }

        // POST: Admin/HotelRoom/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenPhong,DienTich,ToiDa,DichVuHuyPhong,GiaTien,GomBuaAn,Img,MoTa,KhachSan_ID")] PhongKhachSan phongKhachSan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongKhachSan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(phongKhachSan);
        }

        // GET: Admin/HotelRoom/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongKhachSan phongKhachSan = db.PhongKhachSans.Find(id);
            if (phongKhachSan == null)
            {
                return HttpNotFound();
            }
            return View(phongKhachSan);
        }

        // POST: Admin/HotelRoom/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhongKhachSan phongKhachSan = db.PhongKhachSans.Find(id);
            db.PhongKhachSans.Remove(phongKhachSan);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
