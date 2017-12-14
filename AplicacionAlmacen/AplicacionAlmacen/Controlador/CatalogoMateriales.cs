using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionAlmacen.Modelo;
namespace AplicacionAlmacen.Controlador
{
    class CatalogoMateriales
    {
        public List<Materiales> GetAllMateriales()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Materiales;
                return list.ToList();
            }
        }
    }
}
