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
    }
}