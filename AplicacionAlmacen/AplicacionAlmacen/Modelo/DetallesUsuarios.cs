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
    
    public partial class DetallesUsuarios
    {
        public int IdDetalles { get; set; }
        public int idUsuario { get; set; }
        public Nullable<bool> electricos { get; set; }
        public Nullable<bool> seguridad { get; set; }
        public Nullable<bool> capitalHumano { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}
