using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace AplicacionAlmacen.Vista
{
    public partial class Solicitudes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Solicitudes()
        {
            InitializeComponent();
            Controlador.Solicitudes s = new Controlador.Solicitudes();
            GridControl.DataSource=s.existe();
        }

        private void GridControl_Click(object sender, EventArgs e)
        {

        }
    }
}