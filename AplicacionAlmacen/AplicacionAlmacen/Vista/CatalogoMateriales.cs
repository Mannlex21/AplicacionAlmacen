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
        //E=editar,N=nuevo,s=sin seleccionar
        Char tipo = 's';
        int contT = 0;
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
                GridControl.DataSource = s.GetMateriales( ((int)bindingSource.Current / pageSize), pageSize);
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
                var x = s.GetMaterialesFiltros(editBusquedaId.Text.Equals("")? -1: Int32.Parse(editBusquedaId.Text), editBusquedaDesc.Text, editBusquedaMarca.Text);
                bindingSource.DataSource = x.Count;
                GridControl.DataSource = x;
            }
            else
            {
                Recargar();
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

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Controlador.MaterialesControlador s = new Controlador.MaterialesControlador();
            s.getDig(editGrupo.Text, editSubGrupo.Text);
            //Console.WriteLine(s.getDig(dig));
            if (tipo.Equals('N'))
            {
                CheckControls(tabPage2);
                if (contT == 0)
                {
                    Materiales m = new Materiales();
                    MaterialesContable mc = new MaterialesContable();
                    m.idMaterial = s.getDig(layoutControlItem54.Text,edit.Text);
                    m.descripcion = editDesc.Text;
                    m.uMedida = editUnidadM.Text;
                    m.marca = editMarca.Text; //decimal.Parse(editCantidad.Text);
                    m.existencia = decimal.Parse(editExistencia.Text);
                    m.localizacion = editLocali.Text;
                    m.minimo = decimal.Parse(editMinimo.Text);
                    m.maximo = decimal.Parse(editMaximo.Text);
                    m.costoProm = decimal.Parse(editCostoP.Text);
                    m.costoPromAnt = decimal.Parse(editCostoPA.Text);
                    m.cantIni = decimal.Parse(editCantidadI.Text);
                    m.importeIni = decimal.Parse(editImporteI.Text);
                    m.fechaUltimoMov = editFechaU.DateTime;
                    m.puntoPedido = decimal.Parse(editPuntoP.Text);
                    m.pedidoEstandar = decimal.Parse(editPedidoE.Text);
                    m.herramienta = editHerramienta.Checked;
                    m.seguridadInd = editSeguridad.Checked;

                    /*
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
                    */
                    //Object item = s.guardarMaterial(m);

                    /*System.Reflection.PropertyInfo m = item.GetType().GetProperty("message");
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
                    }*/
                }
                contT = 0;

            }
            else if (tipo.Equals('E'))
            {
                CheckControls(tabPage2);
                if (contT == 0)
                {
                    Materiales M = new Materiales();
                    /*s.numGpo = Int16.Parse(editNumeroG.Text);
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
                    }*/
                }
                contT = 0;
            }
            else if (tipo.Equals('s'))
            {

            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}