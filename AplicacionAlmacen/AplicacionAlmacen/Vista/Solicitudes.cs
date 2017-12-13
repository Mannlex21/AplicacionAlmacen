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
namespace AplicacionAlmacen.Vista
{
    public partial class Solicitudes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static int totalRecords = 1;
        static private int pageSize = 30;
        static Controlador.Solicitudes s = new Controlador.Solicitudes();
        static List<Solicitud_Requisiciones> records = new List<Solicitud_Requisiciones>();
        public Solicitudes()
        {
            InitializeComponent();
            bindingNavigator.BindingSource= bindingSource;
            bindingSource.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList();
        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            GridControl.DataSource = s.GetSolicitudes("ASC", ((int)bindingSource.Current/pageSize), pageSize);
           
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
    }
}



