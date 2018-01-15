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
using AplicacionAlmacen.Modelo;
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Views.Grid;

namespace AplicacionAlmacen.Vista
{
    public partial class Solicitudes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static int preReq;
        public static int dep;
        public static int ejer;
        static int totalRecords = 1;
        static private int pageSize = 30;
        static Controlador.SolicitudesControlador s = new Controlador.SolicitudesControlador();
        static Controlador.DepartamentosControlador d = new Controlador.DepartamentosControlador();
        static List<Solicitud_Requisiciones> records = new List<Solicitud_Requisiciones>();
        public Solicitudes()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            WindowState = FormWindowState.Maximized;

            bindingNavigator.BindingSource= bindingSource;
            bindingSource.CurrentChanged += new EventHandler(bindingSource1_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList();
            foreach (var t in d.GetDepartamentos())
            {
                depaCombo.Items.Add(t.descripcion);
            }

        }
        private void Recargar()
        {
            bindingNavigator.BindingSource = bindingSource;
            bindingSource.CurrentChanged += new EventHandler(bindingSource1_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList();

        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if(bindingSource.Current is null) {
                GridControl.DataSource = null;
            }
            else {
                GridControl.DataSource = s.GetSolicitudes(depaCombo.Text, ((int)bindingSource.Current / pageSize), pageSize);
            }
            
            
        }

        class PageOffsetList : System.ComponentModel.IListSource
        {
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                totalRecords = s.numeroSol();
                // Return a list of page offsets based on "totalRecords" and "pageSize"
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            new CatalogoMateriales().Show();
        }

        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            new CatalogoGrupos().Show();
        }

        private void depaCombo_Click(object sender, EventArgs e)
        {
            GridControl.DataSource = s.GetSolicitudes(depaCombo.Text, ((int)bindingSource.Current / pageSize), pageSize);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Recargar();
        }

        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int r = Tabla.GetSelectedRows()[0];
            preReq = Int32.Parse(Tabla.GetRowCellValue(r, "preRequisicion").ToString());
            dep = Int32.Parse(Tabla.GetRowCellValue(r, "departamento").ToString());
            ejer = Int32.Parse(Tabla.GetRowCellValue(r, "ejercicio").ToString());
            new DetalleSolicitud().Show();
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            
            const string msg = "La requisición debe contener materiales existentes.¿Desea continuar?";
            const string caption = "Asignación";
            var res = MessageBox.Show(msg, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                Cursor.Current = Cursors.WaitCursor;
                int r = Tabla.GetSelectedRows()[0];
                string ciclo = Tabla.GetRowCellValue(r, "ciclo").ToString();
                string departamento = Tabla.GetRowCellValue(r, "departamento").ToString();
                int ejercicio = Int32.Parse(Tabla.GetRowCellValue(r, "ejercicio").ToString());
                int preRequisicion = Int32.Parse(Tabla.GetRowCellValue(r, "preRequisicion").ToString());

                Object item = s.claveSolicitud(ciclo, departamento, ejercicio);

                System.Reflection.PropertyInfo m = item.GetType().GetProperty("message");
                System.Reflection.PropertyInfo c = item.GetType().GetProperty("code");
                System.Reflection.PropertyInfo re = item.GetType().GetProperty("result");
                String message = (String)(m.GetValue(item, null));
                String result = (String)(re.GetValue(item, null));
                int code = (int)(c.GetValue(item, null));

                if (code == 1)
                {
                    string clave = result;

                    Object item2 = s.asignarClave(clave, preRequisicion);

                    System.Reflection.PropertyInfo m2 = item2.GetType().GetProperty("message");
                    System.Reflection.PropertyInfo c2 = item2.GetType().GetProperty("code");
                    String message2 = (String)(m2.GetValue(item2, null));
                    int code2 = (int)(c2.GetValue(item2, null));
                    if (code2 == 1)
                    {
                        Recargar();
                        MessageBox.Show(message2, "OK", MessageBoxButtons.OK, MessageBoxIcon.None);

                    }
                    else
                    {
                        MessageBox.Show(message2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {

            }
        }
    }
}



