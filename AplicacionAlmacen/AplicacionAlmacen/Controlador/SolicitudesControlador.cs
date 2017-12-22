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
            try { 
                using (var bd = new AlmacenEntities())
                {
                    var list = bd.Solicitud_Requisiciones.Where(s => s.liberaLocal == true && s.liberaCapitalHumano==true
                    && s.liberaElectrico == true && s.liberaSeguridad == true && s.requisicion=="n/a" && s.liberaAlmacen == false);
                    return  list.ToList();
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }
        }
        public int numeroSol()
        {
            try { 
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;
                int cont = 0;
                using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                {
                    string query = "SELECT COUNT(*) FROM Solicitud_Requisiciones WHERE liberaLocal=1 AND liberaCapitalHumano=1 " +
                        "AND liberaElectrico=1 AND liberaSeguridad=1 AND liberaAlmacen=0 AND requisicion='n/a'";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cont = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                return cont;
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return 0;
            }
        }
        public List<Solicitud_Requisiciones> GetSolicitudes(string depa, int page, int pageSize)
        {
            try { 
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
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }

        }
    }
}

