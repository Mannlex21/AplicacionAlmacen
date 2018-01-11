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
                List<listaM> i= new List<listaM>();
                using (var bd = new AlmacenEntities())
                {
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
                        }
                    }
                    int max = 0;
                    if (x.Count!=0)
                    {
                        max = Int32.Parse(x.Max(t => t.id));
                    }
                    return max+1;
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
        public MaterialesContable GetMaterialContable(int idMaterial)
        {
            try
            {
                using (var bd = new AlmacenEntities())
                {
                    IEnumerable<MaterialesContable> query = bd.MaterialesContable;
                    var Results = query.Where(m=>m.idMaterial==idMaterial).ToList();
                    return Results.FirstOrDefault();
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
        public string getDig(string grupo,string subgrupo)
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
            if (valor.Length == 2)
            {
                valor = "0" + valor;
            }
            else if (valor.Length == 1)
            {
                valor = "00" + valor;
            }
            string result = grupo + "" + subgrupo + "" + valor;
            string[] Valores = new string[7];
            var Suma = 0;
            var Residuo = 0;
            var Dig = 0;
            var mCos = 0;
            for (int x = 0; x < 7; x++)
            {
                Valores[x] = result[x].ToString();
            }
            Suma = (Suma + (Int32.Parse(Valores[6]) * 2));
            Suma = (Suma + (Int32.Parse(Valores[5]) * 3));
            Suma = (Suma + (Int32.Parse(Valores[4]) * 4));
            Suma = (Suma + (Int32.Parse(Valores[3]) * 5));
            Suma = (Suma + (Int32.Parse(Valores[2]) * 6));
            Suma = (Suma + (Int32.Parse(Valores[1]) * 7));
            Suma = (Suma + (Int32.Parse(Valores[0]) * 2));

            mCos = Suma / 11;
            Residuo = (Suma - (11 * mCos));
            Dig = 11 - Residuo;

            if (Dig == 10 || Dig == 11)
            {
                Dig = 0;
            }
            
            result = result + Dig;
            return result;
        }
        public Object guardarMaterial(Materiales material, MaterialesContable materialContable)
        {
            try
            {
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;

                Object result = "";
                AlmacenEntities db = new AlmacenEntities();
                var us = from u in db.Materiales select u;
                us = us.Where(u => u.idMaterial == material.idMaterial);
                var x = us.FirstOrDefault();
                if (us.FirstOrDefault() == null)
                {
                    context.Materiales.Add(material);
                    context.SaveChanges();
                    context.MaterialesContable.Add(materialContable);
                    context.SaveChanges();
                    result = new { message = "Se guardo correctamente", code = 1 };
                }
                else
                {
                    result = new { message = "Ya existe este grupo: " + material.idMaterial, code = 2 };
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
        public Object editarMaterial(Materiales material, MaterialesContable materialesContable)
        {
            try
            {
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;
                Object result = "";
                using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                {
                    context.Entry(material).State=System.Data.Entity.EntityState.Modified;
                    context.Entry(materialesContable).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }
                result = new { message = "Se edito correctamente", code = 1 };

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
        public Object borrarMaterial(int idMaterial)
        {
            try
            {
                string s;
                var context = new AlmacenEntities();
                var connection = context.Database.Connection;
                using (SqlConnection con = new SqlConnection(connection.ConnectionString))
                {
                    string query = "DELETE FROM MaterialesContable WHERE idMaterial=@idMaterial2 " +
                                   " DELETE FROM Materiales WHERE idMaterial=@idMaterial;";
                    query += " SELECT SCOPE_IDENTITY()";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        cmd.Parameters.AddWithValue("@idMaterial", idMaterial);
                        cmd.Parameters.AddWithValue("@idMaterial2", idMaterial);
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
