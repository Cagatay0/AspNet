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
    public class durumTablesController : Controller
    {
        private LiftSepetiEntities4 db = new LiftSepetiEntities4();
        // GET: durumTables
        public ActionResult Index()
        {
            return View(db.durumTable.ToList());
        }
        // GET: durumTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            durumTable durumTable = db.durumTable.Find(id);
            if (durumTable == null)
            {
                return HttpNotFound();
            }
            return View(durumTable);
        }
        // GET: durumTables/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: durumTables/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,durum")] durumTable durumTable)
        {
            if (ModelState.IsValid)
            {
                db.durumTable.Add(durumTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(durumTable);
        }
        // GET: durumTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            durumTable durumTable = db.durumTable.Find(id);
            if (durumTable == null)
            {
                return HttpNotFound();
            }
            return View(durumTable);
        }
        // POST: durumTables/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,durum")] durumTable durumTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(durumTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(durumTable);
        }
        // GET: durumTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            durumTable durumTable = db.durumTable.Find(id);
            if (durumTable == null)
            {
                return HttpNotFound();
            }
            return View(durumTable);
        }
        // POST: durumTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            durumTable durumTable = db.durumTable.Find(id);
            db.durumTable.Remove(durumTable);
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
