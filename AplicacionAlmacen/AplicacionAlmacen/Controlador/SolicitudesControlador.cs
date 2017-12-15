using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionAlmacen;
using AplicacionAlmacen.Modelo;

namespace AplicacionAlmacen.Controlador
{
    class SolicitudesControlador
    {
        public List<Solicitud_Requisiciones> GetAllSolicitudes()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Solicitud_Requisiciones.Where(s => s.liberaLocal == true && s.liberaCapitalHumano==true
                && s.liberaElectrico == true && s.liberaSeguridad == true && s.requisicion=="n/a" && s.liberaAlmacen == false);
                return  list.ToList();
            }
        }
        public int numeroSol()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Solicitud_Requisiciones.Where(s => s.liberaLocal == true && s.liberaCapitalHumano == true
                && s.liberaElectrico == true && s.liberaSeguridad == true && s.liberaAlmacen==false && s.requisicion=="n/a");
                return list.ToList().Count();
            }
        }
        public List<Solicitud_Requisiciones> GetSolicitudes(string depa, int page, int pageSize)
        {
            AlmacenEntities DB = new AlmacenEntities();
            int pageIndex = Convert.ToInt32(page);
            if (depa == "")
            {
                var Results = DB.Solicitud_Requisiciones.Where(s => s.liberaLocal == true && s.liberaCapitalHumano == true
                    && s.liberaElectrico == true && s.liberaSeguridad == true && s.liberaAlmacen == false && s.requisicion == "n/a")
                    .OrderBy(s => s.preRequisicion).Skip(pageIndex * pageSize).Take(pageSize);
                return Results.ToList();
            }
            else
            {
                var dep = DB.Departamentos.Where(s => s.descripcion == depa).FirstOrDefault();
                var Results = DB.Solicitud_Requisiciones.Where(s => s.liberaLocal == true && s.liberaCapitalHumano == true
                    && s.liberaElectrico == true && s.liberaSeguridad == true && s.liberaAlmacen == false && s.requisicion == "n/a" && s.departamento == dep.idDepartamento)
                    .OrderBy(s => s.preRequisicion).Skip(pageIndex * pageSize).Take(pageSize);
                return Results.ToList();
            }
            
            
        }
    }
}

