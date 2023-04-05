using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcEnityFrameworkcodefirst.Models
{
    public class DatabaseContext:DbContext
    {
        public DbSet<Kişiler> Kişiler { get; set; }
        public DbSet<Adresler> Adresler { get; set; }
        public DatabaseContext()
        {
            Database.SetInitializer(new VeriTabaniOlusturucu());
        }

    }



    public class VeriTabaniOlusturucu:CreateDatabaseIfNotExists<DatabaseContext>// eğer data base yoksa yeni bir db oluştur.
    {

        protected override void Seed(DatabaseContext context)//database oluşturulduktan sonra bunu yap
        {
           
            for (int i = 1; i < 11; i++)
            {
                //Id ıdenty kensidi alır
                Kişiler kisi = new Kişiler();
                kisi.Ad=FakeData.NameData.GetFirstName();
                kisi.Soyad=FakeData.NameData.GetSurname();
                kisi.Yas=FakeData.NumberData.GetNumber(18,65);//random yas aralığı

                context.Kişiler.Add(kisi);//insert into where değerler bu gibi eklemekten kurtardı enty framework
            }
            context.SaveChanges();
            List<Kişiler> kisilist =context.Kişiler.ToList();//select * from kisiler demiş olduk.
            
            foreach (Kişiler item in kisilist)
            {
                Adresler adres = new Adresler();
                adres.Adrestanim=FakeData.PlaceData.GetAddress();
                adres.kisi=item;//bu adresin kişisi kim ise ona gönder adresi.
                context.Adresler.Add(adres);
            }
            context.SaveChanges();

        }   



    }
}