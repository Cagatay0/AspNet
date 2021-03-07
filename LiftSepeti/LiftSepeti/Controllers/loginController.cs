using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiftSepeti.Models.Entity;

namespace LiftSepeti.Controllers
{
    public class loginController : Controller
    {
        // GET: login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginBos()
        {
            return RedirectToAction("Index", "anasayfa");
        }
        [HttpPost]
        public ActionResult Login(String bayiad,String sifre)
        {
            LiftSepetiEntities4 db = new LiftSepetiEntities4();
            bayiTable bayi = db.bayiTable.Where(x => x.bayiad.Equals(bayiad) && x.sifre.Equals(sifre)).FirstOrDefault();
            if(bayi != null)
            {
                ViewData["bayi id"] = bayi.id;
                return RedirectToAction("Index", "bayianasayfa", new { bayiid = bayi.id});
            }
            else
            {
                yoneticiTable yonetici = db.yoneticiTable.Where(x => x.ad.Equals(bayiad) && x.sifre.Equals(sifre)).FirstOrDefault();
               if(yonetici != null)
                {
                    return RedirectToAction("Index", "yoneticianasayfa");
                }
                else
                {
                    return RedirectToAction("Index", "login");
                }
                
            }
        }
        public ActionResult LogOut()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}