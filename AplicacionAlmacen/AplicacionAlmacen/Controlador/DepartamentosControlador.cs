using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionAlmacen.Modelo;
namespace AplicacionAlmacen.Controlador
{
    class DepartamentosControlador
    {
        public List<Departamentos> GetAllDepartamentos()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Departamentos;
                return list.ToList();
            }
        }
        public List<Departamentos> GetDepartamentos()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Departamentos;
                return list.ToList();
            }
        }
    }
}
