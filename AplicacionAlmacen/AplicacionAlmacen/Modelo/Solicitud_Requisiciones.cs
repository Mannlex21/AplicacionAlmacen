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
    
    public partial class Solicitud_Requisiciones
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Solicitud_Requisiciones()
        {
            this.DetalleRequisicion2 = new HashSet<DetalleRequisicion2>();
            this.DetalleRequisicion = new HashSet<DetalleRequisicion>();
        }
    
        public int preRequisicion { get; set; }
        public Nullable<int> preRequisicionAnt { get; set; }
        public string requisicion { get; set; }
        public Nullable<System.DateTime> fechaRequisicion { get; set; }
        public string uso { get; set; }
        public Nullable<System.DateTime> fechaNecesitar { get; set; }
        public short departamento { get; set; }
        public string ciclo { get; set; }
        public string area { get; set; }
        public Nullable<System.DateTime> fechaRecepcion { get; set; }
        public int ejercicio { get; set; }
        public Nullable<int> solicitante { get; set; }
        public string observaciones { get; set; }
        public Nullable<bool> liberaLocal { get; set; }
        public Nullable<bool> liberaSeguridad { get; set; }
        public Nullable<bool> liberaCapitalHumano { get; set; }
        public Nullable<bool> liberaElectrico { get; set; }
        public Nullable<bool> liberaAlmacen { get; set; }
        public string anexo { get; set; }
    
        public virtual Departamentos Departamentos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleRequisicion2> DetalleRequisicion2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DetalleRequisicion> DetalleRequisicion { get; set; }
    }
}
