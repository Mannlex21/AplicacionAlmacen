using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
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
            try { 
                using (var bd = new AlmacenEntities())
                {
                    var list = bd.Materiales.ToList();
                    return list;
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }
        }
        public int numeroMat()
        {
            try { 
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;
                int cont = 0;
                using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                {
                    string query = "SELECT COUNT(*) FROM Materiales" ;
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
        class listaM
        {
            public string id { get; set; }
        }
        
        public int getConsecutivo(string valor)
        {
            try
            {
                /*var context = new AlmacenEntities();
                var connection = context.Database.Connection;
                int cont = 0;
                using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                {
                    string query = "SELECT COUNT(*) FROM Materiales";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cont = Convert.ToInt32(cmd.ExecuteScalar());
                        con.Close();
                    }
                }
                return cont;*/
                List<listaM> i= new List<listaM>();
                using (var bd = new AlmacenEntities())
                {
                    //IEnumerable<Materiales> query = bd.Materiales;
                    //query = query.Where(m=>m.idMaterial.ToString().Length==7);
                    foreach (var element in bd.Materiales.OrderBy(s=> s.idMaterial))
                    {
                        var temporal="";
                        if (element.idMaterial.ToString().Length>=7)
                        {
                            
                            if (element.idMaterial.ToString().Length == 7)
                            {
                                temporal = "0" + element.idMaterial;
                            }
                            else
                            {
                                temporal = element.idMaterial.ToString();
                            }
                            i.Add(new listaM
                            {
                                id = temporal
                            });
                        }
                    }
                    int cont=0;
                    List<listaM> x = new List<listaM>();
                    foreach (var e in i)
                    {
                        if (e.id.Substring(0, 4)==valor)
                        {
                            
                            var conse = e.id.Substring(e.id.Length - 4);
                            conse=conse.Remove(conse.Length - 1);
                            x.Add(new listaM
                            {
                                id = conse
                            });
                            cont += 1;
                        }
                    }
                    
                    /*foreach (var e in x)
                    {
                        int v=Int32.Parse(e.id);
                        if(v)
                    }*/
                    Console.WriteLine(x.LastOrDefault());
                    
                    return 0;
                }

            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return 0;
            }
            
        }
        public List<Materiales> GetMateriales(int page, int pageSize)
        {
            try { 
                using (var bd = new AlmacenEntities())
                {
                    int pageIndex = Convert.ToInt32(page);
                    IEnumerable<Materiales> query = bd.Materiales;
                    var Results = query.OrderBy(s => s.idMaterial).Skip(pageIndex * pageSize).Take(pageSize).ToList();
                    return Results;
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }
        }
        public List<Materiales> GetMaterialesFiltros(int id, string desc, string marca)
        {
            try
            {
                using (var bd = new AlmacenEntities())
                {
                    IEnumerable<Materiales> query = bd.Materiales;
                    if (id > -1)
                    {
                        query = query.Where(s => s.idMaterial==id);
                    }
                    if (desc != "")
                    {
                        query = query.Where(s => s.descripcion.ToUpper().Contains(desc.ToUpper()));
                    }
                    if (marca != "")
                    {
                        query = query.Where(s => s.marca.ToUpper().Contains(marca.ToUpper()));
                    }
                    var Results = query.OrderBy(s => s.idMaterial).ToList();
                    return Results;
                }
            }
            catch (SqlException odbcEx)
            {
                var error = odbcEx;
                return null;
            }
        }
        public int getDig(string grupo,string subgrupo)
        {
            if (grupo.Length<=1)
            {
                grupo = "0" + grupo;
            }
            if (subgrupo.Length <= 1)
            {
                subgrupo = "0" + subgrupo;
            }

            string valor= getConsecutivo(grupo+subgrupo).ToString();
            string[] Valores = new string[7];
            var Suma = 0;
            var Residuo = 0;
            var Dig = 0;
            var mCos = 0;
            for (int x = 1; x <= 7; x++)
            {
                Valores[x] = valor.Substring(x, 1);
            }
            Suma = (Suma + (Int32.Parse(Valores[7]) * 2));
            Suma = (Suma + (Int32.Parse(Valores[6]) * 3));
            Suma = (Suma + (Int32.Parse(Valores[5]) * 4));
            Suma = (Suma + (Int32.Parse(Valores[4]) * 5));
            Suma = (Suma + (Int32.Parse(Valores[3]) * 6));
            Suma = (Suma + (Int32.Parse(Valores[2]) * 7));
            Suma = (Suma + (Int32.Parse(Valores[1]) * 2));

            mCos = Suma / 11;
            Residuo = (Suma - (11 * mCos));
            Dig = 11 - Residuo;

            if (Dig == 10 || Dig == 11)
            {
                Dig = 0;
            }
            return Dig;
        }
        /*public Object guardarMaterial(Materiales material)
        {
            try
            {
                string s;
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;

                Object result = "";
                AlmacenEntities db = new AlmacenEntities();
                var us = from u in db.Materiales select u;
                us = us.Where(u => u.numGpo == material.numGpo);
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
                    result = new { message = "Ya existe este grupo: " + grupo.numGpo, code = 2 };
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

        }*/
    }
}
