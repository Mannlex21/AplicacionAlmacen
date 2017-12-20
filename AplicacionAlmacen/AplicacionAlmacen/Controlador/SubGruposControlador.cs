using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public List<SubGrupos> GetSubGrupos(int page, int pageSize)
        {
            using (var bd = new AlmacenEntities())
            {
                int pageIndex = Convert.ToInt32(page);
                var Results = bd.SubGrupos.OrderBy(s => s.subGrupo).Skip(pageIndex * pageSize).Take(pageSize).ToList();
                return Results;
            }
        }
        public int numeroSubG()
        {
            var context = new AlmacenEntities();
            var connection = context.Database.Connection;
            int cont = 0;
            using (SqlConnection con = new SqlConnection(connection.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM SubGrupos";
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

        public Object guardarSubGrupo(SubGrupos sub)
        {
            try
            {
                string s;
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;

                Object result="";
                AlmacenEntities db = new AlmacenEntities();
                var us = from u in db.GpoMateriales select u;
                us = us.Where(u => u.numGpo == sub.grupo);
                var x = us.FirstOrDefault();
                if (us.FirstOrDefault() != null)
                {
                    using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                    {

                        string query = "INSERT INTO SubGrupos (grupo,subGrupo,descripcion) VALUES (@grupo,@subGrupo,@descripcion)";
                        query += " SELECT SCOPE_IDENTITY()";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@descripcion", sub.descripcion);
                            cmd.Parameters.AddWithValue("@grupo", sub.grupo);
                            cmd.Parameters.AddWithValue("@subGrupo", sub.subGrupo);
                            s = cmd.ExecuteScalar().ToString();
                            con.Close();
                        }
                    }
                    result = new { message = "Se guardo correctamente", code = 1 };
                }
                else
                {
                    result = new { message = "No se encontro el grupo", code = 2 };
                }
                
                return result;
            }
            catch (SqlException odbcEx)
            {
                Object result = new { message = "Error: " + odbcEx.Message.ToString(), code = 2 };
                return result;
            }
            catch (Exception ex)
            {
                Object result = new { message = "Error: " + ex.Message.ToString(), code = 2 };
                return result;
            }

        }
        public Object borrarSubGrupo(SubGrupos sub)
        {
            try
            {
                string s;
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;
                using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                {
                    string query = "DELETE FROM SubGrupos WHERE grupo=@grupo and subGrupo=@subGrupo";
                    query += " SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@grupo", sub.grupo);
                        cmd.Parameters.AddWithValue("@subGrupo", sub.subGrupo);
                        s = cmd.ExecuteScalar().ToString();
                        con.Close();
                    }
                }
                Object result = new { message = "Se borro correctamente", code = 1 };
                return result;
            }
            catch (SqlException odbcEx)
            {
                Object result = new { message = "Error: " + odbcEx.Message.ToString(), code = 2 };
                return result;
            }
            catch (Exception ex)
            {
                Object result = new { message = "Error: " + ex.Message.ToString(), code = 2 };
                return result;
            }

        }
        public Object editarSubGrupo(SubGrupos sub,int grupoA,int subGrupoA)
        {
            try
            {
                string s;
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;

                Object result = "";
                AlmacenEntities db = new AlmacenEntities();
                var us = from u in db.GpoMateriales select u;
                us = us.Where(u => u.numGpo == sub.grupo);
                var x = us.FirstOrDefault();
                if (us.FirstOrDefault() != null)
                {
                    using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                    {

                        string query = "UPDATE SubGrupos SET grupo = @grupoN ,subGrupo = @subGrupoN ,descripcion = @descripcionN" +
                                        " WHERE grupo=@grupo and subGrupo=@subGrupo";
                        query += " SELECT SCOPE_IDENTITY()";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@grupoN", sub.grupo);
                            cmd.Parameters.AddWithValue("@subGrupoN", sub.subGrupo);
                            cmd.Parameters.AddWithValue("@descripcionN", sub.descripcion);
                            cmd.Parameters.AddWithValue("@grupo", grupoA);
                            cmd.Parameters.AddWithValue("@subGrupo", subGrupoA);
                            s = cmd.ExecuteScalar().ToString();
                            con.Close();
                        }
                    }
                    result = new { message = "Se edito correctamente", code = 1 };
                }
                else
                {
                    result = new { message = "No se encontro el grupo", code = 2 };
                }

                return result;
            }
            catch (SqlException odbcEx)
            {
                Object result = new { message = "Error: " + odbcEx.Message.ToString(), code = 2 };
                return result;
            }
            catch (Exception ex)
            {
                Object result = new { message = "Error: " + ex.Message.ToString(), code = 2 };
                return result;
            }

        }

        /* public JsonResult setRequisicion(Solicitud solicitud, List<Partidas> partidas, Checks checks) //Gets the todo Lists.  
         {
             try
             {
                 string s;
                 var context = new AlmacenEntities();
                 var connection = context.Database.Connection;
                 int preReq = 0;
                 using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                 {
                     string query = "SELECT COUNT(*) FROM Solicitud_Requisiciones WHERE departamento=" + solicitud.departamento;
                     using (SqlCommand cmd = new SqlCommand(query))
                     {
                         cmd.Connection = con;
                         con.Open();
                         preReq = Convert.ToInt32(cmd.ExecuteScalar());
                         con.Close();
                     }


                 }
                 using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                 {
                     string query = "INSERT INTO Solicitud_Requisiciones(preRequisicion,preRequisicionAnt,requisicion,fechaRequisicion,fechaNecesitar,uso,departamento,ciclo,area,fechaRecepcion,ejercicio,solicitante,observaciones,liberaLocal,liberaSeguridad,liberaElectrico,liberaCapitalHumano,liberaAlmacen) " +
                         "VALUES(@preRequisicion,@preRequisicionAnt,@requisicion,@fechaRequisicion,@fechaNecesitar,@uso,@departamento,@ciclo,@area,@fechaRecepcion,@ejercicio,@solicitante,@observaciones,@liberaLocal,@liberaSeguridad,@liberaElectrico,@liberaCapitalHumano,@liberaAlmacen)";
                     query += " SELECT SCOPE_IDENTITY()";
                     using (SqlCommand cmd = new SqlCommand(query))
                     {
                         cmd.Connection = con;
                         con.Open();
                         cmd.Parameters.AddWithValue("@preRequisicion", preReq + 1);
                         cmd.Parameters.AddWithValue("@preRequisicionAnt", 0);
                         cmd.Parameters.AddWithValue("@requisicion", solicitud.idRequisicion);
                         cmd.Parameters.AddWithValue("@fechaNecesitar", Convert.ToDateTime(solicitud.fechaNecesitar));
                         cmd.Parameters.AddWithValue("@fechaRequisicion", Convert.ToDateTime(solicitud.fechaRequisicion));
                         cmd.Parameters.AddWithValue("@uso", solicitud.uso);
                         cmd.Parameters.AddWithValue("@departamento", solicitud.departamento);
                         cmd.Parameters.AddWithValue("@ciclo", solicitud.ciclo);
                         cmd.Parameters.AddWithValue("@area", solicitud.area);
                         cmd.Parameters.AddWithValue("@fechaRecepcion", Convert.ToDateTime(solicitud.fechaRecepcion));
                         cmd.Parameters.AddWithValue("@ejercicio", solicitud.ejercicio);
                         cmd.Parameters.AddWithValue("@solicitante", solicitud.solicitante);
                         if (solicitud.observaciones == null)
                         {
                             cmd.Parameters.AddWithValue("@observaciones", "---");
                         }
                         else
                         {
                             cmd.Parameters.AddWithValue("@observaciones", solicitud.observaciones);
                         }
                         if (checks.electrico == false)
                         {
                             cmd.Parameters.AddWithValue("@liberaElectrico", true);
                         }
                         else
                         {
                             cmd.Parameters.AddWithValue("@liberaElectrico", false);
                         }
                         if (checks.soldadura == false && checks.altura == false
                             && checks.espaciosConfinados == false && checks.izajes == false && checks.montacarga == false)
                         {
                             cmd.Parameters.AddWithValue("@liberaSeguridad", true);
                         }
                         else
                         {
                             cmd.Parameters.AddWithValue("@liberaSeguridad", false);
                         }
                         if (checks.trabajoSindicato == false && checks.retencionImpuesto == false)
                         {
                             cmd.Parameters.AddWithValue("@liberaCapitalHumano", true);
                         }
                         else
                         {
                             cmd.Parameters.AddWithValue("@liberaCapitalHumano", false);
                         }
                         cmd.Parameters.AddWithValue("@liberaLocal", false);
                         cmd.Parameters.AddWithValue("@liberaAlmacen", false);
                         s = cmd.ExecuteScalar().ToString();
                         con.Close();
                     }
                 }
                 int cont = 0;
                 string r = "";
                 foreach (var value in partidas)
                 {


                     using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                     {
                         string query = "INSERT INTO DetalleRequisicion (preRequisicion,requisicion,partida,material,cantidad,detalle,ejercicio,costoU,costoTotal,existencia,FechaUltimaEntrada,departamento) " +
                             "VALUES(@preRequisicion, @requisicion, @partida, @material, @cantidad, @detalle, @ejercicio, @costoU, @costoTotal, @existencia, @FechaUltimaEntrada,@departamento)";
                         query += " SELECT SCOPE_IDENTITY()";
                         using (SqlCommand cmd = new SqlCommand(query))
                         {
                             cmd.Connection = con;
                             con.Open();
                             cmd.Parameters.AddWithValue("@preRequisicion", preReq + 1);
                             cmd.Parameters.AddWithValue("@requisicion", solicitud.idRequisicion);
                             cmd.Parameters.AddWithValue("@partida", cont++);
                             cmd.Parameters.AddWithValue("@material", Int32.Parse(value.Clave));
                             cmd.Parameters.AddWithValue("@cantidad", float.Parse(value.Cantidad));
                             cmd.Parameters.AddWithValue("@detalle", value.Detalle);
                             cmd.Parameters.AddWithValue("@ejercicio", solicitud.ejercicio);
                             cmd.Parameters.AddWithValue("@costoU", float.Parse(value.PrecioU));
                             cmd.Parameters.AddWithValue("@costoTotal", float.Parse(value.PrecioU) * float.Parse(value.Cantidad));
                             cmd.Parameters.AddWithValue("@existencia", float.Parse(value.Existencia));
                             cmd.Parameters.AddWithValue("@FechaUltimaEntrada", Convert.ToDateTime("01/01/2017"));
                             cmd.Parameters.AddWithValue("@departamento", solicitud.departamento);
                             r = r + cmd.ExecuteScalar().ToString() + ",";
                             con.Close();
                         }
                     }
                 }
                 using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                 {
                     string query = "INSERT INTO DetalleRequisicion2 (trabajoSindicato,retencionImpuesto,altura,espaciosConfinados,electrico,corte,soldadura,operacionMontacargas,izajesCarga,preRequisicion,departamento,ejercicio) " +
                         "VALUES(@trabajoSindicato, @retencionImpuesto, @altura, @espaciosConfinados, @electrico, @corte, @soldadura, @operacionMontacargas, @izajesCarga, @preRequisicion, @departamento, @ejercicio)";
                     query += " SELECT SCOPE_IDENTITY()";
                     using (SqlCommand cmd = new SqlCommand(query))
                     {
                         cmd.Connection = con;
                         con.Open();
                         cmd.Parameters.AddWithValue("@preRequisicion", preReq + 1);
                         cmd.Parameters.AddWithValue("@departamento", solicitud.departamento);
                         cmd.Parameters.AddWithValue("@ejercicio", solicitud.ejercicio);
                         cmd.Parameters.AddWithValue("@trabajoSindicato", checks.trabajoSindicato);
                         cmd.Parameters.AddWithValue("@retencionImpuesto", checks.retencionImpuesto);
                         cmd.Parameters.AddWithValue("@altura", checks.altura);
                         cmd.Parameters.AddWithValue("@espaciosConfinados", checks.espaciosConfinados);
                         cmd.Parameters.AddWithValue("@electrico", checks.electrico);
                         cmd.Parameters.AddWithValue("@corte", checks.corte);
                         cmd.Parameters.AddWithValue("@soldadura", checks.soldadura);
                         cmd.Parameters.AddWithValue("@operacionMontacargas", checks.montacarga);
                         cmd.Parameters.AddWithValue("@izajesCarga", checks.izajes);
                         s = cmd.ExecuteScalar().ToString();
                         con.Close();
                     }
                 }
                 var jsonData = new { code = "OK", resultSol = s, resultPar = r, partidas = partidas, solicitud = solicitud, preRequisicion = preReq + 1 };
                 return Json(jsonData, JsonRequestBehavior.AllowGet);
             }
             catch (SqlException odbcEx)
             {
                 var jsonData = new { code = odbcEx };
                 return Json(jsonData, JsonRequestBehavior.AllowGet);
             }
             catch (Exception ex)
             {
                 var jsonData = new { code = ex };
                 return Json(jsonData, JsonRequestBehavior.AllowGet);
             }
         }*/
    }
}
