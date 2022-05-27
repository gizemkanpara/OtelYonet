using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class Musteri
    {
        [Key]
        public int MusteriID { get; set; }

        [
                    Required(ErrorMessage = "{0} Gerekli"),
                    Display(Name = "Müşteri TC"),
                    StringLength(11, MinimumLength = 11, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")
                    ]
        public string MusteriTC { get; set; }

        [
            Required(ErrorMessage = "{0} Gerekli"),
            Display(Name = "Müşteri Adı"),
            StringLength(20, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")
            ]
        public string MusteriAdi { get; set; }

        [
            Required(ErrorMessage = "{0} Gerekli"),
            Display(Name = "Müşteri Soyadı"),
            StringLength(20, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")
            ]
        public string MusteriSoyadi { get; set; }

        [
            Required(ErrorMessage = "{0} Gerekli"),
            Display(Name = "Müşteri Telefon"),
            StringLength(15, MinimumLength = 9, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")
            ]
        public string MusteriTel { get; set; }

        [
            Required(ErrorMessage = "{0} Gerekli"),
            Display(Name = "Müşteri Adresi"),
            StringLength(100, MinimumLength = 2, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")
            ]
        public string MusteriAdresi { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Cinsiyet"), Range(1, 10, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int CinsiyetID { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Müşteri Tipi"), Range(1, 20, ErrorMessage = "{0} {1} ve {2} arasında olmalı.")]
        public int MusteriTipID { get; set; }

        public Cinsiyet Cinsiyet { get; set; }

        public MusteriTip MusteriTip { get; set; }

    }
}
