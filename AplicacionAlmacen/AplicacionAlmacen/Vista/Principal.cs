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

namespace AplicacionAlmacen
{
    public partial class Principal : DevExpress.XtraEditors.XtraForm
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controlador.Principal p = new Controlador.Principal();
            System.Diagnostics.Debug.WriteLine(p.metodo().FirstOrDefault().marca);
        }
    }
}