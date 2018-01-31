using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AplicacionAlmacen.Controlador.Clases
{
    class ConexionServidor
    {
        public string msgDesconectado = "Desconectado";
        public string msgConectado = "Conectado";
        public Color colorDesconectado = Color.FromArgb(255, 58, 58);
        public Color colorConectado = Color.FromArgb(86, 255, 92);
        public Color colorBackConectado = Color.FromArgb(157, 157, 157);
        public Color colorBackDesconectado = Color.FromArgb(203, 203, 203);
        public bool verificarConexion()
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
