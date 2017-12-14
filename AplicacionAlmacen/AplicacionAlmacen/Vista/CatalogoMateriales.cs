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
using AplicacionAlmacen.Modelo;
namespace AplicacionAlmacen.Vista
{
    public partial class CatalogoMateriales : DevExpress.XtraEditors.XtraForm
    {
        static Controlador.MaterialesControlador s= new Controlador.MaterialesControlador();
        static int totalRecords = 1;
        static private int pageSize = 30;
        static List<Materiales> records = new List<Materiales>();
        public CatalogoMateriales()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            WindowState = FormWindowState.Maximized;
            bindingNavigator.BindingSource = bindingSource;
            bindingSource.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList();
            

        }
        void afterLoad(object sender, EventArgs e)
        {
            
            

        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            GridControl.DataSource = s.GetMateriales(((int)bindingSource.Current / pageSize), pageSize);

        }

        class PageOffsetList : System.ComponentModel.IListSource
        {
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                totalRecords = s.numeroMat();
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }

        private void CatalogoMateriales_Load(object sender, EventArgs e)
        {
            
        }
    }
}