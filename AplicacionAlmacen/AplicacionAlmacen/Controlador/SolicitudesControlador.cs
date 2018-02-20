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
                    var list = bd.Solicitud_Requisiciones.Where(s => s.liberaLocal == "A" && s.liberaCapitalHumano == "A"
                    && s.liberaElectrico == "A" && s.liberaSeguridad == "A" && s.requisicion=="n/a" && s.liberaAlmacen == "P");
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
                    string query = "SELECT COUNT(*) FROM Solicitud_Requisiciones WHERE liberaLocal='A' AND liberaCapitalHumano='A' " +
                        "AND liberaElectrico='A' AND liberaSeguridad='A' AND liberaAlmacen='P' AND requisicion='n/a'";
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
                    var Results = DB.Solicitud_Requisiciones.Where(s => s.liberaLocal == "A" && s.liberaCapitalHumano == "A"
                        && s.liberaElectrico == "A" && s.liberaSeguridad == "A" && s.liberaAlmacen == "P" && s.requisicion == "n/a")
                        .OrderBy(s => s.preRequisicion).Skip(pageIndex * pageSize).Take(pageSize);
                    return Results.ToList();
                }
                else
                {
                    var dep = DB.Departamentos.Where(s => s.descripcion == depa).FirstOrDefault();
                    var Results = DB.Solicitud_Requisiciones.Where(s => s.liberaLocal == "A" && s.liberaCapitalHumano == "A"
                        && s.liberaElectrico == "A" && s.liberaSeguridad == "A" && s.liberaAlmacen == "P" && s.requisicion == "n/a" && s.departamento == dep.idDepartamento)
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
        public List<Solicitud_Requisiciones> GetSolicitudesAll(string depa)
        {
            try
            {
                AlmacenEntities DB = new AlmacenEntities();
                if (depa == "")
                {
                    var Results = DB.Solicitud_Requisiciones.Where(s => s.liberaLocal == "A" && s.liberaCapitalHumano == "A"
                        && s.liberaElectrico == "A" && s.liberaSeguridad == "A" && s.liberaAlmacen == "P" && s.requisicion == "n/a")
                        .OrderBy(s => s.preRequisicion).ToList();
                    return Results;
                }
                else
                {
                    var dep = DB.Departamentos.Where(s => s.descripcion == depa).FirstOrDefault();
                    var Results = DB.Solicitud_Requisiciones.Where(s => s.liberaLocal == "A" && s.liberaCapitalHumano == "A"
                        && s.liberaElectrico == "A" && s.liberaSeguridad == "A" && s.liberaAlmacen == "P" && s.requisicion == "n/a" && s.departamento == dep.idDepartamento)
                        .OrderBy(s => s.preRequisicion).ToList();
                    return Results;
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }

        }
        public bool existeMaterial(int id)
        {
            try {
                AlmacenEntities DB = new AlmacenEntities();
                var Results = DB.Materiales.Where(s => s.idMaterial==id).FirstOrDefault();
                if (Results == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
                
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return false;
            }
        }
        public List<dynamic> GetSolicitudDet(int preReq, int dep, int ejercicio)
        {
            try
            {
                AlmacenEntities DB = new AlmacenEntities();
                var Results = (from pd in DB.DetalleRequisicion
                         orderby pd.partida
                         select new
                         {
                             pd.partida,
                             pd.preRequisicion,
                             pd.departamento,
                             pd.material,
                             pd.cantidad,
                             pd.detalle,
                             pd.ejercicio,
                             pd.costoU,
                             pd.costoTotal,
                             pd.FechaUltimaEntrada,
                             pd.descripcion,
                             existencia=(DB.Materiales.Where(s=>s.idMaterial==pd.material).FirstOrDefault().existencia==null)?pd.existencia: DB.Materiales.Where(s => s.idMaterial == pd.material).FirstOrDefault().existencia
                         }).Where(s => s.preRequisicion == preReq && s.departamento == dep && s.ejercicio == ejercicio).ToList();
                return Results.ToList<dynamic>();
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }

        }
        public int getConsecutivo(string ciclo, string departamento, int ejercicio)
        {
            List<listaS> c = new List<listaS>();
            using (var bd = new AlmacenEntities())
            {
                
                foreach (var x in bd.Solicitud_Requisiciones)
                {
                    if (x.requisicion!="n/a") {
                        string[] sp = x.requisicion.Split('/');
                        string ci = "" + sp[0].ToString()[0];
                        string dep = "" + sp[0].ToString()[1] + sp[0].ToString()[2];
                        string ej = sp[2].ToString();
                        string ej2 = "" + ejercicio.ToString()[2] + ejercicio.ToString()[3];
                        if (ci.Equals(ciclo) && dep.Equals(departamento) && ej.Equals(ej2))
                        {
                            int conse = Int32.Parse(sp[1]);
                            c.Add(new listaS
                            {
                                id = conse
                            });
                        }

                    }
                }
            }
            int max = 0;
            if (c.Count != 0)
            {
                max = c.Max(t => t.id);
            }
            return max+1;
        }
        class listaS
        {
            public int id { get; set; }
        }
        public Object claveSolicitud(string ciclo, string departamento, int ejercicio)
        {
            Object result = "";
            try
            {
                int conse = getConsecutivo(ciclo, departamento, ejercicio);
                string consecutivo = "";
                string ej2 = "" + ejercicio.ToString()[2] + ejercicio.ToString()[3];
                
                consecutivo = (conse.ToString().Length == 1) ? "000" + conse : (conse.ToString().Length == 2) ? "00" + conse : (conse.ToString().Length == 3) ? "0" + conse : "" + conse;
                string r = ciclo + departamento + "/" + consecutivo + "/" + ej2;
                result = new { message = "OK",result=r, code = 1 };
                return result;
            }
            catch (Exception ex)
            {
                result = new { message = "Error: " + ex.Message.ToString(),result="error", code = 2 };
                return result;
            }
            
        }
        public Object asignarClave(string clave, int id, int ejercicio, int departamento)
        {
            Object result = "";
            try
            {
                int contF= 0;
                List<DetalleRequisicion> li;
                using (var bd = new AlmacenEntities())
                {
                     li= bd.DetalleRequisicion.Where(s => s.preRequisicion==id 
                    && s.departamento==departamento && s.ejercicio==ejercicio).ToList();
                }
                AlmacenEntities DB = new AlmacenEntities();
                foreach (var i in li)
                {
                    if (DB.Materiales.Where(s => s.idMaterial == i.material).FirstOrDefault().existencia >= i.cantidad)
                    {
                        contF++;
                    }
                }
                if (contF==0)
                {
                    var context = new AlmacenEntities();
                    var connection = context.Database.Connection;
                    using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                    {
                        string query = "UPDATE Solicitud_Requisiciones SET requisicion='" + clave + "', liberaAlmacen='A' WHERE preRequisicion=" + id+" and departamento="+departamento+" and ejercicio="+ejercicio;
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteScalar();
                            con.Close();
                        }
                    }
                    result = new { message = "Se asigno la siguiente clave correctamente: " + clave, code = 1 };
                    return result;
                }
                else
                {
                    result = new { message = "Actualmente hay existencia de los materiales " + clave, code = 2 };
                    return result;
                }
                
            }
            catch (SqlException odbcEx)
            {
                result = new { message = "Error: " + odbcEx.Message.ToString(), code = 2 };
                return result;
            }
            catch (Exception odbcEx)
            {
                result = new { message = "Error: " + odbcEx.Message.ToString(), code = 2 };
                return result;
            }
            
        }
    }
}

