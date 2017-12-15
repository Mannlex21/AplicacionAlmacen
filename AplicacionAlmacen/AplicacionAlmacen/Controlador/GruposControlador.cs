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
            using (var bd = new AlmacenEntities())
            {
                var list = bd.GpoMateriales;
                return list.ToList();
            }
        }
        public List<GpoMateriales> GetGrupos(int page, int pageSize)
        {
            using (var bd = new AlmacenEntities())
            {
                int pageIndex = Convert.ToInt32(page);
                var Results = bd.GpoMateriales.OrderBy(s => s.numGpo).Skip(pageIndex * pageSize).Take(pageSize).ToList();
                return Results;
            }
        }
        public int numeroGrupo()
        {
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
    }
}
