﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AplicacionAlmacen.Modelo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AlmacenEntities : DbContext
    {
        public AlmacenEntities()
            : base("name=AlmacenEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Configuracion> Configuracion { get; set; }
        public virtual DbSet<Departamentos> Departamentos { get; set; }
        public virtual DbSet<DetalleRequisicion2> DetalleRequisicion2 { get; set; }
        public virtual DbSet<DetallesUsuarios> DetallesUsuarios { get; set; }
        public virtual DbSet<GpoMateriales> GpoMateriales { get; set; }
        public virtual DbSet<Materiales> Materiales { get; set; }
        public virtual DbSet<MaterialesContable> MaterialesContable { get; set; }
        public virtual DbSet<Solicitud_Requisiciones> Solicitud_Requisiciones { get; set; }
        public virtual DbSet<SubGrupos> SubGrupos { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<DetalleRequisicion> DetalleRequisicion { get; set; }
        public virtual DbSet<AdjuntoMateriales> AdjuntoMateriales { get; set; }
    }
}
