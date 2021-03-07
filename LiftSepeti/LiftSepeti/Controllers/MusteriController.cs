using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiftSepeti.Models.Entity;


namespace LiftSepeti.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        LiftSepetiEntities4 db = new LiftSepetiEntities4();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(String musterinumara)
        {
            var musteriler = db.musteriTable.ToList();
            foreach (var mus in musteriler)
            {
                if (mus.telefon == musterinumara)
                {
                    return RedirectToAction("musterianasayfa", "Musteri", new { musteriid = mus.id });
                }
            }
            return RedirectToAction("Index", "Musteri");
        }
        public ActionResult musterianasayfa(int musteriid)
        {
            ViewBag.musteriid = musteriid;
            var bayiurunler = db.bayiurunlerTable.ToList();
            return View(bayiurunler);
        }
        public ActionResult siparis(int liftid, int musteriid)
        {
            return RedirectToAction("musterianasayfa", "Musteri", new { musteriid = musteriid });
        }
        public ActionResult Goruntule(int bayiid)
        {
            LiftSepetiEntities4 db = new LiftSepetiEntities4();
            ViewBag.bayiid = bayiid;
            var musteri = db.musteriTable.ToList();
            bayiTable bayi = db.bayiTable.Where(x => x.id == bayiid).SingleOrDefault();
            ViewBag.bayibilgiler = bayi;
            return View(musteri);
        }
    }
}