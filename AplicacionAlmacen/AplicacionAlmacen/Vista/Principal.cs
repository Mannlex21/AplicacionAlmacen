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
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            const string message = "¿Estas seguro?";
            const string caption = "Cerrar";
            var result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);

            e.Cancel = (result == DialogResult.No);
        }
        private void Principal_Load(object sender, EventArgs e)
        {
            //QUITAR CUANTO NO ESTE CONECTADO EN SERVIDOR
            Red();
        }
        private void tileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            new Vista.CatalogoSubGrupos().Show();
        }
        public void Red()
        {
            Controlador.Clases.ConexionServidor conexion = new Controlador.Clases.ConexionServidor();
            
            if (conexion.verificarConexion())
            {
                panel.Enabled = true;
                lblConexion.Text = conexion.msgConectado;
                lblConexion.ForeColor = conexion.colorConectado;
                lblConexion.BackColor = conexion.colorBackConectado;
            }
            else
            {
                panel.Enabled = false;
                lblConexion.Text = conexion.msgDesconectado;
                lblConexion.ForeColor = conexion.colorDesconectado;
                lblConexion.BackColor = conexion.colorBackDesconectado;
            }
        }
    }
}