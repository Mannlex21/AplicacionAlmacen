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
    class Solicitudes
    {
        public List<Solicitud_Requisiciones> GetAllSolicitudes()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Solicitud_Requisiciones.Where(s => s.liberaLocal == true && s.liberaCapitalHumano==true
                && s.liberaElectrico == true && s.liberaSeguridad == true /*&& s.requisicion=="n/a"*/);
                return  list.ToList();
            }
        }
        public int numeroSol()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Solicitud_Requisiciones.Where(s => s.liberaLocal == true && s.liberaCapitalHumano == true
                && s.liberaElectrico == true && s.liberaSeguridad == true /*&& s.requisicion=="n/a"*/);
                return list.ToList().Count();
            }
        }
        public List<Solicitud_Requisiciones> GetSolicitudes(int page,int pageSize)
        {
            AlmacenEntities DB = new AlmacenEntities();
            int pageIndex = Convert.ToInt32(page);
            var Results = DB.Solicitud_Requisiciones.Where(s => s.liberaLocal == true && s.liberaCapitalHumano == true
                && s.liberaElectrico == true && s.liberaSeguridad == true && s.requisicion=="n/a")
                .OrderBy(s => s.preRequisicion).Skip(pageIndex * pageSize).Take(pageSize);
            return Results.ToList();
        }
    }
}

