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
using AplicacionAlmacen.Modelo;
namespace AplicacionAlmacen.Vista
{
    public partial class CatalogoSubGrupos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static Controlador.SubGruposControlador sg = new Controlador.SubGruposControlador();

        static int totalRecords = 1;
        static private int pageSize = 30;
        static List<SubGrupos> records = new List<SubGrupos>();
        public CatalogoSubGrupos()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            WindowState = FormWindowState.Maximized;
            bindingNavigator.BindingSource = bindingSource;
            bindingSource.CurrentChanged += new System.EventHandler(bindingSource_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList();
        }
        private void bindingSource_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current is null)
            {
                GridControlSub.DataSource = null;
            }
            else
            {
                GridControlSub.DataSource = sg.GetSubGrupos(((int)bindingSource.Current / pageSize), pageSize);
            }


        }
        class PageOffsetList : System.ComponentModel.IListSource
        {
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                totalRecords = sg.numeroSubG();
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }
        private void Recargar()
        {
            bindingNavigator.BindingSource = bindingSource;
            bindingSource.CurrentChanged += new EventHandler(bindingSource_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Recargar();
            Recargar();
        }
    }
}