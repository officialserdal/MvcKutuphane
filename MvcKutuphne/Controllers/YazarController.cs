using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphne.Models.Entity;

namespace MvcKutuphne.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DBkutuphaneEntities db = new DBkutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.YAZAR.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YazarEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YazarEkle(YAZAR p)
        {
            db.YAZAR.Add(p);
            db.SaveChanges();
            return View();

        }
    }
}