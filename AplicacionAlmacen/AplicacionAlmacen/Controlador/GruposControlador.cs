using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionAlmacen.Modelo;
namespace AplicacionAlmacen.Controlador
{
    class GruposControlador
    {
        public List<GpoMateriales> GetAllGrupos()
        {
            try {
                using (var bd = new AlmacenEntities())
                {
                    var list = bd.GpoMateriales;
                    return list.ToList();
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }
        }
        public List<GrupoLite> GetAllGruposLigero()
        {
            try
            {
                using (var bd = new AlmacenEntities())
                {
                    var query = bd.GpoMateriales.Select(store => new GrupoLite { numGpo = store.numGpo, descripcion = store.descripcion });

                    //var list = bd.GpoMateriales.Select(store => new GpoMateriales { numGpo = store.numGpo, descripcion= store.descripcion});
                    return query.ToList();
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }
        }
        public List<GpoMateriales> GetGrupos(int page, int pageSize)
        {
            try { 
                using (var bd = new AlmacenEntities())
                {
                    IEnumerable<GpoMateriales> query = bd.GpoMateriales;
                    int pageIndex = Convert.ToInt32(page);
                    var Results = query.OrderBy(s => s.numGpo).Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    return Results;
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }
           
        }
        public List<GpoMateriales> GetGruposFiltros(int noGpo, string desc)
        {
            try
            {
                using (var bd = new AlmacenEntities())
                {
                    IEnumerable<GpoMateriales> query = bd.GpoMateriales;
                    if (desc != "")
                    {
                        query = query.Where(s => s.descripcion.ToUpper().Contains(desc.ToUpper()));
                    }
                    if (noGpo > -1)
                    {
                        query = query.Where(s => s.numGpo == noGpo);
                    }
                    var Results = query.OrderBy(s => s.numGpo).ToList();
                    return Results;
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }

        }
        public int numeroGrupo()
        {
            try { 
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;
                int cont = 0;
                using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                {
                    string query = "SELECT COUNT(*) FROM GpoMateriales";
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
        public Object guardarGrupo(GpoMateriales grupo)
        {
            try
            {
                Object result = "";
                using (var db = new AlmacenEntities())
                {
                    var us =db.GpoMateriales.Where(u => u.numGpo == grupo.numGpo).FirstOrDefault();
                    if (us == null)
                    {
                        db.GpoMateriales.Add(grupo);
                        db.SaveChanges();
                        result = new { message = "Se guardo correctamente", code = 1 };
                    }
                    else
                    {
                        result = new { message = "Ya existe este grupo: " + grupo.numGpo, code = 2 };
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

        public Object editarGrupo(GpoMateriales grupo, int numGpo)
        {
            try
            {
                Object result = "";
                grupo.numGpo = (Int16)numGpo;
                using (var bd = new AlmacenEntities())
                {
                    bd.Entry(grupo).State = System.Data.Entity.EntityState.Modified;
                    bd.SaveChanges();
                    result = new { message = "Se edito correctamente", code = 1 };

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
        public Object borrarGrupo(GpoMateriales grupo)
        {
            try
            {
                string s;
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;
                using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                {
                    string query = "DELETE FROM GpoMateriales WHERE numGpo=@numGpo";
                    query += " SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@numGpo", grupo.numGpo);
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
        public class GrupoLite
        {
            public int numGpo { get; set; }
            public string descripcion { get; set; }
            // Other field you may need from the Product entity
        }
    }
}
