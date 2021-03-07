using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LiftSepeti.Models
{
    public class musterisiparisModel
    {
        public int id { get; set; }
        public int musteriid { get; set; }
        public int bayiid { get; set; }
        public int liftid { get; set; }
        public int modelid { get; set; }
        public string resim { get; set; }
        public string bayiad { get; set; }
        public string liftad { get; set; }
        public double fiyat { get; set; }
        public int bakimperiyot { get; set; }
        public double kar { get; set; }
        public DateTime tarih { get; set; }
        public int bakim { get; set; }
        public string musterinumara { get; set; }
    }
}