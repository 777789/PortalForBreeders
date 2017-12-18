using System;
using System.Collections.Generic;
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
        public string Typ { get; set; }
        public string Pasza { get; set; }
        public string Producent { get; set; }
        public float Cena { get; set; }
        public float Bialko {get; set;}
        public float Energia {get; set;}
        public float Oleje_I_Tluszcze{get; set;}
        public float Wapn {get; set;}
        public float Fosfor {get; set;}
        public float Sod { get; set; }
    }
}