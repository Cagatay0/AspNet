using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LiftSepeti.Models.Entity;

namespace LiftSepeti.Controllers
{
    public class yoneticiliftlerController : Controller
    {
        private LiftSepetiEntities4 db = new LiftSepetiEntities4();
        // GET: yoneticiliftler
        public ActionResult Index()
        {
            var liftTable = db.liftTable.Include(l => l.modelTable);
            return View(liftTable.ToList());
        }
        // GET: yoneticiliftler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            liftTable liftTable = db.liftTable.Find(id);
            if (liftTable == null)
            {
                return HttpNotFound();
            }
            return View(liftTable);
        }
        // GET: yoneticiliftler/Create
        public ActionResult Create()
        {
            ViewBag.modelid = new SelectList(db.modelTable, "id", "ad");
            return View();
        }

        // POST: yoneticiliftler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,modelid,adet,fiyat,bakimperiyot,resim")] liftTable liftTable)
        {
            if (ModelState.IsValid)
            {
                db.liftTable.Add(liftTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.modelid = new SelectList(db.modelTable, "id", "ad", liftTable.modelid);
            return View(liftTable);
        }
        // GET: yoneticiliftler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            liftTable liftTable = db.liftTable.Find(id);
            if (liftTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.modelid = new SelectList(db.modelTable, "id", "ad", liftTable.modelid);
            return View(liftTable);
        }

        // POST: yoneticiliftler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,modelid,adet,fiyat,bakimperiyot,resim")] liftTable liftTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(liftTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.modelid = new SelectList(db.modelTable, "id", "ad", liftTable.modelid);
            return View(liftTable);
        }
        // GET: yoneticiliftler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            liftTable liftTable = db.liftTable.Find(id);
            if (liftTable == null)
            {
                return HttpNotFound();
            }
            return View(liftTable);
        }
        public ActionResult Sil(int? id)
        {
            liftTable liftTable = db.liftTable.Find(id);
            db.liftTable.Remove(liftTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // POST: yoneticiliftler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            liftTable liftTable = db.liftTable.Find(id);
            db.liftTable.Remove(liftTable);
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
