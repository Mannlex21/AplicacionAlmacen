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
    
    public partial class DetallesUsuarios2
    {
        public int id { get; set; }
        public Nullable<int> idUsuario { get; set; }
        public string username { get; set; }
        public string Role { get; set; }
        public int departamento { get; set; }
        public string idEmpleado { get; set; }
    
        public virtual Usuarios Usuarios { get; set; }
    }
}