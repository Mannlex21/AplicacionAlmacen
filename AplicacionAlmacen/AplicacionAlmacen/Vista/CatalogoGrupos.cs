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

        static int totalRecords = 1;
        static private int pageSize = 30;
        static List<GpoMateriales> records = new List<GpoMateriales>();
        int contT = 0;
        //E=editar,N=nuevo,s=sin seleccionar
        Char tipo = 's';
        int numGpoA=0;
        public CatalogoGrupos()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            WindowState = FormWindowState.Maximized;
            bindingNavigator.BindingSource = bindingSource;
            bindingSource.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList();

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
            
            tipo = 'N';
            this.tabControl1.SelectTab(1);
            EnableControls(tabPage3);
            ResetControls(tabPage3);
        }

        private void CatalogoGrupos_Load(object sender, EventArgs e)
        {
            DisableControls(tabPage3);
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
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ResetControls(tabPage3);
            DisableControls(tabPage3);
        }

        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tipo.Equals('N'))
            {
                CheckControls(tabPage3);
                if (contT == 0)
                {
                    GpoMateriales s = new GpoMateriales();
                    //numGpo,descripcion,cuenta_F_Z,aplicaCentCost_F_Z,subCuenta_F_Z,subSubCuenta_F_Z,cuenta_A_Z,aplicaCentCost_A_Z,
                    //subCuenta_A_Z,subSubCuenta_A_Z,cuenta_C_Z,aplicaCentCost_C_Z,subCuenta_C_Z,subSubCuenta_C_Z,cuenta_D_Z,
                    //aplicaCentCost_D_Z,subCuenta_D_Z,subSubCuenta_D_Z,cuenta_F_R,aplicaCentCost_F_R,subCuenta_F_R,subSubCuenta_F_R,
                    //cuenta_A_R,aplicaCentCost_A_R,subCuenta_A_R,subSubCuenta_A_R,cuenta_C_R,aplicaCentCost_C_R,subCuenta_C_R,
                    //subSubCuenta_C_R,cuenta_D_R,aplicaCentCost_D_R,subCuenta_D_R,subSubCuenta_D_R,cantidad,importe
                    s.numGpo =Int16.Parse(editNumeroG.Text);
                    s.descripcion = editDescripcion.Text;
                    s.cuenta_F_Z = Int32.Parse(editCuFZ.Text);
                    s.aplicaCentCost_F_Z = editApliCeFZ.Checked;
                    s.subCuenta_F_Z = Int32.Parse(editSubCuFZ.Text);
                    s.subSubCuenta_F_Z = Int32.Parse(editSubSCuFZ.Text);
                    s.cuenta_A_Z = Int32.Parse(editCuAZ.Text);
                    s.aplicaCentCost_A_Z = editApliCeAZ.Checked;
                    s.subCuenta_A_Z = Int32.Parse(editSubCuAZ.Text);
                    s.subSubCuenta_A_Z = Int32.Parse(editSubSCuAZ.Text);
                    s.cuenta_C_Z= Int32.Parse(editCuCZ.Text);
                    s.aplicaCentCost_C_Z = editApliCeCZ.Checked;
                    s.subCuenta_C_Z = Int32.Parse(editSubCuCZ.Text);
                    s.subSubCuenta_C_Z = Int32.Parse(editSubCuCZ.Text);
                    s.cuenta_D_Z = Int32.Parse(editCuDZ.Text);
                    s.aplicaCentCost_D_Z = editApliCeDZ.Checked;
                    s.subCuenta_D_Z = Int32.Parse(editSubCuDZ.Text);
                    s.subSubCuenta_D_Z = Int32.Parse(editSubSCuDZ.Text);
                    s.cuenta_F_R = Int32.Parse(editCuFR.Text);
                    s.aplicaCentCost_F_R = editApliCeFR.Checked;
                    s.subCuenta_F_R = Int32.Parse(editSubCuFR.Text);
                    s.subSubCuenta_F_R = Int32.Parse(editSubSCuFR.Text);
                    s.cuenta_A_R = Int32.Parse(editCuAR.Text);
                    s.aplicaCentCost_A_R = editApliCeAR.Checked;
                    s.subCuenta_A_R = Int32.Parse(editSubCuAR.Text);
                    s.subSubCuenta_A_R = Int32.Parse(editSubSCuAR.Text);
                    s.cuenta_C_R = Int32.Parse(editCuCR.Text);
                    s.aplicaCentCost_C_R = editApliCeCR.Checked;
                    s.subCuenta_C_R = Int32.Parse(editSubCuCR.Text);
                    s.subSubCuenta_C_R = Int32.Parse(editSubSCuCR.Text);
                    s.cuenta_D_R = Int32.Parse(editCuDR.Text);
                    s.aplicaCentCost_D_R = editApliCeDR.Checked;
                    s.subCuenta_D_R = Int32.Parse(editSubCuDR.Text);
                    s.subSubCuenta_D_R = Int32.Parse(editSubSCuDR.Text);
                    s.cantidad = decimal.Parse(editCantidad.Text);
                    s.importe = decimal.Parse(editImporte.Text);

                    Object item = g.editarGrupo(s,numGpoA);

                    System.Reflection.PropertyInfo m = item.GetType().GetProperty("message");
                    System.Reflection.PropertyInfo c = item.GetType().GetProperty("code");
                    String message = (String)(m.GetValue(item, null));
                    int code = (int)(c.GetValue(item, null));

                    if (code == 1)
                    {
                        ResetControls(tabPage3);
                        DisableControls(tabPage3);
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
            else if (tipo.Equals('E'))
            {
                CheckControls(tabPage3);
                if (contT == 0)
                {
                    GpoMateriales s = new GpoMateriales();
                    s.numGpo = Int16.Parse(editNumeroG.Text);
                    s.descripcion = editDescripcion.Text;
                    s.cuenta_F_Z = Int32.Parse(editCuFZ.Text);
                    s.aplicaCentCost_F_Z = editApliCeFZ.Checked;
                    s.subCuenta_F_Z = Int32.Parse(editSubCuFZ.Text);
                    s.subSubCuenta_F_Z = Int32.Parse(editSubSCuFZ.Text);
                    s.cuenta_A_Z = Int32.Parse(editCuAZ.Text);
                    s.aplicaCentCost_A_Z = editApliCeAZ.Checked;
                    s.subCuenta_A_Z = Int32.Parse(editSubCuAZ.Text);
                    s.subSubCuenta_A_Z = Int32.Parse(editSubSCuAZ.Text);
                    s.cuenta_C_Z = Int32.Parse(editCuCZ.Text);
                    s.aplicaCentCost_C_Z = editApliCeCZ.Checked;
                    s.subCuenta_C_Z = Int32.Parse(editSubCuCZ.Text);
                    s.subSubCuenta_C_Z = Int32.Parse(editSubCuCZ.Text);
                    s.cuenta_D_Z = Int32.Parse(editCuDZ.Text);
                    s.aplicaCentCost_D_Z = editApliCeDZ.Checked;
                    s.subCuenta_D_Z = Int32.Parse(editSubCuDZ.Text);
                    s.subSubCuenta_D_Z = Int32.Parse(editSubSCuDZ.Text);
                    s.cuenta_F_R = Int32.Parse(editCuFR.Text);
                    s.aplicaCentCost_F_R = editApliCeFR.Checked;
                    s.subCuenta_F_R = Int32.Parse(editSubCuFR.Text);
                    s.subSubCuenta_F_R = Int32.Parse(editSubSCuFR.Text);
                    s.cuenta_A_R = Int32.Parse(editCuAR.Text);
                    s.aplicaCentCost_A_R = editApliCeAR.Checked;
                    s.subCuenta_A_R = Int32.Parse(editSubCuAR.Text);
                    s.subSubCuenta_A_R = Int32.Parse(editSubSCuAR.Text);
                    s.cuenta_C_R = Int32.Parse(editCuCR.Text);
                    s.aplicaCentCost_C_R = editApliCeCR.Checked;
                    s.subCuenta_C_R = Int32.Parse(editSubCuCR.Text);
                    s.subSubCuenta_C_R = Int32.Parse(editSubSCuCR.Text);
                    s.cuenta_D_R = Int32.Parse(editCuDR.Text);
                    s.aplicaCentCost_D_R = editApliCeDR.Checked;
                    s.subCuenta_D_R = Int32.Parse(editSubCuDR.Text);
                    s.subSubCuenta_D_R = Int32.Parse(editSubSCuDR.Text);
                    s.cantidad = decimal.Parse(editCantidad.Text);
                    s.importe = decimal.Parse(editImporte.Text);

                    Object item = g.editarGrupo(s, numGpoA);

                    System.Reflection.PropertyInfo m = item.GetType().GetProperty("message");
                    System.Reflection.PropertyInfo c = item.GetType().GetProperty("code");
                    String message = (String)(m.GetValue(item, null));
                    int code = (int)(c.GetValue(item, null));

                    if (code == 1)
                    {
                        ResetControls(tabPage3);
                        DisableControls(tabPage3);
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

        private void textEdit23_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            numGpoA = 0;
            ResetControls(tabPage3);
            tipo = 'E';
            int r = Tabla.GetSelectedRows()[0];
            //editGrupo.Text = Tabla.GetRowCellValue(r, "grupo").ToString();
            //editSubGrupo.Text = Tabla.GetRowCellValue(r, "subGrupo").ToString();

            //,,,,aplicaCentCost_F_R,subCuenta_F_R,subSubCuenta_F_R,
            //cuenta_A_R,aplicaCentCost_A_R,subCuenta_A_R,subSubCuenta_A_R,cuenta_C_R,aplicaCentCost_C_R,subCuenta_C_R,
            //subSubCuenta_C_R,cuenta_D_R,aplicaCentCost_D_R,subCuenta_D_R,subSubCuenta_D_R,cantidad,importe

            editNumeroG.Text = Tabla.GetRowCellValue(r, "numGpo").ToString();
            editDescripcion.Text = Tabla.GetRowCellValue(r, "descripcion").ToString();
            editCuFZ.Text = Tabla.GetRowCellValue(r, "cuenta_F_Z").ToString();
            if(Tabla.GetRowCellValue(r, "aplicaCentCost_F_Z").ToString().Equals("True"))
            {
                editApliCeFZ.Checked = true;
            }
            else
            {
                editApliCeFZ.Checked = false;
            }
            
            editSubCuFZ.Text = Tabla.GetRowCellValue(r, "subCuenta_F_Z").ToString();
            editSubSCuFZ.Text = Tabla.GetRowCellValue(r, "subSubCuenta_F_Z").ToString();
            editCuAZ.Text = Tabla.GetRowCellValue(r, "cuenta_A_Z").ToString();
            if (Tabla.GetRowCellValue(r, "aplicaCentCost_A_Z").ToString().ToString().Equals("True"))
            {
                editApliCeAZ.Checked = true;
            }
            else
            {
                editApliCeAZ.Checked = false;
            }
            editSubCuAZ.Text= Tabla.GetRowCellValue(r, "subCuenta_A_Z").ToString();
            editSubSCuAZ.Text = Tabla.GetRowCellValue(r, "subSubCuenta_A_Z").ToString();
            editCuCZ.Text = Tabla.GetRowCellValue(r, "cuenta_C_Z").ToString();
            if (Tabla.GetRowCellValue(r, "aplicaCentCost_C_Z").ToString().ToString().Equals("True"))
            {
                editApliCeCZ.Checked = true;
            }
            else
            {
                editApliCeCZ.Checked = false;
            }
            
            editSubCuCZ.Text = Tabla.GetRowCellValue(r, "subCuenta_C_Z").ToString();
            editSubCuCZ.Text = Tabla.GetRowCellValue(r, "subSubCuenta_C_Z").ToString();
            editCuDZ.Text = Tabla.GetRowCellValue(r, "cuenta_D_Z").ToString();
            if (Tabla.GetRowCellValue(r, "aplicaCentCost_D_Z").ToString().ToString().Equals("True"))
            {
                editApliCeDZ.Checked = true;
            }
            else
            {
                editApliCeDZ.Checked = false;
            }
            editSubCuDZ.Text = Tabla.GetRowCellValue(r, "subCuenta_D_Z").ToString();
            editSubSCuDZ.Text = Tabla.GetRowCellValue(r, "subSubCuenta_D_Z").ToString();
            editCuFR.Text = Tabla.GetRowCellValue(r, "cuenta_F_R").ToString();
            if (Tabla.GetRowCellValue(r, "aplicaCentCost_D_Z").ToString().ToString().Equals("True"))
            {
                editApliCeFR.Checked = true;
            }
            else
            {
                editApliCeFR.Checked = false;
            }
            editApliCeFR.Checked = Tabla.GetRowCellValue(r, "").ToString();
            editSubCuFR.Text = Tabla.GetRowCellValue(r, "").ToString();
            editSubSCuFR.Text = Tabla.GetRowCellValue(r, "").ToString();
            editCuAR.Text = Tabla.GetRowCellValue(r, "").ToString();
            editApliCeAR.Checked = Tabla.GetRowCellValue(r, "").ToString();
            editSubCuAR.Text = Tabla.GetRowCellValue(r, "").ToString();
            editSubSCuAR.Text = Tabla.GetRowCellValue(r, "").ToString();
            editCuCR.Text = Tabla.GetRowCellValue(r, "").ToString();
            editApliCeCR.Checked = Tabla.GetRowCellValue(r, "").ToString();
            editSubCuCR.Text = Tabla.GetRowCellValue(r, "").ToString();
            editSubSCuCR.Text = Tabla.GetRowCellValue(r, "").ToString();
            editCuDR.Text = Tabla.GetRowCellValue(r, "").ToString();
            editApliCeDR.Checked = Tabla.GetRowCellValue(r, "").ToString();
            editSubCuDR.Text = Tabla.GetRowCellValue(r, "").ToString();
            editSubSCuDR.Text = Tabla.GetRowCellValue(r, "").ToString();
            editCantidad.Text = Tabla.GetRowCellValue(r, "").ToString();
            editImporte.Text = Tabla.GetRowCellValue(r, "").ToString();
            numGpoA = Int32.Parse(Tabla.GetRowCellValue(r, "numGpo").ToString());

            this.tabControl1.SelectTab(1);
            EnableControls(tabPage3);
        }
    }
}