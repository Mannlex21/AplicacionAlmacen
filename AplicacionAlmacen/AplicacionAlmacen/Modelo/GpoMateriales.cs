//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class GpoMateriales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GpoMateriales()
        {
            this.SubGrupos = new HashSet<SubGrupos>();
        }
    
        public short numGpo { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> cuenta_F_Z { get; set; }
        public Nullable<bool> aplicaCentCost_F_Z { get; set; }
        public Nullable<int> subCuenta_F_Z { get; set; }
        public Nullable<int> subSubCuenta_F_Z { get; set; }
        public Nullable<int> cuenta_A_Z { get; set; }
        public Nullable<bool> aplicaCentCost_A_Z { get; set; }
        public Nullable<int> subCuenta_A_Z { get; set; }
        public Nullable<int> subSubCuenta_A_Z { get; set; }
        public Nullable<int> cuenta_C_Z { get; set; }
        public Nullable<bool> aplicaCentCost_C_Z { get; set; }
        public Nullable<int> subCuenta_C_Z { get; set; }
        public Nullable<int> subSubCuenta_C_Z { get; set; }
        public Nullable<int> cuenta_D_Z { get; set; }
        public Nullable<bool> aplicaCentCost_D_Z { get; set; }
        public Nullable<int> subCuenta_D_Z { get; set; }
        public Nullable<int> subSubCuenta_D_Z { get; set; }
        public Nullable<int> cuenta_F_R { get; set; }
        public Nullable<bool> aplicaCentCost_F_R { get; set; }
        public Nullable<int> subCuenta_F_R { get; set; }
        public Nullable<int> subSubCuenta_F_R { get; set; }
        public Nullable<int> cuenta_A_R { get; set; }
        public Nullable<bool> aplicaCentCost_A_R { get; set; }
        public Nullable<int> subCuenta_A_R { get; set; }
        public Nullable<int> subSubCuenta_A_R { get; set; }
        public Nullable<int> cuenta_C_R { get; set; }
        public Nullable<bool> aplicaCentCost_C_R { get; set; }
        public Nullable<int> subCuenta_C_R { get; set; }
        public Nullable<int> subSubCuenta_C_R { get; set; }
        public Nullable<int> cuenta_D_R { get; set; }
        public Nullable<bool> aplicaCentCost_D_R { get; set; }
        public Nullable<int> subCuenta_D_R { get; set; }
        public Nullable<int> subSubCuenta_D_R { get; set; }
        public Nullable<decimal> cantidad { get; set; }
        public Nullable<decimal> importe { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubGrupos> SubGrupos { get; set; }
    }
}
