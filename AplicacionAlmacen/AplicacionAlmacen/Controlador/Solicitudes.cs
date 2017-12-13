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
        public List<Solicitud_Requisiciones> GetSolicitudes(string sord, int page,int pageSize)
        {
            AlmacenEntities DB = new AlmacenEntities();
            int pageIndex = Convert.ToInt32(page);
            
            var Results = DB.Solicitud_Requisiciones.Where(s => s.liberaLocal == true && s.liberaCapitalHumano == true
                 && s.liberaElectrico == true && s.liberaSeguridad == true /*&& s.requisicion=="n/a"*/);

            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)pageSize);

            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.preRequisicion);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.preRequisicion);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            return Results.ToList();
        }
    }
}

