using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace EndToEnd.Models
{
    public class BydloModels
    {
        public int ID { get; set; }
        public string Wiek { get; set; }
        public string Pasza { get; set; }
        public string Producent { get; set; }
        public decimal Cena { get; set; }
        public decimal Bialko {get; set;}
        public decimal Energia {get; set;}
        [Display(Name = "Oleje i tłuszcze")]
        public decimal Tluszcze{get; set;}
        public decimal Wapn {get; set;}
        public decimal Fosfor {get; set;}
        public decimal Sod { get; set; }
    }
}