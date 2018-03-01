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
    public class HotelController : Controller
    {
        private UvoyageDBContext db = new UvoyageDBContext();

        // GET: Admin/Hotel
        public ActionResult Index()
        {
            var khachSans = db.KhachSans.Include(k => k.QuanHuyen);
            return View(khachSans.ToList());
        }

        // GET: Admin/Hotel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachSan khachSan = db.KhachSans.Find(id);
            if (khachSan == null)
            {
                return HttpNotFound();
            }
            return View(khachSan);
        }

        // GET: Admin/Hotel/Create
        public ActionResult Create()
        {
            ViewBag.QuanHuyen_ID = new SelectList(db.QuanHuyens, "ID", "TenQuanHuyen");
            return View();
        }

        // POST: Admin/Hotel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenKhachSan,UnsignedName,DiaChi,XepHang,SoDienThoai,ThongTinLienHe,GiaTien,UuTien,ThongTinMoTa,TienIch,ChinhSach,QuanHuyen_ID,GoogleMap")] KhachSan khachSan)
        {
            if (ModelState.IsValid)
            {
                db.KhachSans.Add(khachSan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuanHuyen_ID = new SelectList(db.QuanHuyens, "ID", "TenQuanHuyen", khachSan.QuanHuyen_ID);
            return View(khachSan);
        }

        // GET: Admin/Hotel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachSan khachSan = db.KhachSans.Find(id);
            if (khachSan == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuanHuyen_ID = new SelectList(db.QuanHuyens, "ID", "TenQuanHuyen", khachSan.QuanHuyen_ID);
            return View(khachSan);
        }

        // POST: Admin/Hotel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenKhachSan,UnsignedName,DiaChi,XepHang,SoDienThoai,ThongTinLienHe,GiaTien,UuTien,ThongTinMoTa,TienIch,ChinhSach,QuanHuyen_ID,GoogleMap")] KhachSan khachSan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachSan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuanHuyen_ID = new SelectList(db.QuanHuyens, "ID", "TenQuanHuyen", khachSan.QuanHuyen_ID);
            return View(khachSan);
        }

        // GET: Admin/Hotel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachSan khachSan = db.KhachSans.Find(id);
            if (khachSan == null)
            {
                return HttpNotFound();
            }
            return View(khachSan);
        }

        // POST: Admin/Hotel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachSan khachSan = db.KhachSans.Find(id);
            db.KhachSans.Remove(khachSan);
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
