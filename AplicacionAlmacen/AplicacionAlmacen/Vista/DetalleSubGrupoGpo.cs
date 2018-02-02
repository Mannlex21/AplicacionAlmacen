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
    public partial class DetalleSubGrupoGpo : DevExpress.XtraEditors.XtraForm
    {
        static Controlador.GruposControlador g = new Controlador.GruposControlador();
        CatalogoSubGrupos formLocal;
        public DetalleSubGrupoGpo(CatalogoSubGrupos formExterno)
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            try { 
                formLocal = formExterno;
                GridControl.DataSource = g.GetAllGruposLigero();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridControl_DoubleClick(object sender, EventArgs e)
        {
            try { 
                int r = Tabla.GetSelectedRows()[0];
                string grupo = Tabla.GetRowCellValue(r, "numGpo").ToString();
                formLocal.textGrupo = grupo;
                formLocal.setTextGrupo();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}