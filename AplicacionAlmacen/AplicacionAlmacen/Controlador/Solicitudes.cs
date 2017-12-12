using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionAlmacen;
using AplicacionAlmacen.Modelo;

namespace AplicacionAlmacen.Controlador
{
    class Solicitudes
    {
        public List<Materiales> existe()
        {
            using (var bd = new AlmacenEntities())
            {
                return  bd.Materiales.ToList();
                
            }
        }
    }
}
