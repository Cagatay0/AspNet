using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using LiftSepeti.Models.Entity;

namespace LiftSepeti.Controllers
{
    public class yoneticibayilerController : Controller
    {
        private LiftSepetiEntities4 db = new LiftSepetiEntities4();
        // GET: yoneticibayiler
        public ActionResult Index(string ara)
        {
            //return View(db.bayiTable.ToList());
            return View(db.bayiTable.Where(x=>x.bayiad.Contains(ara)||ara==null).ToList());
        }
        // GET: yoneticibayiler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayiTable bayiTable = db.bayiTable.Find(id);
            if (bayiTable == null)
            {
                return HttpNotFound();
            }
            return View(bayiTable);
        }
        // GET: yoneticibayiler/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: yoneticibayiler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ulke,sehir,bayiad,sifre,adres")] bayiTable bayiTable)
        {
            if (ModelState.IsValid)
            {
                try { 
                db.bayiTable.Add(bayiTable);
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                catch(DbEntityValidationException dbValEx)
                {
                    
                }
            }
            return View(bayiTable);
        }
        // GET: yoneticibayiler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayiTable bayiTable = db.bayiTable.Find(id);
            if (bayiTable == null)
            {
                return HttpNotFound();
            }
            return View(bayiTable);
        }
        // POST: yoneticibayiler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ulke,sehir,bayiad,sifre,adres")] bayiTable bayiTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bayiTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bayiTable);
        }
        // GET: yoneticibayiler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayiTable bayiTable = db.bayiTable.Find(id);
            if (bayiTable == null)
            {
                return HttpNotFound();
            }
            return View(bayiTable);
        }
        public ActionResult Sil(int? id)
        {
            bayiTable bayiTable = db.bayiTable.Find(id);
            db.bayiTable.Remove(bayiTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST: yoneticibayiler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bayiTable bayiTable = db.bayiTable.Find(id);
            db.bayiTable.Remove(bayiTable);
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
        public ActionResult Anasayfa()
        {
            ViewData["icerik"] = "İçerik değerimizi ViewData ile string olarak taşıyoruz.";
            return View();
        }
    }
}
