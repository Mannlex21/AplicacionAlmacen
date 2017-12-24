using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using AplicacionAlmacen.Controlador;
using DevExpress.LookAndFeel;
using System.Net.NetworkInformation;
namespace AplicacionAlmacen
{
    public partial class Principal : DevExpress.XtraEditors.XtraForm
    {
        
        public Principal()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            panel.BackColor = Color.FromArgb(50, Color.Black);
            NetworkChange.NetworkAvailabilityChanged += AvailabilityChanged;
        }
        private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            Red();
        }

        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            new Vista.Solicitudes().Show();
        }

        private void tileItem4_ItemClick(object sender, TileItemEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            new Vista.CatalogoMateriales().Show();
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            new Vista.CatalogoGrupos().Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            //QUITAR CUANTO NO ESTE CONECTADO EN SERVIDOR
            //Red();
        }
        private void tileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            new Vista.CatalogoSubGrupos().Show();
        }
        public void Red()
        {
            /*if (e.IsAvailable)*/
            if (verificarConexion())
            {
                tileItem1.Enabled = true;
                tileItem2.Enabled = true;
                tileItem3.Enabled = true;
                tileItem4.Enabled = true;
                lblConexion.Text = "";
            }
            else
            {
                tileItem1.Enabled = false;
                tileItem2.Enabled = false;
                tileItem3.Enabled = false;
                tileItem4.Enabled = false;
                lblConexion.ForeColor = System.Drawing.Color.Red;
                lblConexion.Text = "No hay conexión";
                lblConexion.BackColor = Color.Transparent;
            }
        }
        public bool verificarConexion()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "172.16.0.5";
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
                return false;
                Console.WriteLine("Conexion fallo:" + ex.Message.ToString());
            }
        }
    }
}