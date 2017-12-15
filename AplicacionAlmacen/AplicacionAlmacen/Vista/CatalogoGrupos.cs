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
    public partial class CatalogoGrupos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static Controlador.GruposControlador g =new Controlador.GruposControlador();
        static Controlador.SubGruposControlador sg = new Controlador.SubGruposControlador();

        static int totalRecords = 1;
        static private int pageSize = 30;
        static List<GpoMateriales> records = new List<GpoMateriales>();
        public CatalogoGrupos()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            WindowState = FormWindowState.Maximized;
            bindingNavigator.BindingSource = bindingSource;
            bindingSource.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList();

            bindingNavigatorS.BindingSource = bindingSourceS;
            bindingSourceS.CurrentChanged += new System.EventHandler(bindingSource2_CurrentChanged);
            bindingSourceS.DataSource = new PageOffsetList2();

        }
        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSource.Current is null)
            {
                GridControl.DataSource = null;
            }
            else
            {
                GridControl.DataSource = g.GetGrupos(((int)bindingSource.Current / pageSize), pageSize);
            }


        }
        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {
            if (bindingSourceS.Current is null)
            {
                GridControlSub.DataSource = null;
            }
            else
            {
                GridControlSub.DataSource = sg.GetSubGrupos(((int)bindingSourceS.Current / pageSize), pageSize);
            }


        }
        class PageOffsetList : System.ComponentModel.IListSource
        {
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                totalRecords = g.numeroGrupo();
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                return pageOffsets;
            }
        }
        class PageOffsetList2 : System.ComponentModel.IListSource
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
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Recargar();
            RecargarSub();
        }
        private void Recargar()
        {
            bindingNavigator.BindingSource = bindingSource;
            bindingSource.CurrentChanged += new EventHandler(bindingSource1_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList();

        }
        private void RecargarSub()
        {
            bindingNavigator.BindingSource = bindingSource;
            bindingSource.CurrentChanged += new EventHandler(bindingSource2_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList2();

        }
    }
}