using MvcEnityFrameworkcodefirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcEnityFrameworkcodefirst.Controllers
{
    public class AdresController : Controller
    {
            DatabaseContext db = new DatabaseContext();

        // GET: Adres
        public ActionResult Yeni()
        {
            List<Kişiler> kisiler = db.Kişiler.ToList();
            List<SelectListItem> liste = new List<SelectListItem>();
            //foreach (var item in kisiler)
            //{
            //    liste.Add(new SelectListItem()
            //    {
            //        Text = item.Ad + " " + item.Soyad,
            //        Value = item.ID.ToString()

            //    });


            //}

            //Linq İle
            liste = (from kisi in kisiler select new SelectListItem() 
            {
             
                Text = kisi.Ad + " " + kisi.Soyad,Value = kisi.ID.ToString()
                
            }).ToList();
            ViewBag.kisiler = liste; //view bag bir kere gösterir listeyi sonra silinir.
            TempData["liste"] = liste; //lissteyi hemen silinmesin diye temp data ya attık. 
            return View();
        }

        [HttpPost]
        public ActionResult Yeni(Adresler adres)
        {
          Kişiler kisi =  db.Kişiler.Where(x => x.ID == adres.kisi.ID).FirstOrDefault();
            if (kisi!=null)
            {
                adres.kisi = kisi;
                db.Adresler.Add(adres);
               int sonuc = db.SaveChanges();
                if (sonuc > 0) { ViewBag.mesaj = "Adres kaydedildi"; ViewBag.renk = "success"; }

                else           { ViewBag.mesaj = "Adres kaydedilemedi."; ViewBag.renk = "danger"; }

            }
            ViewBag.kisiler = TempData["liste"];// Yeni listeyi view e bag tekrar temp data ile attık. ViewBag.kisiler in içi boşaldı tek seferlik di o . temp data olmasa veri tabanına bağlanıp tekrar liste almamız gerekirdi.
            return View();
        }

        public ActionResult Duzenle(int? adresId)
        {
            Adresler adres = null;
            if (adresId != null)
            {
                adres = db.Adresler.Where(x => x.ID == adresId).FirstOrDefault();
                List<SelectListItem> liste = (from kisi in db.Kişiler.ToList()
                select new SelectListItem()
                {
                    Text = kisi.Ad + " " + kisi.Soyad,
                    Value = kisi.ID.ToString()

                }).ToList();
                ViewBag.kisiler = liste;
                TempData["liste"] = liste;
            }

            return View(adres);

        }

        [HttpPost]
        public ActionResult Duzenle(Adresler model,int? adresId)
        {
            Adresler adres = db.Adresler.Where(x => x.ID == adresId).FirstOrDefault();
            Kişiler kisi  = db.Kişiler.Where(x => x.ID == model.kisi.ID).FirstOrDefault();

            if (kisi != null)
            {
                adres.Adrestanim = model.Adrestanim;
                adres.kisi = kisi;
              
                int sonuc = db.SaveChanges();
                if (sonuc > 0) { ViewBag.mesaj = "Adres kaydedildi"; ViewBag.renk = "success"; }

                else { ViewBag.mesaj = "Adres kaydedilemedi."; ViewBag.renk = "danger"; }

            }
            ViewBag.kisiler = TempData["liste"];

            return View();
        }

        public ActionResult Sil(int? AdresId)
        {
            Adresler adres = null;
            if (AdresId != null)
            {
                adres = db.Adresler.Where(x => x.ID == AdresId).FirstOrDefault();

            }

            return View(adres);
        }

        [HttpPost, ActionName("Sil")]
        public ActionResult Sil2(int? AdresID)
        {
            if (AdresID != null)
            {
                Adresler adres = db.Adresler.Where(x => x.ID == AdresID).FirstOrDefault();
                db.Adresler.Remove(adres);
                db.SaveChanges();
            }
            return RedirectToAction("Homepage", "Home");//kişi yi silip başka sayfaya yönlendirdik.

        }
    }
}