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
    
    public partial class receteTable
    {
        public int id { get; set; }
        public int modelid { get; set; }
        public int depoid { get; set; }
        public int kullanimmiktari { get; set; }
    
        public virtual depoTable depoTable { get; set; }
        public virtual modelTable modelTable { get; set; }
    }
}
