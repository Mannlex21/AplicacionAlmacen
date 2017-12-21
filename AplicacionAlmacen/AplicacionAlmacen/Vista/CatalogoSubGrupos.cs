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
        int contT=0;
        //E=editar,N=nuevo,s=sin seleccionar
        Char tipo = 's';
        int grupoA=0, subGrupoA=0;
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
        private void btnActualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Recargar();
        }
        private void btnNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tipo = 'N'; 
            this.tabControl1.SelectTab(1);
            EnableControls(tabPage2);
        }

        private void CatalogoSubGrupos_Load(object sender, EventArgs e)
        {
            DisableControls(tabPage2);
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
        private void CheckControls(Control con)
        {

            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    CheckControls(c);

                }
                if (con is TextEdit)
                {
                    TextEdit textBox = (TextEdit)con;
                    if (textBox.Text == "")
                    {
                        contT++;
                    }
                }

            }

        }
        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetControls(tabPage2);
            DisableControls(tabPage2);

        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tipo.Equals('N'))
            {
                CheckControls(tabPage2);
                if (contT == 0)
                {
                    SubGrupos s = new SubGrupos();
                    s.descripcion = editDescripcion.Text;
                    s.grupo = Int16.Parse(editGrupo.Text);
                    s.subGrupo = Int16.Parse(editSubGrupo.Text);

                    Object item = sg.guardarSubGrupo(s);

                    System.Reflection.PropertyInfo m = item.GetType().GetProperty("message");
                    System.Reflection.PropertyInfo c = item.GetType().GetProperty("code");
                    String message = (String)(m.GetValue(item, null));
                    int code = (int)(c.GetValue(item, null));

                    if (code == 1)
                    {
                        ResetControls(tabPage2);
                        DisableControls(tabPage2);
                        tipo = 's';
                        Recargar();
                        MessageBox.Show(message, "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else if (code == 2)
                    {
                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                contT = 0;
                
            }
            else if(tipo.Equals('E')){
                CheckControls(tabPage2);
                if (contT == 0)
                {
                    SubGrupos s = new SubGrupos();
                    s.descripcion = editDescripcion.Text;
                    s.grupo = Int16.Parse(editGrupo.Text);
                    s.subGrupo = Int16.Parse(editSubGrupo.Text);

                    Object item = sg.editarSubGrupo(s,grupoA,subGrupoA);

                    System.Reflection.PropertyInfo m = item.GetType().GetProperty("message");
                    System.Reflection.PropertyInfo c = item.GetType().GetProperty("code");
                    String message = (String)(m.GetValue(item, null));
                    int code = (int)(c.GetValue(item, null));

                    if (code == 1)
                    {
                        ResetControls(tabPage2);
                        DisableControls(tabPage2);
                        tipo = 's';
                        Recargar();
                        MessageBox.Show(message, "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else if (code == 2)
                    {
                        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                contT = 0;
            }
            else if (tipo.Equals('s'))
            {

            }
            
            
        }

        private void btnBorrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int r=TablaSub.GetSelectedRows()[0];
            SubGrupos s = new SubGrupos();
            s.descripcion = TablaSub.GetRowCellValue(r, "descripcion").ToString();
            s.grupo = Int16.Parse(TablaSub.GetRowCellValue(r, "grupo").ToString());
            s.subGrupo = Int16.Parse(TablaSub.GetRowCellValue(r, "subGrupo").ToString());
            
            Object item = sg.borrarSubGrupo(s);

            System.Reflection.PropertyInfo m = item.GetType().GetProperty("message");
            System.Reflection.PropertyInfo c = item.GetType().GetProperty("code");
            String message = (String)(m.GetValue(item, null));
            int code = (int)(c.GetValue(item, null));

            if (code == 1)
            {
                Recargar();
                MessageBox.Show(message, "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                
            }
            else if (code == 2)
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tipo = 'E';
            int r = TablaSub.GetSelectedRows()[0];
            editDescripcion.Text = TablaSub.GetRowCellValue(r, "descripcion").ToString();
            editGrupo.Text = TablaSub.GetRowCellValue(r, "grupo").ToString();
            editSubGrupo.Text = TablaSub.GetRowCellValue(r, "subGrupo").ToString();
            grupoA = Int16.Parse(TablaSub.GetRowCellValue(r, "grupo").ToString());
            subGrupoA = Int16.Parse(TablaSub.GetRowCellValue(r, "subGrupo").ToString());

            this.tabControl1.SelectTab(1);
            EnableControls(tabPage2);
        }
    }
}