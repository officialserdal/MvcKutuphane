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
        public ActionResult YazarSil(int id)
        {
            var yazar = db.YAZAR.Find(id);
            db.YAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult YazarGetir(int id)
        {
            var yzr = db.YAZAR.Find(id);
            return View("YazarGetir", yzr);

        }
        public ActionResult YazarGuncelle(YAZAR tbl)
        {
            var yzr = db.YAZAR.Find(tbl.ID);
            yzr.ID = tbl.ID;
            yzr.AD = tbl.AD;
            yzr.SOYAD = tbl.SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");


        }
    }
}