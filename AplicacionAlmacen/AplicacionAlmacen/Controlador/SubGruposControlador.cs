using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionAlmacen.Modelo;
namespace AplicacionAlmacen.Controlador
{
    class SubGruposControlador
    {
        public List<SubGrupos> GetAllSubGrupos()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.SubGrupos.ToList();
                return list;
            }
        }
        public List<SubGrupos> GetSubGrupos()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.SubGrupos.ToList();
                return list;
            }
        }
    }
}
