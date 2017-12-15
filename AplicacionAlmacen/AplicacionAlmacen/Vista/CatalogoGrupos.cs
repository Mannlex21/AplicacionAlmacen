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
        static Controlador.GruposControlador g =new Controlador.GruposControlador();
        static Controlador.SubGruposControlador sg = new Controlador.SubGruposControlador();
        public CatalogoGrupos()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            WindowState = FormWindowState.Maximized;
            GridControl.DataSource = g.GetAllGrupos();
            GridControlSub.DataSource = sg.GetAllSubGrupos();

        }
        
    }
}