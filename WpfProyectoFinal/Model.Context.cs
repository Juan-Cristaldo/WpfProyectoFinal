﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfProyectoFinal
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ElectroparEntities : DbContext
    {
        public ElectroparEntities()
            : base("name=ElectroparEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Ciudad> Ciudad { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Contactos> Contactos { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<Mantenimiento> Mantenimiento { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<TipoGenerador> TipoGenerador { get; set; }
    }
}