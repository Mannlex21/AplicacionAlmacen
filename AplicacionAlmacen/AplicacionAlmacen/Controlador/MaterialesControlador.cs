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
        public int getDig(string valor)
        {
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
    }
}
