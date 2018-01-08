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
namespace AplicacionAlmacen.Vista
{
    public partial class DetalleSolicitud : DevExpress.XtraEditors.XtraForm
    {
        static Controlador.SolicitudesControlador s = new Controlador.SolicitudesControlador();
        public DetalleSolicitud()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            Solicitudes s2 = new Solicitudes();

            GridControl.DataSource = s.GetSolicitudDet(Solicitudes.preReq, Solicitudes.dep, Solicitudes.ejer);
            bindingSource.CurrentChanged += new EventHandler(bindingSource_CurrentChanged);
        }
        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current is null)
            {
                GridControl.DataSource = null;
            }
            else
            {
                GridControl.DataSource = s.GetSolicitudDet(Solicitudes.preReq, Solicitudes.dep, Solicitudes.ejer);
            }


        }
    }
}