using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphne.Models.Entity;

namespace MvcKutuphne.Controllers
{
    public class KitapController : Controller
    {
        DBkutuphaneEntities db = new DBkutuphaneEntities();
        // GET: Kitap
        public ActionResult Index(string p)
        {
            //var kitaplar = db.TBLKITAP.ToList();
            var kitaplar = from k in db.TBLKITAP select k;
            if (!string.IsNullOrEmpty(p))
            {
                kitaplar=kitaplar.Where(m=>m.AD.Contains(p));
                
            }
            return View(kitaplar.ToList());
        }
        [HttpGet]
        public ActionResult KitapEkle()
        {

            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {

                                               Text = i.AD,
                                               Value = i.ID.ToString()                                       
                                           }).ToList();

            ViewBag.dgr1 = deger1;

            List<SelectListItem> deger2 = (from i in db.YAZAR.ToList()
                                           select new SelectListItem
                                           {

                                               Text = i.AD + ' '+ i.SOYAD, 
                                               Value = i.ID.ToString()
                                           }).ToList();

            ViewBag.dgr2 = deger2;
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP p)
        {
           
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.YAZAR.Where(k => k.ID == p.YAZAR1.ID).FirstOrDefault();
            p.TBLKATEGORI = ktg;
            p.YAZAR1 =yzr;
            db.TBLKITAP.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
         
        }
        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult KitapGetir(int id)
        {
            var ktb = db.TBLKITAP.Find(id);
            List<SelectListItem> deger1 = (from i in db.TBLKATEGORI.ToList()
                                           select new SelectListItem
                                           {

                                               Text = i.AD,
                                               Value = i.ID.ToString()
                                           }).ToList();

            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.YAZAR.ToList()
                                           select new SelectListItem
                                           {

                                               Text = i.AD + ' ' + i.SOYAD,
                                               Value = i.ID.ToString()
                                           }).ToList();

            ViewBag.dgr2 = deger2;

            return View("KitapGetir", ktb);

        }
        public ActionResult KitapGuncelle(TBLKITAP p)
        {
            var kitap = db.TBLKITAP.Find(p.ID);
            kitap.AD = p.AD;
            kitap.BASIMYIL = p.BASIMYIL;
            kitap.SAYFA = p.SAYFA;
            kitap.YAYINEVI = p.YAYINEVI;
            var ktg = db.TBLKATEGORI.Where(k => k.ID == p.TBLKATEGORI.ID).FirstOrDefault();
            var yzr = db.YAZAR.Where(y => y.ID == p.YAZAR1.ID).FirstOrDefault();
            kitap.KATEGORI = ktg.ID;
            kitap.YAZAR = yzr.ID;
            db.SaveChanges();
           return RedirectToAction("Index");



        }
    }
}