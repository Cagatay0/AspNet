﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LiftSepetiEntities4 : DbContext
    {
        public LiftSepetiEntities4()
            : base("name=LiftSepetiEntities4")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<bayisatisTable> bayisatisTable { get; set; }
        public virtual DbSet<bayiTable> bayiTable { get; set; }
        public virtual DbSet<bayiurunlerTable> bayiurunlerTable { get; set; }
        public virtual DbSet<depoTable> depoTable { get; set; }
        public virtual DbSet<durumTable> durumTable { get; set; }
        public virtual DbSet<liftTable> liftTable { get; set; }
        public virtual DbSet<modelTable> modelTable { get; set; }
        public virtual DbSet<musteriTable> musteriTable { get; set; }
        public virtual DbSet<odemeyontemiTable> odemeyontemiTable { get; set; }
        public virtual DbSet<receteTable> receteTable { get; set; }
        public virtual DbSet<siparisTable> siparisTable { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<yoneticiTable> yoneticiTable { get; set; }
    }
}
