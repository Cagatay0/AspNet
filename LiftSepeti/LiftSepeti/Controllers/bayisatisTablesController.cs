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
    public class bayisatisTablesController : Controller
    {
        private LiftSepetiEntities4 db = new LiftSepetiEntities4();

        // GET: bayisatisTables
        public ActionResult Index(int? bayiid)
        {
            var bayisatisTable = db.bayisatisTable.Include(b => b.bayiTable).Include(b => b.bayiurunlerTable).Include(b => b.musteriTable);

            var musteriTable = db.musteriTable.ToList();
            musteriTable musteritbl = db.musteriTable.Find(bayiid);

            bayiTable bayi = db.bayiTable.Where(x => x.id == bayiid).SingleOrDefault();
            ViewBag.bayibilgiler = bayi;
            return View(bayisatisTable.ToList());  
        }
        // GET: bayisatisTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayisatisTable bayisatisTable = db.bayisatisTable.Find(id);
            if (bayisatisTable == null)
            {
                return HttpNotFound();
            }
            return View(bayisatisTable);
        }

        // GET: bayisatisTables/Create
        public ActionResult Create(int bayiid)
        {
            ViewBag.bayiad = db.bayiTable.Find(bayiid).bayiad;

            var musterilerlist = db.musteriTable.ToList();
            List<musteriTable> musteriler = new List<musteriTable>();
            foreach (var i in musterilerlist)
            {
                musteriler.Add(i);
            }
            ViewBag.musteriler = musteriler;
            var bayiurunler = db.bayiurunlerTable.Where(x => x.bayiid == bayiid).ToList();
            List<liftTable> isimler = new List<liftTable>();
            foreach (var i in bayiurunler)
            {
                isimler.Add(i.liftTable);
            }
            ViewBag.isimler = isimler;
            ViewBag.bayiid = bayiid;
            ViewBag.bayiurunleriid = new SelectList(db.bayiurunlerTable, "id", "liftid");
            ViewBag.musteriid = new SelectList(db.musteriTable, "id", "ad");
            bayiTable bayi = db.bayiTable.Where(x => x.id == bayiid).SingleOrDefault();
            ViewBag.bayibilgiler = bayi;
            return View();
        }
        // POST: bayisatisTables/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,bayiid,musteriid,bayiurunleriid,tarih,kar,satisadet")] bayisatisTable bayisatisTable)
        {
            if (ModelState.IsValid)
            {
                db.bayisatisTable.Add(bayisatisTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", bayisatisTable.bayiid);
            ViewBag.bayiurunleriid = new SelectList(db.bayiurunlerTable, "id", "id", bayisatisTable.bayiurunleriid);
            ViewBag.musteriid = new SelectList(db.musteriTable, "id", "ad", bayisatisTable.musteriid);
            return View(bayisatisTable);
        }
        // GET: bayisatisTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayisatisTable bayisatisTable = db.bayisatisTable.Find(id);
            if (bayisatisTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", bayisatisTable.bayiid);
            ViewBag.bayiurunleriid = new SelectList(db.bayiurunlerTable, "id", "id", bayisatisTable.bayiurunleriid);
            ViewBag.musteriid = new SelectList(db.musteriTable, "id", "ad", bayisatisTable.musteriid);
            return View(bayisatisTable);
        }

        // POST: bayisatisTables/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,bayiid,musteriid,bayiurunleriid,tarih,kar,satisadet")] bayisatisTable bayisatisTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bayisatisTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", bayisatisTable.bayiid);
            ViewBag.bayiurunleriid = new SelectList(db.bayiurunlerTable, "id", "id", bayisatisTable.bayiurunleriid);
            ViewBag.musteriid = new SelectList(db.musteriTable, "id", "ad", bayisatisTable.musteriid);
            return View(bayisatisTable);
        }
        // GET: bayisatisTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bayisatisTable bayisatisTable = db.bayisatisTable.Find(id);
            if (bayisatisTable == null)
            {
                return HttpNotFound();
            }
            return View(bayisatisTable);
        }
        // POST: bayisatisTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bayisatisTable bayisatisTable = db.bayisatisTable.Find(id);
            db.bayisatisTable.Remove(bayisatisTable);
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
