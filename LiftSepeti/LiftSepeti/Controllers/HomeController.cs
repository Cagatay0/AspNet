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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LiftSepetiEntities4 db = new LiftSepetiEntities4();
            var liftTable = db.liftTable.Include(l =>l.modelTable);
            return View(liftTable.ToList());
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}