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
    public partial class CatalogoGrupos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public CatalogoGrupos()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            WindowState = FormWindowState.Maximized;
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void CatalogoGrupos_Load(object sender, EventArgs e)
        {

        }
    }
}