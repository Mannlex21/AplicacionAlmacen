﻿using System;
using System.Collections.Generic;
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
            using (var bd = new AlmacenEntities())
            {
                var list = bd.Materiales.ToList();
                return list;
            }
        }
        public int numeroMat()
        {
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
        public List<Materiales> GetMateriales(int page, int pageSize)
        {
            using (var bd = new AlmacenEntities())
            {
                int pageIndex = Convert.ToInt32(page);
                var Results = bd.Materiales.OrderBy(s => s.idMaterial).Skip(pageIndex * pageSize).Take(pageSize).ToList();
                return Results;
            }
           
            
        }
    }
}