//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LiftSepeti.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class siparisTable
    {
        public int id { get; set; }
        public int bayiid { get; set; }
        public int liftid { get; set; }
        public int durumid { get; set; }
        public System.DateTime tarih { get; set; }
        public double adet { get; set; }
        public int odemeyontemiid { get; set; }
    
        public virtual bayiTable bayiTable { get; set; }
        public virtual durumTable durumTable { get; set; }
        public virtual liftTable liftTable { get; set; }
        public virtual odemeyontemiTable odemeyontemiTable { get; set; }
    }
}
