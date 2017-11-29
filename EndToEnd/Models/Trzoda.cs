using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Trzoda
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Bialko_ogolne{get; set;}
        public float Energia {get; set;}
        public float Oleje_i_tluszcze {get; set;}
        public float wlokno_surowe {get; set;}
        public float popiol_surowy {get; set;}
        public float wapn {get; set;}
        public float fosfor {get; set;}
        public float sod {get; set;}
        public float magnez {get; set;}
        public float lizyna {get; set;}
        public float metionina {get; set;}
        public float treonina {get; set;}
        public float arginina { get; set; }
        public float witamina_a { get; set; }
        public float witamina_d3 { get; set; }
        public float witamina_e { get; set; }
    }
}