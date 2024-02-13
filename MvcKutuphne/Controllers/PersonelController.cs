using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphne.Models.Entity;
    

namespace MvcKutuphne.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        DBkutuphaneEntities db = new DBkutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLPERSONEL.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Personelekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Personelekle(TBLPERSONEL p)
        {
            if (!ModelState.IsValid)
            {
                return View("Personelekle");
            }
            db.TBLPERSONEL.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult PersonelGetir(int id)
        {
            var yzr = db.YAZAR.Find(id);
            return View("PersonelGetir", yzr);

        }
        public ActionResult PersonelGuncelle(TBLPERSONEL tbl)
        {
            var prs = db.TBLPERSONEL.Find(tbl.ID);
            prs.PERSONEL = tbl.PERSONEL;        
            db.SaveChanges();
            return RedirectToAction("Index");

             
        }

    }
}