using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcEnityFrameworkcodefirst.Models
{
    [Table("Adresler")]
    public class Adresler
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(300)]
        public string Adrestanim { get; set; }
        public virtual Kişiler kisi { get; set; }

    }
}