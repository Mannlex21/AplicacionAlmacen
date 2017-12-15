using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionAlmacen.Modelo;
namespace AplicacionAlmacen.Controlador
{
    class GruposControlador
    {
        public List<GpoMateriales> GetAllGrupos()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.GpoMateriales;
                return list.ToList();
            }
        }
        public List<GpoMateriales> GetGrupos()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.GpoMateriales;
                return list.ToList();
            }
        }
    }
}
