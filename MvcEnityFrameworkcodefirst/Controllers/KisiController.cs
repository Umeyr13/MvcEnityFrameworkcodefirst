using MvcEnityFrameworkcodefirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEnityFrameworkcodefirst.Controllers
{
    public class KisiController : Controller
    {
        // GET: Kisi
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Kişiler kisi)
        {
            DatabaseContext context = new DatabaseContext();
            context.Kişiler.Add(kisi);
           int sonuc = context.SaveChanges();
            if (sonuc > 0) { ViewBag.mesaj = "Kişi kaydedildi"; ViewBag.renk ="success"; } 
                      else { ViewBag.mesaj="Kişi kaydedilemedi."; ViewBag.renk ="danger"; }
            return View();
        }

    }
}