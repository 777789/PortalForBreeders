using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Bydlo
    {
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public float Bialko_ogolne {get; set;}
        public float Energia {get; set;}
        public float Oleje_I_tluszcze{get; set;}
        public float wapn {get; set;}
        public float fosfor {get; set;}
        public float sod { get; set; }
        public int witamina_a { get; set; }
        public int witamina_d3 { get; set; }
        public int witamina_c { get; set; }
        public int witamina_e { get; set; }
    }
    
}