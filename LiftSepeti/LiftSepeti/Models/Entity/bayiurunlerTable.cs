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
    
    public partial class bayiurunlerTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bayiurunlerTable()
        {
            this.bayisatisTable = new HashSet<bayisatisTable>();
        }
    
        public int id { get; set; }
        public int bayiid { get; set; }
        public int liftid { get; set; }
        public int stok { get; set; }
        public double fiyat { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bayisatisTable> bayisatisTable { get; set; }
        public virtual bayiTable bayiTable { get; set; }
        public virtual liftTable liftTable { get; set; }
    }
}
