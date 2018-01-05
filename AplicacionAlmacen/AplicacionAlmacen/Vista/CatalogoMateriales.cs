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
using DevExpress.LookAndFeel;
namespace AplicacionAlmacen.Vista
{
    public partial class CatalogoMateriales : DevExpress.XtraBars.Ribbon.RibbonForm
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
            if (bindingSource.Current is null)
            {
                GridControl.DataSource = null;
            }
            else
            {
                int id;
                if (editBusquedaId.Text.Equals(""))
                {
                    id = -1;
                }
                else
                {
                    id = Int32.Parse(editBusquedaId.Text);
                }
                GridControl.DataSource = s.GetMateriales(id, editBusquedaDesc.Text, editBusquedaMarca.Text, ((int)bindingSource.Current / pageSize), pageSize);
            }
            

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
        
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Recargar();
        }
        private void Recargar()
        {
            bindingNavigator.BindingSource = bindingSource;
            bindingSource.CurrentChanged += new EventHandler(bindingSource1_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.tabControl1.SelectTab(1);
            EnableControls(tabPage2);
        }
        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }
        private void EnableControls(Control con)
        {

            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    EnableControls(c);
                }
                con.Enabled = true;
            }

        }
        private void ResetControls(Control con)
        {

            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    ResetControls(c);

                }
                if (con is TextEdit)
                {
                    TextEdit textBox = (TextEdit)con;
                    textBox.Text = null;
                }

            }

        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetControls(tabPage2);
            DisableControls(tabPage2);
        }

        private void CatalogoMateriales_Load(object sender, EventArgs e)
        {
            DisableControls(tabPage2);
        }

        private void editBusqued_Press(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar=='\r')
            {
                e.Handled = true;
            }
        }
        private void editBusquedaId_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarFiltro();
            }

        }
        private void editBusquedaDesc_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarFiltro();
            }
        }
        private void editBusquedaMarca_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                buscarFiltro();
            }
        }
        private void buscarFiltro()
        {
            Cursor.Current = Cursors.WaitCursor;
            if (editBusquedaId.Text!="" || editBusquedaMarca.Text!="" || editBusquedaDesc.Text!="")
            {
                GridControl.DataSource = s.GetMateriales(editBusquedaId.Text.Equals("")? -1: Int32.Parse(editBusquedaId.Text), editBusquedaDesc.Text, editBusquedaMarca.Text, ((int)bindingSource.Current / pageSize), pageSize);
            }
            
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            editBusquedaDesc.Text = "";
            editBusquedaId.Text = "";
            editBusquedaMarca.Text = "";
            Recargar();
        }
    }
}