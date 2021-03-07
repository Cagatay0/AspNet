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
    public class urunreceteController : Controller
    {
        // GET: urunrecete
        public ActionResult Index(int id)
        {
            LiftSepetiEntities4 db = new LiftSepetiEntities4();
            var ebat= db.receteTable.Find(id).modelTable.ebat;
            var ad = db.receteTable.Find(id).modelTable.ad;
            var teminsuresi = db.receteTable.Find(id).depoTable.teminsuresi;
            var liftres = db.liftTable.Where(i => i.modelid == id).FirstOrDefault();
            var resim = liftres.resim;
            var adet = liftres.adet;
            ViewBag.adet = adet;
            ViewBag.resim = resim;
            ViewBag.ebat = ebat;
            ViewBag.ad = ad;
            ViewBag.teminsuresi = teminsuresi;
            ViewBag.modelid = id;
            var receteTable = db.receteTable.Include(r => r.depoTable).Include(r => r.modelTable);
            return View(receteTable.ToList());
        }
    }
}