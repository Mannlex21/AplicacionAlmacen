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
            panel.BackColor = Color.FromArgb(50, Color.Black);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controlador.PrincipalControlador p = new Controlador.PrincipalControlador();
            System.Diagnostics.Debug.WriteLine(p.metodo().FirstOrDefault().marca);
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
    }
}