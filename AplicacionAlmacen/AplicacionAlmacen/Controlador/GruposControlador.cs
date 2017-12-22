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
        public List<GpoMateriales> GetGrupos(int page, int pageSize)
        {
            try { 
                using (var bd = new AlmacenEntities())
                {
                    int pageIndex = Convert.ToInt32(page);
                    var Results = bd.GpoMateriales.OrderBy(s => s.numGpo).Skip(pageIndex * pageSize).Take(pageSize).ToList();
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
                string s;
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;

                Object result = "";
                AlmacenEntities db = new AlmacenEntities();
                var us = from u in db.GpoMateriales select u;
                us = us.Where(u => u.numGpo == grupo.numGpo);
                var x = us.FirstOrDefault();
                if (us.FirstOrDefault() == null)
                {
                    using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                    {
                        String query = "INSERT INTO [dbo].[GpoMateriales] (numGpo, descripcion, cuenta_F_Z, aplicaCentCost_F_Z, " +
                                        "subCuenta_F_Z, subSubCuenta_F_Z, cuenta_A_Z, aplicaCentCost_A_Z, subCuenta_A_Z, subSubCuenta_A_Z, " +
                                        "cuenta_C_Z, aplicaCentCost_C_Z, subCuenta_C_Z, subSubCuenta_C_Z, cuenta_D_Z, aplicaCentCost_D_Z, " +
                                        "subCuenta_D_Z, subSubCuenta_D_Z, cuenta_F_R, aplicaCentCost_F_R, subCuenta_F_R, subSubCuenta_F_R, cuenta_A_R, " +
                                        "aplicaCentCost_A_R, subCuenta_A_R, subSubCuenta_A_R, cuenta_C_R, aplicaCentCost_C_R, subCuenta_C_R, " +
                                        "subSubCuenta_C_R, cuenta_D_R, aplicaCentCost_D_R, subCuenta_D_R, subSubCuenta_D_R, cantidad, importe) " +
                           
                            "VALUES(@numGpo, @descripcion, @cuenta_F_Z, @aplicaCentCost_F_Z, @subCuenta_F_Z, @subSubCuenta_F_Z, @cuenta_A_Z, " +
                                "@aplicaCentCost_A_Z, @subCuenta_A_Z, @subSubCuenta_A_Z, @cuenta_C_Z, @aplicaCentCost_C_Z, @subCuenta_C_Z, " +
                                "@subSubCuenta_C_Z, @cuenta_D_Z, @aplicaCentCost_D_Z, @subCuenta_D_Z, @subSubCuenta_D_Z, @cuenta_F_R, " +
                                "@aplicaCentCost_F_R, @subCuenta_F_R, @subSubCuenta_F_R, @cuenta_A_R, @aplicaCentCost_A_R, @subCuenta_A_R, " +
                                "@subSubCuenta_A_R, @cuenta_C_R, @aplicaCentCost_C_R, @subCuenta_C_R, @subSubCuenta_C_R, @cuenta_D_R, " +
                                "@aplicaCentCost_D_R, @subCuenta_D_R, @subSubCuenta_D_R, @cantidad, @importe)";
                        query += " SELECT SCOPE_IDENTITY()";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            cmd.Parameters.AddWithValue("@numGpo", grupo.numGpo);
                            cmd.Parameters.AddWithValue("@descripcion", grupo.descripcion);
                            cmd.Parameters.AddWithValue("@cuenta_F_Z", grupo.cuenta_F_Z);
                            cmd.Parameters.AddWithValue("@aplicaCentCost_F_Z", grupo.aplicaCentCost_F_Z);
                            cmd.Parameters.AddWithValue("@subCuenta_F_Z", grupo.subCuenta_F_Z);
                            cmd.Parameters.AddWithValue("@subSubCuenta_F_Z", grupo.subSubCuenta_F_Z);
                            cmd.Parameters.AddWithValue("@cuenta_A_Z", grupo.cuenta_A_Z);
                            cmd.Parameters.AddWithValue("@aplicaCentCost_A_Z", grupo.aplicaCentCost_A_Z);
                            cmd.Parameters.AddWithValue("@subCuenta_A_Z", grupo.subCuenta_A_Z);
                            cmd.Parameters.AddWithValue("@subSubCuenta_A_Z", grupo.subSubCuenta_A_Z);
                            cmd.Parameters.AddWithValue("@cuenta_C_Z", grupo.cuenta_C_Z);
                            cmd.Parameters.AddWithValue("@aplicaCentCost_C_Z", grupo.aplicaCentCost_C_Z);
                            cmd.Parameters.AddWithValue("@subCuenta_C_Z", grupo.subCuenta_C_Z);
                            cmd.Parameters.AddWithValue("@subSubCuenta_C_Z", grupo.subSubCuenta_C_Z);
                            cmd.Parameters.AddWithValue("@cuenta_D_Z", grupo.cuenta_D_Z);
                            cmd.Parameters.AddWithValue("@aplicaCentCost_D_Z", grupo.aplicaCentCost_D_Z);
                            cmd.Parameters.AddWithValue("@subCuenta_D_Z", grupo.subCuenta_D_Z);
                            cmd.Parameters.AddWithValue("@subSubCuenta_D_Z", grupo.subSubCuenta_D_Z);
                            cmd.Parameters.AddWithValue("@cuenta_F_R", grupo.cuenta_F_R);
                            cmd.Parameters.AddWithValue("@aplicaCentCost_F_R", grupo.aplicaCentCost_F_R);
                            cmd.Parameters.AddWithValue("@subCuenta_F_R", grupo.subCuenta_F_R);
                            cmd.Parameters.AddWithValue("@subSubCuenta_F_R", grupo.subSubCuenta_F_R);
                            cmd.Parameters.AddWithValue("@cuenta_A_R", grupo.cuenta_A_R);
                            cmd.Parameters.AddWithValue("@aplicaCentCost_A_R", grupo.aplicaCentCost_A_R);
                            cmd.Parameters.AddWithValue("@subCuenta_A_R", grupo.subCuenta_A_R);
                            cmd.Parameters.AddWithValue("@subSubCuenta_A_R", grupo.subSubCuenta_A_R);
                            cmd.Parameters.AddWithValue("@cuenta_C_R", grupo.cuenta_C_R);
                            cmd.Parameters.AddWithValue("@aplicaCentCost_C_R", grupo.aplicaCentCost_C_R);
                            cmd.Parameters.AddWithValue("@subCuenta_C_R", grupo.subCuenta_C_R);
                            cmd.Parameters.AddWithValue("@subSubCuenta_C_R", grupo.subSubCuenta_C_R);
                            cmd.Parameters.AddWithValue("@cuenta_D_R", grupo.cuenta_D_R);
                            cmd.Parameters.AddWithValue("@aplicaCentCost_D_R", grupo.aplicaCentCost_D_R);
                            cmd.Parameters.AddWithValue("@subCuenta_D_R", grupo.subCuenta_D_R);
                            cmd.Parameters.AddWithValue("@subSubCuenta_D_R", grupo.subSubCuenta_D_R);
                            cmd.Parameters.AddWithValue("@cantidad", grupo.cantidad);
                            cmd.Parameters.AddWithValue("@importe", grupo.importe);
                            s = cmd.ExecuteScalar().ToString();
                            con.Close();
                        }
                    }
                    result = new { message = "Se guardo correctamente", code = 1 };
                }
                else
                {
                    result = new { message = "Ya existe este grupo: "+grupo.numGpo, code = 2 };
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

        public Object editarGrupo(GpoMateriales grupo, int numGpo)
        {
            try
            {
                string s;
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;

                Object result = "";
                /*AlmacenEntities db = new AlmacenEntities();
                var us = from u in db.GpoMateriales select u;
                us = us.Where(u => u.numGpo == numGpo);
                var x = us.FirstOrDefault();
                if (us.FirstOrDefault() != null)
                {*/
                    using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                    {

                        string query = "UPDATE GpoMateriales " +
                        "SET numGpo = @numGpoN, descripcion = @descripcion, cuenta_F_Z = @cuenta_F_Z, aplicaCentCost_F_Z = @aplicaCentCost_F_Z" +
                        ", subCuenta_F_Z = @subCuenta_F_Z, subSubCuenta_F_Z = @subSubCuenta_F_Z, cuenta_A_Z = @cuenta_A_Z" +
                        ", aplicaCentCost_A_Z = @aplicaCentCost_A_Z, subCuenta_A_Z = @subCuenta_A_Z, subSubCuenta_A_Z = @subSubCuenta_A_Z" +
                        ", cuenta_C_Z = @cuenta_C_Z, aplicaCentCost_C_Z = @aplicaCentCost_C_Z, subCuenta_C_Z = @subCuenta_C_Z" +
                        ", subSubCuenta_C_Z = @subSubCuenta_C_Z, cuenta_D_Z = @cuenta_D_Z, aplicaCentCost_D_Z = @aplicaCentCost_D_Z" +
                        ", subCuenta_D_Z = @subCuenta_D_Z, subSubCuenta_D_Z = @subSubCuenta_D_Z, cuenta_F_R = @cuenta_F_R" +
                        ", aplicaCentCost_F_R = @aplicaCentCost_F_R, subCuenta_F_R = @subCuenta_F_R, subSubCuenta_F_R = @subSubCuenta_F_R" +
                        ", cuenta_A_R = @cuenta_A_R, aplicaCentCost_A_R = @aplicaCentCost_A_R, subCuenta_A_R = @subCuenta_A_R" +
                        ", subSubCuenta_A_R = @subSubCuenta_A_R, cuenta_C_R = @cuenta_C_R, aplicaCentCost_C_R = @aplicaCentCost_C_R" +
                        ", subCuenta_C_R = @subCuenta_C_R, subSubCuenta_C_R = @subSubCuenta_C_R, cuenta_D_R = @cuenta_D_R" +
                        ", aplicaCentCost_D_R = @aplicaCentCost_D_R, subCuenta_D_R = @subCuenta_D_R, subSubCuenta_D_R = @subSubCuenta_D_R" +
                        ", cantidad = @cantidad, importe = @importe " +
                        "WHERE numGpo = @numGpo";
                        query += " SELECT SCOPE_IDENTITY()";
                        using (SqlCommand cmd = new SqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                        cmd.Parameters.AddWithValue("@numGpoN", grupo.numGpo);
                        cmd.Parameters.AddWithValue("@descripcion", grupo.descripcion);
                        cmd.Parameters.AddWithValue("@cuenta_F_Z", grupo.cuenta_F_Z);
                        cmd.Parameters.AddWithValue("@aplicaCentCost_F_Z", grupo.aplicaCentCost_F_Z);
                        cmd.Parameters.AddWithValue("@subCuenta_F_Z", grupo.subCuenta_F_Z);
                        cmd.Parameters.AddWithValue("@subSubCuenta_F_Z", grupo.subSubCuenta_F_Z);
                        cmd.Parameters.AddWithValue("@cuenta_A_Z", grupo.cuenta_A_Z);
                        cmd.Parameters.AddWithValue("@aplicaCentCost_A_Z", grupo.aplicaCentCost_A_Z);
                        cmd.Parameters.AddWithValue("@subCuenta_A_Z", grupo.subCuenta_A_Z);
                        cmd.Parameters.AddWithValue("@subSubCuenta_A_Z", grupo.subSubCuenta_A_Z);
                        cmd.Parameters.AddWithValue("@cuenta_C_Z", grupo.cuenta_C_Z);
                        cmd.Parameters.AddWithValue("@aplicaCentCost_C_Z", grupo.aplicaCentCost_C_Z);
                        cmd.Parameters.AddWithValue("@subCuenta_C_Z", grupo.subCuenta_C_Z);
                        cmd.Parameters.AddWithValue("@subSubCuenta_C_Z", grupo.subSubCuenta_C_Z);
                        cmd.Parameters.AddWithValue("@cuenta_D_Z", grupo.cuenta_D_Z);
                        cmd.Parameters.AddWithValue("@aplicaCentCost_D_Z", grupo.aplicaCentCost_D_Z);
                        cmd.Parameters.AddWithValue("@subCuenta_D_Z", grupo.subCuenta_D_Z);
                        cmd.Parameters.AddWithValue("@subSubCuenta_D_Z", grupo.subSubCuenta_D_Z);
                        cmd.Parameters.AddWithValue("@cuenta_F_R", grupo.cuenta_F_R);
                        cmd.Parameters.AddWithValue("@aplicaCentCost_F_R", grupo.aplicaCentCost_F_R);
                        cmd.Parameters.AddWithValue("@subCuenta_F_R", grupo.subCuenta_F_R);
                        cmd.Parameters.AddWithValue("@subSubCuenta_F_R", grupo.subSubCuenta_F_R);
                        cmd.Parameters.AddWithValue("@cuenta_A_R", grupo.cuenta_A_R);
                        cmd.Parameters.AddWithValue("@aplicaCentCost_A_R", grupo.aplicaCentCost_A_R);
                        cmd.Parameters.AddWithValue("@subCuenta_A_R", grupo.subCuenta_A_R);
                        cmd.Parameters.AddWithValue("@subSubCuenta_A_R", grupo.subSubCuenta_A_R);
                        cmd.Parameters.AddWithValue("@cuenta_C_R", grupo.cuenta_C_R);
                        cmd.Parameters.AddWithValue("@aplicaCentCost_C_R", grupo.aplicaCentCost_C_R);
                        cmd.Parameters.AddWithValue("@subCuenta_C_R", grupo.subCuenta_C_R);
                        cmd.Parameters.AddWithValue("@subSubCuenta_C_R", grupo.subSubCuenta_C_R);
                        cmd.Parameters.AddWithValue("@cuenta_D_R", grupo.cuenta_D_R);
                        cmd.Parameters.AddWithValue("@aplicaCentCost_D_R", grupo.aplicaCentCost_D_R);
                        cmd.Parameters.AddWithValue("@subCuenta_D_R", grupo.subCuenta_D_R);
                        cmd.Parameters.AddWithValue("@subSubCuenta_D_R", grupo.subSubCuenta_D_R);
                        cmd.Parameters.AddWithValue("@cantidad", grupo.cantidad);
                        cmd.Parameters.AddWithValue("@importe", grupo.importe);
                        cmd.Parameters.AddWithValue("@numGpo", numGpo);
                        s = cmd.ExecuteScalar().ToString();
                            con.Close();
                        }
                    }
                    result = new { message = "Se edito correctamente", code = 1 };
                /*}
                else
                {
                    result = new { message = "No se encontro el grupo", code = 2 };
                }*/

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
    }
}
