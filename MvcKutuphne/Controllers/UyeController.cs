using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcKutuphne.Models.Entity;

namespace MvcKutuphne.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        DBkutuphaneEntities db = new DBkutuphaneEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLUYELER.ToList();
            return View(degerler);

        }
    }
}