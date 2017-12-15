using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionAlmacen.Modelo;
namespace AplicacionAlmacen.Controlador
{
    class DepartamentosControlador
    {
        public List<Departamentos> GetAllDepartamentos()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Departamentos;
                return list.ToList();
            }
        }
        public List<Departamentos> GetDepartamentos()
        {
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Departamentos;
                return list.ToList();
            }
        }
        public int numeroDep()
        {
            var context = new AlmacenEntities();
            var connection = context.Database.Connection;
            int cont = 0;
            using (SqlConnection con = new SqlConnection(connection.ConnectionString))
            {
                string query = "SELECT COUNT(*) FROM Departamentos";
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
