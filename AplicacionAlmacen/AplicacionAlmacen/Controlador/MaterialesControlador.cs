using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionAlmacen.Modelo;
namespace AplicacionAlmacen.Controlador
{
    class MaterialesControlador
    {
        public List<Materiales> GetAllMateriales()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Materiales;
                return list.ToList();
            }
        }
        public int numeroMat()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Materiales;
                return list.ToList().Count();
            }
        }
        public List<Materiales> GetMateriales(int page, int pageSize)
        {
            AlmacenEntities DB = new AlmacenEntities();
            int pageIndex = Convert.ToInt32(page);
            var Results = DB.Materiales.OrderBy(s => s.descripcion).Skip(pageIndex * pageSize).Take(pageSize);
            return Results.ToList();
        }
    }
}
