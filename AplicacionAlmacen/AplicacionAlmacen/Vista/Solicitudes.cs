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
            new CatalogoGrupos().Show();
        }

        private void depaCombo_Click(object sender, EventArgs e)
        {
            GridControl.DataSource = s.GetSolicitudes(depaCombo.Text, ((int)bindingSource.Current / pageSize), pageSize);
            Console.WriteLine(depaCombo.Text);
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Recargar();
        }

        
    }
}



