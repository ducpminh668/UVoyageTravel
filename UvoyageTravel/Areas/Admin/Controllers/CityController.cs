using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UvoyageTravel.Models.Entity;
using UvoyageTravel.Models.Function;

namespace UvoyageTravel.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        private UvoyageDBContext db = new UvoyageDBContext();

        // GET: Admin/City
        public ActionResult Index()
        {
            return View(db.ThanhPhoes.ToList());
        }

        [HttpPost]
        public ActionResult ImportExcel(ImportExcel importExcel)
        {
            if (ModelState.IsValid)
            {
                string path = Server.MapPath("~/Content/Upload/" + importExcel.file.FileName);
                importExcel.file.SaveAs(path);

                using (var stream = System.IO.File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        var result = reader.AsDataSet();
                        DataTable dt = result.Tables[0];
                        List<string> lstTinhThanh = new List<string>();
                        foreach (DataRow row in dt.Rows)
                        {
                            string CityName = row[0].ToString();
                            ThanhPho city = new ThanhPho();
                            city.TenThanhPho = CityName;
                            city.ID = StringConverter.toUnsignedString(CityName);
                            InsertCity(city);
                        }
                        
                    }
                }

            }
            return RedirectToAction("Index");
        }

        public bool InsertCity(ThanhPho city)
        {
            db.ThanhPhoes.Add(city);
            db.SaveChanges();
            return true;
        }

        // GET: Admin/City/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhPho thanhPho = db.ThanhPhoes.Find(id);
            if (thanhPho == null)
            {
                return HttpNotFound();
            }
            return View(thanhPho);
        }

        // GET: Admin/City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/City/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenThanhPho")] ThanhPho thanhPho)
        {
            if (ModelState.IsValid)
            {
                db.ThanhPhoes.Add(thanhPho);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(thanhPho);
        }

        // GET: Admin/City/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhPho thanhPho = db.ThanhPhoes.Find(id);
            if (thanhPho == null)
            {
                return HttpNotFound();
            }
            return View(thanhPho);
        }

        // POST: Admin/City/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenThanhPho")] ThanhPho thanhPho)
        {
            if (ModelState.IsValid)
            {
                db.Entry(thanhPho).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(thanhPho);
        }

        // GET: Admin/City/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ThanhPho thanhPho = db.ThanhPhoes.Find(id);
            if (thanhPho == null)
            {
                return HttpNotFound();
            }
            return View(thanhPho);
        }

        // POST: Admin/City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ThanhPho thanhPho = db.ThanhPhoes.Find(id);
            db.ThanhPhoes.Remove(thanhPho);
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