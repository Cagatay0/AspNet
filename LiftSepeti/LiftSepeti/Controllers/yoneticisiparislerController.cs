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
    public class yoneticisiparislerController : Controller
    {
        private LiftSepetiEntities4 db = new LiftSepetiEntities4();

        // GET: yoneticisiparisler
        public ActionResult Index(string ara)
        {
            var siparisTable = db.siparisTable.Include(s => s.bayiTable).Include(s => s.durumTable).Include(s => s.liftTable).Include(s => s.odemeyontemiTable);
            if (ara == null)
            {
                return View(siparisTable.Where(x => x.durumTable.id == 2).ToList());
            }
            else
            {
                return View(siparisTable.Where(x => x.bayiTable.bayiad.Contains(ara) && x.durumid == 2).ToList());
            }
        }
        // GET: yoneticisiparisler/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siparisTable siparisTable = db.siparisTable.Find(id);
            if (siparisTable == null)
            {
                return HttpNotFound();
            }
            return View(siparisTable);
        }
        // GET: yoneticisiparisler/Create
        public ActionResult Create()
        {
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke");
            ViewBag.durumid = new SelectList(db.durumTable, "id", "durum");
            ViewBag.liftid = new SelectList(db.liftTable, "id", "resim");
            ViewBag.odemeyontemiid = new SelectList(db.odemeyontemiTable, "id", "tip");
            return View();
        }
        // POST: yoneticisiparisler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bayiid,liftid,durumid,tarih,adet,odemeyontemiid")] siparisTable siparisTable)
        {
            if (ModelState.IsValid)
            {
                db.siparisTable.Add(siparisTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", siparisTable.bayiid);
            ViewBag.durumid = new SelectList(db.durumTable, "id", "durum", siparisTable.durumid);
            ViewBag.liftid = new SelectList(db.liftTable, "id", "resim", siparisTable.liftid);
            ViewBag.odemeyontemiid = new SelectList(db.odemeyontemiTable, "id", "tip", siparisTable.odemeyontemiid);
            return View(siparisTable);
        }
        // GET: yoneticisiparisler/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siparisTable siparisTable = db.siparisTable.Find(id);
            if (siparisTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "bayiad", siparisTable.bayiid);
            ViewBag.durumid = new SelectList(db.durumTable, "id", "durum", siparisTable.durumid);
            ViewBag.liftid = new SelectList(db.liftTable, "id", "id", siparisTable.liftid);
            ViewBag.odemeyontemiid = new SelectList(db.odemeyontemiTable, "id", "tip", siparisTable.odemeyontemiid);
            return View(siparisTable);
        }

        // POST: yoneticisiparisler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bayiid,liftid,durumid,tarih,adet,odemeyontemiid")] siparisTable siparisTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(siparisTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "bayiad", siparisTable.bayiid);
            ViewBag.durumid = new SelectList(db.durumTable, "id", "durum", siparisTable.durumid);
            ViewBag.liftid = new SelectList(db.liftTable, "id", "resim", siparisTable.liftid);
            ViewBag.odemeyontemiid = new SelectList(db.odemeyontemiTable, "id", "tip", siparisTable.odemeyontemiid);
            return View(siparisTable);
        }
        // GET: yoneticisiparisler/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            siparisTable siparisTable = db.siparisTable.Find(id);
            if (siparisTable == null)
            {
                return HttpNotFound();
            }
            return View(siparisTable);
        }
        public ActionResult Sil(int? id)
        {
            siparisTable siparisTable = db.siparisTable.Find(id);
            db.siparisTable.Remove(siparisTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: yoneticisiparisler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            siparisTable siparisTable = db.siparisTable.Find(id);
            db.siparisTable.Remove(siparisTable);
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
        protected void btn_search(object sender,EventArgs e)
        {
        }
    }
}
