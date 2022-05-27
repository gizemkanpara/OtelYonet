using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace otelyonet.Models
{
    public class MusteriTip
    {
        [Key]
        public int MusteriTipID { get; set; }

        [
            Required(ErrorMessage = "{0} Gerekli"),
            Display(Name = "Müşteri Tipi"),
            StringLength(12, MinimumLength = 3, ErrorMessage = "{0} {2} ve {1} arasında olmalı.")
            ]
        public string MusteriTipleri { get; set; }
    }
}
