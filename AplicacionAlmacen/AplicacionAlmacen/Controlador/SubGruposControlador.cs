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
            try {
                using (var bd = new AlmacenEntities())
                {
                    var list = bd.SubGrupos.ToList();
                    return list;
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }
        }
        public List<SubGrupos> GetSubGrupos(int page, int pageSize)
        {
            try {
                using (var bd = new AlmacenEntities())
                {
                  IEnumerable<SubGrupos> query = bd.SubGrupos;
                    int pageIndex = Convert.ToInt32(page);
                    var Results = query.OrderBy(s => s.subGrupo).Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    return Results;
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }
        }
        public List<SubGrupos> GetSubGruposFiltros(int numGpo, int numSubGpo, string desc)
        {
            try
            {
                using (var bd = new AlmacenEntities())
                {
                    IEnumerable<SubGrupos> query = bd.SubGrupos;
                    if (numGpo > -1)
                    {
                        query = query.Where(s => s.grupo == numGpo);
                    }
                    if (numSubGpo > -1)
                    {
                        query = query.Where(s => s.subGrupo == numSubGpo);
                    }
                    if (desc != "")
                    {
                        query = query.Where(s => s.descripcion.Contains(desc));
                    }
                    var Results = query.OrderBy(s => s.subGrupo).ToList();
                    return Results;
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }
        }
        public int numeroSubG()
        {
            try {
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
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return 0;
            }
        }

        public Object guardarSubGrupo(SubGrupos sub)
        {
            try
            {
                Object result = "";
                using (var db = new AlmacenEntities())
                {
                    var us = db.GpoMateriales.Where(u => u.numGpo == sub.grupo).FirstOrDefault();
                    if (us != null)
                    {

                        db.SubGrupos.Add(sub);
                        db.SaveChanges();
                        result = new { message = "Se guardo correctamente", code = 1 };
                    }
                    else
                    {
                        result = new { message = "Ya existe este sub-grupo: " + sub.subGrupo, code = 2 };
                    }

                    return result;
                }
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
    }
}
