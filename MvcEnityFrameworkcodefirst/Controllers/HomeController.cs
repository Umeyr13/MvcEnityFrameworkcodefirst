using MvcEnityFrameworkcodefirst.Models;
using MvcEnityFrameworkcodefirst.Models.Yenimodel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEnityFrameworkcodefirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult HomePage()
        {
            DatabaseContext db = new DatabaseContext();
           List<Kişiler> kisilistesi = db.Kişiler.ToList();

            _HomapageViewModel model = new _HomapageViewModel();
            model.Kişiler = kisilistesi;
            model.adresler = db.Adresler.ToList();
            return View(model);
        }
    }
}