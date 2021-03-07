using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using LiftSepeti.Models;
using LiftSepeti.Models.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiftSepeti.Controllers
{
    public class musteriAPIController : Controller
    {
        // GET: musteriAPI
        public ActionResult Index(int musteriid)
        {
            ViewBag.musteriid = musteriid;
            IEnumerable<musterisiparisModel> musterisiparismodel = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://5ff8af7517386d0017b5172b.mockapi.io/");
                var responseTask = client.GetAsync("musterisiparis");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readjob = result.Content.ReadAsAsync<IList<musterisiparisModel>>();
                    readjob.Wait();
                    musterisiparismodel = readjob.Result;
                }
                else
                {
                }
                return View(musterisiparismodel);
            }
        }
        public ActionResult SiparisEkle(int musteriid, int bayiid, int liftid, int modelid, string resim, string bayiad, string liftad, double fiyat, int bakimperiyot)
        {
            LiftSepetiEntities4 db = new LiftSepetiEntities4();
            if (modelid == 0)
            {
                modelid= db.liftTable.Find(liftid).modelid;
                resim = db.liftTable.Find(liftid).resim;
                liftad = db.liftTable.Find(liftid).modelTable.ad;
                bakimperiyot = db.liftTable.Find(liftid).bakimperiyot;
            }
            ViewBag.musteriid = musteriid;
            var alisFiyat = db.siparisTable.Where(x => x.bayiid == bayiid && x.liftid == liftid).FirstOrDefault().liftTable.fiyat;
            var kar = fiyat - alisFiyat;
            musterisiparisModel musterisiparis = new musterisiparisModel();
            musterisiparis.musteriid = musteriid;
            musterisiparis.bayiid = bayiid;
            musterisiparis.liftid = liftid;
            musterisiparis.modelid = modelid;
            musterisiparis.resim = resim;
            musterisiparis.bayiad = bayiad;
            musterisiparis.liftad = liftad;
            musterisiparis.fiyat = fiyat;
            musterisiparis.bakimperiyot = bakimperiyot;
            musterisiparis.kar = kar;
            musterisiparis.tarih = DateTime.Now;
            musterisiparis.bakim = 0;
            musterisiparis.musterinumara = db.musteriTable.Find(musteriid).telefon;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://5ff8af7517386d0017b5172b.mockapi.io/musterisiparis");
                var postJob = client.PostAsJsonAsync<musterisiparisModel>("musterisiparis", musterisiparis);
                postJob.Wait();
                var result = postJob.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", new { musteriid = musteriid });
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
        }

        public ActionResult BayiSiparisEkle(int musteriid, int bayiid, int liftid, int modelid, string resim, string bayiad, string liftad, double fiyat, int bakimperiyot)
        {
            LiftSepetiEntities4 db = new LiftSepetiEntities4();
            if (modelid == 0)
            {
                modelid = db.liftTable.Find(liftid).modelid;
                resim = db.liftTable.Find(liftid).resim;
                liftad = db.liftTable.Find(liftid).modelTable.ad;
                bakimperiyot = db.liftTable.Find(liftid).bakimperiyot;
            }
            ViewBag.musteriid = musteriid;
            var alisFiyat = db.siparisTable.Where(x => x.bayiid == bayiid && x.liftid == liftid).FirstOrDefault().liftTable.fiyat;
            var kar = fiyat - alisFiyat;
            musterisiparisModel musterisiparis = new musterisiparisModel();
            musterisiparis.musteriid = musteriid;
            musterisiparis.bayiid = bayiid;
            musterisiparis.liftid = liftid;
            musterisiparis.modelid = modelid;
            musterisiparis.resim = resim;
            musterisiparis.bayiad = bayiad;
            musterisiparis.liftad = liftad;
            musterisiparis.fiyat = fiyat;
            musterisiparis.bakimperiyot = bakimperiyot;
            musterisiparis.kar = kar;
            musterisiparis.tarih = DateTime.Now;
            musterisiparis.bakim = 0;
            musterisiparis.musterinumara = db.musteriTable.Find(musteriid).telefon;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://5ff8af7517386d0017b5172b.mockapi.io/musterisiparis");
                var postJob = client.PostAsJsonAsync<musterisiparisModel>("musterisiparis", musterisiparis);
                postJob.Wait();
                var result = postJob.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("satislar", "bayimagaza", new {bayiid = bayiid });
                }
                else
                {
                    return RedirectToAction("satislar", "bayimagaza");
                }

            }
        }
    }
}