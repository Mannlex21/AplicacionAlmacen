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
using DevExpress.LookAndFeel;
using System.Net.NetworkInformation;

namespace AplicacionAlmacen.Vista
{
    public partial class DetalleMaterial : DevExpress.XtraEditors.XtraForm
    {
        static Controlador.MaterialesControlador s = new Controlador.MaterialesControlador();
        public DetalleMaterial()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            try
            {
                CatalogoMateriales m = new CatalogoMateriales();
                boxImg.Image = s.imagen(CatalogoMateriales.imgNombre);
                boxImg.SizeMode = PictureBoxSizeMode.Zoom;
                NetworkChange.NetworkAvailabilityChanged += AvailabilityChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            Red();
        }
        private void DetalleMaterial_Load(object sender, EventArgs e)
        {
            Red();
        }
        public void Red()
        {
            Controlador.Clases.ConexionServidor conexion = new Controlador.Clases.ConexionServidor();
            if (conexion.verificarConexion())
            {
                boxImg.Enabled = true;
            }
            else
            {
                boxImg.Enabled = false;
            }
        }
    }
}