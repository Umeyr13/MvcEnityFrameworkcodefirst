using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEnityFrameworkcodefirst.Models
{
    [Table("Kişiler")]
    public class Kişiler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]//primary key, identy özelliği aktif.
        public int ID { get; set; }
        
        [StringLength(20),Required]//nvharchar(20) yapar."Required" zorunlu alan demek boş geçilemez.
        public string Ad { get; set; }

        [StringLength(20),Required]
        public string Soyad { get; set; }

        [Required]//Zorunlu alan.
        public int Yas { get; set; }
        public virtual List<Adresler> Adresler { get; set; }
    }
}