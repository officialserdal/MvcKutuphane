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
        public ActionResult Index()
        {
            var kitaplar = db.TBLKITAP.ToList();
            return View(kitaplar);
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
            return View();
        }
        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP k)
        {
            db.TBLKITAP.Add(k);
            db.SaveChanges();
            return View();
        }
    }
}