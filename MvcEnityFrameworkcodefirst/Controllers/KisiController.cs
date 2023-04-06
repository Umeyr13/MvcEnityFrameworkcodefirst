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

        DatabaseContext db = new DatabaseContext();
        // GET: Kisi
        public ActionResult Yeni()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yeni(Kişiler kisi)
        {
            
            db.Kişiler.Add(kisi);
           int sonuc = db.SaveChanges();
            if (sonuc > 0) { ViewBag.mesaj = "Kişi kaydedildi"; ViewBag.renk ="success"; } 
                      else { ViewBag.mesaj="Kişi kaydedilemedi."; ViewBag.renk ="danger"; }
            return View();
        }

        public ActionResult Duzenle (int? KisiId)//soruİşareti demek kişi ıd null olabilir demektir.
        {
            Kişiler kisi = null;
            if (KisiId != null)
            {
                
               kisi = db.Kişiler.Where(x => x.ID == KisiId).FirstOrDefault();

            }
          
            return View (kisi);
        }

        [HttpPost]
        public ActionResult Duzenle(Kişiler model,int? kisiid )
        {
            Kişiler kisi = db.Kişiler.Where(x => x.ID == kisiid).FirstOrDefault();
            if (kisi!= null)
            {
                kisi.Ad = model.Ad;
                kisi.Soyad = model.Soyad;
                kisi.Yas = model.Yas;
                int sonuc = db.SaveChanges();
            if (sonuc >0)
            {
                ViewBag.mesaj ="Kişi Bilgileri Güncellendi";
                    ViewBag.renk = "success";
            }
                else
                {
                    ViewBag.mesaj = "Kişi Bilgileri Güncellenemedi";
                    ViewBag.renk = "danger";
                }

            }
            return View ();
        }

        public ActionResult Sil(int? kisiId)
        {
            Kişiler kisi = null ;
            if (kisiId !=null)
            {
                kisi = db.Kişiler.Where(x => x.ID == kisiId).FirstOrDefault();

            }

            return View (kisi);
        }

        [HttpPost,ActionName("Sil")]
        public ActionResult Sil2(int? kisiID)
        {
            if (kisiID != null)
            {
              Kişiler kisi = db.Kişiler.Where(x=>x.ID ==kisiID).FirstOrDefault();
                //List<Adresler> adresler = db.Adresler.Where(x => x.ID == kisiID).ToList();
                //foreach (var item in adresler)
                //{
                //    db.Adresler.Remove(item); // adres ile bağlantısı varsa kişi silmeye izin vermez. böyle durumda istersen önce adresini silip kişi silebilirsin
                //}

                db.Kişiler.Remove(kisi);
                db.SaveChanges();
            }
            return RedirectToAction("Homepage","Home");//kişi yi silip başka sayfaya yönlendirdik.

        }

    }
}