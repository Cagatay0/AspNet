using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LiftSepeti.Models.Entity;
using System.Net.Mail;
using System.Net;

namespace LiftSepeti.Controllers
{
    public class bayisepetController : Controller
    {
        private LiftSepetiEntities4 db = new LiftSepetiEntities4();
        int genelbayiid;
        // GET: bayisepet
        public ActionResult Index(int bayiid, int liftid)
        {
            ViewBag.bayiid = bayiid;
            ViewBag.liftid = liftid;
            siparisTable siparis = new siparisTable();
            siparis.bayiid = bayiid;
            siparis.liftid = liftid;
            siparis.durumid = 1;
            siparis.tarih = DateTime.Now;
            siparis.adet = 1.0;
            siparis.odemeyontemiid = 1;
            db.siparisTable.Add(siparis);
            db.SaveChanges();
            var siparisTable = db.siparisTable.Include(s => s.bayiTable).Include(s => s.durumTable).Include(s => s.liftTable).Include(s => s.odemeyontemiTable);
            return RedirectToAction("getIndex", "bayisepet", new { bayiid = bayiid });
        }
        public ActionResult getIndex(int bayiid)
        {
            var bayiad = db.bayiTable.Find(bayiid).bayiad;
            var sepeturunler = db.siparisTable.Where(x => x.bayiid == bayiid).Where(z => z.durumid == 1);

            if (sepeturunler.ToList().Count != 0)
            {
                ViewBag.bayiid = bayiid;
                ViewBag.bayiad = bayiad;
                var siparisTable = db.siparisTable.Include(s => s.bayiTable).Include(s => s.durumTable).Include(s => s.liftTable).Include(s => s.odemeyontemiTable);
                return View(siparisTable.Where(x => x.bayiid == bayiid && x.durumid == 1).ToList());
            }
            else
            {
                ViewBag.bayiid = bayiid;
                ViewBag.bayiad = bayiad;
                return RedirectToAction("sepetbos", "bayisepet", new { bayiid = bayiid });
            }

        }
        public ActionResult sepetbos(int bayiid)
        {
            var bayiad = db.bayiTable.Find(bayiid).bayiad;
            ViewBag.bayiid = bayiid;
            ViewBag.bayiad = bayiad;
            return View();
        }
        public ActionResult ode(int bayiid, int odemeyontemi)
        {
            var bayiad = db.bayiTable.Find(bayiid).bayiad;
            ViewBag.bayiid = bayiid;
            ViewBag.bayiad = bayiad;
            ViewBag.odemeyontemi = odemeyontemi;
            var bayisipariler = db.siparisTable.Where(x => x.bayiid == bayiid && x.durumid==1);
            bayisipariler.ToList();
            foreach (var x in bayisipariler.ToList())
            {
                x.durumid = 2;
                x.odemeyontemiid = odemeyontemi;
                int modelid = x.liftTable.modelid;
                var recetemodellist = db.receteTable.Where(a => a.modelid == modelid);
                foreach (var i in recetemodellist)
                {
                    db.depoTable.Find(i.depoid).stok -= i.kullanimmiktari;
                    if (db.depoTable.Find(i.depoid).stok < 20)
                    {
                        //email notification
                        MailMessage mail = new MailMessage(); //yeni bir mail nesnesi Oluşturuldu.
                        mail.IsBodyHtml = true; //mail içeriğinde html etiketleri kullanılsın mı?
                        mail.To.Add("liftsepeti@gmail.com"); //Kime mail gönderilecek.

                        //mail kimden geliyor, hangi ifade görünsün?
                        mail.From = new MailAddress("liftsepeti@gmail.com", "Stok Bildirimi", System.Text.Encoding.UTF8);
                        mail.Subject = "Stok Eşik Değerine Ulaştı " + "Stok Eşik Değeri";//mailin konusu

                        //mailin içeriği.. Bu alan isteğe göre genişletilip daraltılabilir.
                        mail.Body = "E-Posta:" + "liftsepeti@gmail.com" + "Konu:" + "Stok uyarısı" + "Içerik:" + "Hammadde Eşik Değerinin Altına Düştü";
                        mail.IsBodyHtml = true;
                        SmtpClient smp = new SmtpClient();

                        //mailin gönderileceği adres ve şifresi
                        smp.Credentials = new NetworkCredential("liftsepeti@gmail.com", "LiftSepeti.");
                        smp.Port = 587;
                        smp.Host = "smtp.gmail.com";//gmail üzerinden gönderiliyor.
                        smp.EnableSsl = true;
                        smp.Send(mail);//mail isimli mail gönderiliyor.
                    }
                }
                MailMessage mail2 = new MailMessage(); //yeni bir mail nesnesi Oluşturuldu.
                mail2.IsBodyHtml = true; //mail içeriğinde html etiketleri kullanılsın mı?
                mail2.To.Add("liftsepeti@gmail.com"); //Kime mail gönderilecek.

                //mail kimden geliyor, hangi ifade görünsün?
                mail2.From = new MailAddress("liftsepeti@gmail.com", "Yeni Sipariş Var", System.Text.Encoding.UTF8);
                mail2.Subject = "Yeni Sipariş Var " + "Yeni Sipariş Var";//mailin konusu

                //mailin içeriği.. Bu alan isteğe göre genişletilip daraltılabilir.
                mail2.Body = "E-Posta:" + "liftsepeti@gmail.com" + "Konu:" + "Stok uyarısı" + "Içerik:" + "Yeni Sipariş Var";
                mail2.IsBodyHtml = true;
                SmtpClient smp1 = new SmtpClient();

                //mailin gönderileceği adres ve şifresi
                smp1.Credentials = new NetworkCredential("liftsepeti@gmail.com", "LiftSepeti.");
                smp1.Port = 587;
                smp1.Host = "smtp.gmail.com";//gmail üzerinden gönderiliyor.
                smp1.EnableSsl = true;
                smp1.Send(mail2);//mail isimli mail gönderiliyor.
                db.SaveChanges();
            }
            var siparisTable = db.siparisTable.Include(s => s.bayiTable).Include(s => s.durumTable).Include(s => s.liftTable).Include(s => s.odemeyontemiTable);
            return RedirectToAction("Index", "bayianasayfa", new { bayiid = bayiid });
        }
        public ActionResult sil(int bayiid, int liftid)
        {
            siparisTable siparisTable = db.siparisTable.Find(liftid);
            db.siparisTable.Remove(siparisTable);
            db.SaveChanges();
            return RedirectToAction("getIndex", "bayisepet", new { bayiid = bayiid });
        }
        // GET: bayisepet/Details/5
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
        // GET: bayisepet/Create
        public ActionResult Create()
        {
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke");
            ViewBag.durumid = new SelectList(db.durumTable, "id", "durum");
            ViewBag.liftid = new SelectList(db.liftTable, "id", "resim");
            ViewBag.odemeyontemiid = new SelectList(db.odemeyontemiTable, "id", "tip");
            return View();
        }

        // POST: bayisepet/Create
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
        // GET: bayisepet/Edit/5
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
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", siparisTable.bayiid);
            ViewBag.durumid = new SelectList(db.durumTable, "id", "durum", siparisTable.durumid);
            ViewBag.liftid = new SelectList(db.liftTable, "id", "resim", siparisTable.liftid);
            ViewBag.odemeyontemiid = new SelectList(db.odemeyontemiTable, "id", "tip", siparisTable.odemeyontemiid);
            return View(siparisTable);
        }

        // POST: bayisepet/Edit/5
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
            ViewBag.bayiid = new SelectList(db.bayiTable, "id", "ulke", siparisTable.bayiid);
            ViewBag.durumid = new SelectList(db.durumTable, "id", "durum", siparisTable.durumid);
            ViewBag.liftid = new SelectList(db.liftTable, "id", "resim", siparisTable.liftid);
            ViewBag.odemeyontemiid = new SelectList(db.odemeyontemiTable, "id", "tip", siparisTable.odemeyontemiid);
            return View(siparisTable);
        }
        // GET: bayisepet/Delete/5
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
        // POST: bayisepet/Delete/5
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
    }
}
