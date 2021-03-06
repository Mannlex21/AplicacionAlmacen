﻿using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AplicacionAlmacen.Modelo;
namespace AplicacionAlmacen.Controlador
{
    class MaterialesControlador
    {
        string carpetaImagen = RutasGenerales.carpetaImagen;
        string carpetaAdjunto = RutasGenerales.carpetaAdjunto;

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
                        query = query.Where(s => s.idMaterial.ToString().Contains(id.ToString()));
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
                using (var bd = new AlmacenEntities())
                {
                    Object result = "";
                    AlmacenEntities db = new AlmacenEntities();
                    var us = db.Materiales.Where(u => u.idMaterial == material.idMaterial).FirstOrDefault();
                    if (us == null)
                    {
                        bd.Materiales.Add(material);
                        bd.SaveChanges();
                        bd.MaterialesContable.Add(materialContable);
                        bd.SaveChanges();
                        result = new { message = "Se guardo correctamente", code = 1 };
                    }
                    else
                    {
                        result = new { message = "Ya existe este material: " + material.idMaterial, code = 2 };
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
        public Object editarMaterial(Materiales material, MaterialesContable materialesContable)
        {
            try
            {
                
                using (var bd = new AlmacenEntities())
                {
                    Object result = "";
                    var idMC = bd.MaterialesContable.AsNoTracking().Where(s => s.idMaterial == material.idMaterial).FirstOrDefault().idMaterialesCont;
                    materialesContable.idMaterialesCont = idMC;
                    bd.Entry(material).State = System.Data.Entity.EntityState.Modified;
                    bd.Entry(materialesContable).State = System.Data.Entity.EntityState.Modified;
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
        public String crearImagen(String url, String primero, String id)
        {
            try
            {
                url = url.ToLower();

                String ext = (url.EndsWith(".png") )? ".png" : ".jpg";
                try
                {
                    String nuevo = carpetaImagen + primero+"-" + id + ext;
                    File.Copy(url, nuevo, true);
                    return nuevo;
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            return "";
        }
        public void eliminarImagen(String img)
        {
            try
            {
                string dir = carpetaImagen + img;
                File.Delete(dir);
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }
        public Bitmap imagen(String img)
        {
            try
            {
                FileStream fs = new FileStream(carpetaImagen + img, FileMode.Open, FileAccess.Read);
                Image foto = Image.FromStream(fs);
                fs.Close();
                return (Bitmap)foto;
            }
            catch (IOException)
            {
                return null;
            }
        }
        public String actualizarImagen(String img, String url, String tab, String id)
        {
            eliminarImagen(img);
            return crearImagen(url, tab, id);
        }
        public string crearCarpetaAdjunto(string dir)
        {
            try
            {
                if (Directory.Exists(carpetaAdjunto + dir))
                {
                    Console.WriteLine("That path exists already.");
                    return carpetaAdjunto + dir;
                }
                else
                {
                    DirectoryInfo di = Directory.CreateDirectory(carpetaAdjunto+dir);
                    return carpetaAdjunto + dir;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
                return "";
            }
        }
        public void crearImagenes(string url, string primero, string id,string urlN)
        {
            try
            {
                url = url.ToLower();
                String[] urlA = url.Split(',');
                for (int i = 0;i < urlA.Length;i++)
                {
                    string nuevo = "";
                    if (urlA[i] != "")
                    {
                        string[] parts = urlA[i].Split('\\');
                        string[] ext = parts[parts.Length - 1].Split('.');
                        string[] files = Directory.GetFiles(urlN);
                        int fc = files.Length + 1;

                        nuevo ="M-"+fc+"."+ext[1];
                        File.Copy(urlA[i], urlN + "\\" + nuevo, true);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
        }
        public void eliminarAdjuntos(string dir)
        {
            if (dir!="")
            {
                Directory.Delete(dir, true);
            }
        }
    }
}
