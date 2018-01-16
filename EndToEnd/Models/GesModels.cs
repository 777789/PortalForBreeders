using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class GesModels
    {
        public int Id { get; set; }
        public string Wiek { get; set; }
        public string Pasza { get; set; }
        public string Producent { get; set; }
        public decimal Cena { get; set; }
        [Display(Name = "Białko")]
        public decimal Bialko { get; set; }
        public decimal Energia { get; set; }
        public decimal Oleje { get; set; }
        [Display(Name = "Wapń")]
        public decimal Wapn { get; set; }
        public decimal Fosfor { get; set; }
        [Display(Name = "Sód")]
        public decimal Sod { get; set; }
        public decimal Lizyna { get; set; }
        public decimal Metionina { get; set; }
        public decimal Treonina { get; set; }
    }
}