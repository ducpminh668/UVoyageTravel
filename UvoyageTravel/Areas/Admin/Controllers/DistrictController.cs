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
    public class DistrictController : Controller
    {
        private UvoyageDBContext db = new UvoyageDBContext();

        // GET: Admin/District
        public ActionResult Index()
        {
            var quanHuyens = db.QuanHuyens.Include(q => q.ThanhPho);
            return View(quanHuyens.ToList());
        }

        // GET: Admin/District/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanHuyen quanHuyen = db.QuanHuyens.Find(id);
            if (quanHuyen == null)
            {
                return HttpNotFound();
            }
            return View(quanHuyen);
        }

        // GET: Admin/District/Create
        public ActionResult Create()
        {
            ViewBag.ThanhPho_ID = new SelectList(db.ThanhPhoes, "ID", "TenThanhPho");
            return View();
        }

        // POST: Admin/District/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenQuanHuyen,ThanhPho_ID")] QuanHuyen quanHuyen)
        {
            if (ModelState.IsValid)
            {
                db.QuanHuyens.Add(quanHuyen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ThanhPho_ID = new SelectList(db.ThanhPhoes, "ID", "TenThanhPho", quanHuyen.ThanhPho_ID);
            return View(quanHuyen);
        }

        // GET: Admin/District/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanHuyen quanHuyen = db.QuanHuyens.Find(id);
            if (quanHuyen == null)
            {
                return HttpNotFound();
            }
            ViewBag.ThanhPho_ID = new SelectList(db.ThanhPhoes, "ID", "TenThanhPho", quanHuyen.ThanhPho_ID);
            return View(quanHuyen);
        }

        // POST: Admin/District/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenQuanHuyen,ThanhPho_ID")] QuanHuyen quanHuyen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quanHuyen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ThanhPho_ID = new SelectList(db.ThanhPhoes, "ID", "TenThanhPho", quanHuyen.ThanhPho_ID);
            return View(quanHuyen);
        }

        // GET: Admin/District/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuanHuyen quanHuyen = db.QuanHuyens.Find(id);
            if (quanHuyen == null)
            {
                return HttpNotFound();
            }
            return View(quanHuyen);
        }

        // POST: Admin/District/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            QuanHuyen quanHuyen = db.QuanHuyens.Find(id);
            db.QuanHuyens.Remove(quanHuyen);
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
