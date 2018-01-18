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
    public partial class DetalleMaterialImg : DevExpress.XtraEditors.XtraForm
    {
        static Controlador.SolicitudesControlador s = new Controlador.SolicitudesControlador();
        public DetalleMaterialImg()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            Solicitudes s2 = new Solicitudes();
            this.Text = "Detalle (PreRequisición: "+Solicitudes.preReq+" - Departamento: "+Solicitudes.dep+" - Ejercicio: "+Solicitudes.ejer+")";
            GridControl.DataSource = s.GetSolicitudDet(Solicitudes.preReq, Solicitudes.dep, Solicitudes.ejer);
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

        private void DetalleSolicitud_Load(object sender, EventArgs e)
        {
            
        }
    }
}