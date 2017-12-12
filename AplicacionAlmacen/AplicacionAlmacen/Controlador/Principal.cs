using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AplicacionAlmacen;
using AplicacionAlmacen.Modelo;

namespace AplicacionAlmacen.Controlador
{
    class Principal
    {
        public List<Materiales> metodo()
        {
            AlmacenEntities db = new AlmacenEntities();
            var context = new AlmacenEntities();
            var connection = context.Database.Connection;
            Configuracion e = new Configuracion();
            using (SqlConnection con = new SqlConnection(connection.ConnectionString))
            {
                string s;
                string query = "SELECT*FROM DetallesUsuarios";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    //cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                    //s = cmd.ExecuteScalar().ToString();
                    s = cmd.ToString();
                    con.Close();
                    return db.Materiales.ToList();
                }
            }



        }
    }
}
