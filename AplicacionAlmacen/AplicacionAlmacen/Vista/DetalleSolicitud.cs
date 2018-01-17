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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;

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

            Tabla.RowCellStyle += (sender, e) => {
                GridView view = sender as GridView;
                if (e.Column.FieldName == "cantidad")
                {
                    double exis = Double.Parse(view.GetRowCellValue(e.RowHandle, "existencia").ToString());
                    double cant = Double.Parse(view.GetRowCellValue(e.RowHandle, "cantidad").ToString());
                    if (cant <= exis)
                    {
                        e.Appearance.BackColor = Color.Yellow;
                        e.Appearance.ForeColor = Color.Black;
                    }
                }
                if (e.Column.FieldName == "material")
                {
                    int idMat = Int32.Parse(view.GetRowCellValue(e.RowHandle, "material").ToString());

                    if (!s.existeMaterial(idMat))
                    {
                        e.Appearance.BackColor = Color.Red;
                        e.Appearance.ForeColor = Color.White;
                    }
                    else
                    {
                        e.Appearance.BackColor = Color.LightGreen;
                        e.Appearance.ForeColor = Color.Black;
                    }

                }
            };
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

        private void DetalleSolicitud_Load(object sender, EventArgs e)
        {
            
        }
    }
}