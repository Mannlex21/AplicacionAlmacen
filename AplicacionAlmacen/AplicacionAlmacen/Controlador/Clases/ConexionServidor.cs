using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionAlmacen.Controlador.Clases
{
    class ConexionServidor
    {
        public static bool verificarConexion()
        {
            try
            {
                Ping myPing = new Ping();
                String host = RutasGenerales.ipServidor;
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Conexion exitosa");
                    return true;
                    // presumably online
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Conexion fallo:" + ex.Message.ToString());
                return false;
            }
        }
    }
}
