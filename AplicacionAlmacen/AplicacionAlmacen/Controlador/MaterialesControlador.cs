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
        public List<Materiales> GetMateriales(int id, string desc, string marca,int page, int pageSize)
        {
            try { 
                using (var bd = new AlmacenEntities())
                {
                    int pageIndex = Convert.ToInt32(page);
                    IEnumerable<Materiales> query = bd.Materiales;
                    if (id>-1)
                    {
                        query = query.Where(s=> s.idMaterial.ToString().Contains(id.ToString()));
                    }
                    if (desc!="")
                    {
                        query = query.Where(s => s.descripcion.ToUpper().Contains(desc.ToUpper()));
                    }
                    if (marca!="")
                    {
                        query = query.Where(s => s.marca.ToUpper().Contains(marca.ToUpper()));
                    }
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
    }
}
