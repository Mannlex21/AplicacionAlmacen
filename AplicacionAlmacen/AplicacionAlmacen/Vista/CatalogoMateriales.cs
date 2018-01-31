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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;

namespace AplicacionAlmacen.Vista
{
    public partial class CatalogoMateriales : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static Controlador.MaterialesControlador s= new Controlador.MaterialesControlador();
        public static string imgNombre;
        public string textGrupo;
        public string textSubGrupo;
        static int totalRecords = 1;
        static private int pageSize = 30;
        string  carpetaImagen = Controlador.RutasGenerales.carpetaImagen;
        string carpetaAdjunto = Controlador.RutasGenerales.carpetaAdjunto;

        internal void setTextGrupo()
        {
            editGrupo.Text = textGrupo;
        }
        internal void setTextSubGrupo()
        {
            editSubGrupo.Text = textSubGrupo;
        }
        public static string directorio ="";
        
        static List<Materiales> records = new List<Materiales>();
        //E=editar,N=nuevo,s=sin seleccionar
        Char tipo = 's';
        int contT = 0;
        int materialA = 0;
        string idMaterialRef="";

        public CatalogoMateriales()
        {
            InitializeComponent();

            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            WindowState = FormWindowState.Maximized;
            bindingNavigator.BindingSource = bindingSource;
            bindingSource.CurrentChanged += new System.EventHandler(bindingSource1_CurrentChanged);
            bindingSource.DataSource = new PageOffsetList();
            editFechaU.DateTime = DateTime.Today;
            NetworkChange.NetworkAvailabilityChanged += AvailabilityChanged;

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
        private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            Red();
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
            Cursor.Current = Cursors.WaitCursor;
            tipo = 'N';
            this.tabControl1.SelectTab(1);
            EnableControls(tabPage2);
            ResetControls(tabPage2);
            editFechaU.DateTime = DateTime.Today;
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
                        if (textBox.Name == "editAdjunto")
                        {

                        }
                        else
                        {
                            contT++;
                        }
                    }
                }
            }
        }
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ResetControls(tabPage2);
            DisableControls(tabPage2);
            tipo = 's';
        }
        private void CatalogoMateriales_Load(object sender, EventArgs e)
        {
            DisableControls(tabPage2);
            Red();
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
                var e = int.TryParse(editBusquedaId.Text, out int n); 
                if (editBusquedaId.Text==""){
                    var x = s.GetMaterialesFiltros(editBusquedaId.Text.Equals("") ? -1 : Int32.Parse(editBusquedaId.Text), editBusquedaDesc.Text, editBusquedaMarca.Text);
                    bindingSource.DataSource = x.Count;
                    GridControl.DataSource = x;
                }
                else{
                    if (e)
                    {
                        var x = s.GetMaterialesFiltros(editBusquedaId.Text.Equals("") ? -1 : Int32.Parse(editBusquedaId.Text), editBusquedaDesc.Text, editBusquedaMarca.Text);
                        bindingSource.DataSource = x.Count;
                        GridControl.DataSource = x;
                    }
                    else
                    {
                        MessageBox.Show("Id debe ser un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
                
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
            Cursor.Current = Cursors.WaitCursor;
            if (tipo.Equals('N'))
            {
                CheckControls(tabPage2);
                if (contT == 0)
                {
                    if (Int32.Parse(editGrupo.Text)!=0 && Int32.Parse(editSubGrupo.Text) != 0)
                    {
                        vaciarCamposBusq();
                        Materiales m = new Materiales();
                        MaterialesContable mc = new MaterialesContable();
                        var idMaterial = s.getDig(editGrupo.Text, editSubGrupo.Text);
                        m.idMaterial = Int32.Parse(idMaterial);
                        m.materialReferencia = idMaterial;
                        m.descripcion = editDesc.Text;
                        m.uMedida = editUnidadM.Text;
                        m.marca = editMarca.Text;
                        m.existencia = decimal.Parse(editExistencia.Text);
                        m.localizacion = editLocali.Text;
                        m.minimo = decimal.Parse(editMinimo.Text);
                        m.maximo = decimal.Parse(editMaximo.Text);
                        m.costoProm = decimal.Parse(editCostoP.Text);
                        m.costoPromAnt = decimal.Parse(editCostoPA.Text);
                        m.cantIni = decimal.Parse(editCantidadI.Text);
                        m.importeIni = decimal.Parse(editImporteI.Text);
                        m.importe = decimal.Parse(editImporte.Text);
                        m.fechaUltimoMov = editFechaU.DateTime;
                        m.puntoPedido = decimal.Parse(editPuntoP.Text);
                        m.pedidoEstandar = decimal.Parse(editPedidoE.Text);
                        m.herramienta = editHerramienta.Checked;
                        m.seguridadInd = editSeguridad.Checked;
                        m.adjunto = carpetaAdjunto + "Material-" + idMaterial;
                        string url =editImagen.Text.ToLower();

                        String ext = (url.EndsWith(".png")) ? ".png" : ".jpg";
                        m.imagen = "Material-" +idMaterial+ext;


                        mc.idMaterial = Int32.Parse(idMaterial);
                        mc.cuenta_F_Z = Int32.Parse(cuenta_F_Z.Text);
                        mc.aplicaCentCost_F_Z = aplicaCentCost_F_Z.Checked;
                        mc.subCuenta_F_Z = Int32.Parse(subCuenta_F_Z.Text);
                        mc.subSubCuenta_F_Z = Int32.Parse(subSubCuenta_F_Z.Text);
                        mc.cuenta_A_Z = Int32.Parse(cuenta_A_Z.Text);
                        mc.aplicaCentCost_A_Z = aplicaCentCost_A_Z.Checked;
                        mc.subCuenta_A_Z = Int32.Parse(subCuenta_A_Z.Text);
                        mc.subSubCuenta_A_Z = Int32.Parse(subSubCuenta_A_Z.Text);
                        mc.cuenta_C_Z = Int32.Parse(cuenta_C_Z.Text);
                        mc.aplicaCentCost_C_Z = aplicaCentCost_C_Z.Checked;
                        mc.subCuenta_C_Z = Int32.Parse(subCuenta_C_Z.Text);
                        mc.subSubCuenta_C_Z = Int32.Parse(subSubCuenta_C_Z.Text);
                        mc.cuenta_D_Z = Int32.Parse(cuenta_D_Z.Text);
                        mc.aplicaCentCost_D_Z = aplicaCentCost_D_Z.Checked;
                        mc.subCuenta_D_Z = Int32.Parse(subCuenta_D_Z.Text);
                        mc.subSubCuenta_D_Z = Int32.Parse(subSubCuenta_D_Z.Text);
                        mc.cuenta_F_R = Int32.Parse(cuenta_F_R.Text);
                        mc.aplicaCentCost_F_R = aplicaCentCost_F_R.Checked;
                        mc.subCuenta_F_R = Int32.Parse(subCuenta_F_R.Text);
                        mc.subSubCuenta_F_R = Int32.Parse(subSubCuenta_F_R.Text);
                        mc.cuenta_A_R = Int32.Parse(cuenta_A_R.Text);
                        mc.aplicaCentCost_A_R = aplicaCentCost_A_R.Checked;
                        mc.subCuenta_A_R = Int32.Parse(subCuenta_A_R.Text);
                        mc.subSubCuenta_A_R = Int32.Parse(subSubCuenta_A_R.Text);
                        mc.cuenta_C_R = Int32.Parse(cuenta_C_R.Text);
                        mc.aplicaCentCost_C_R = aplicaCentCost_C_R.Checked;
                        mc.subCuenta_C_R = Int32.Parse(subCuenta_C_R.Text);
                        mc.subSubCuenta_C_R = Int32.Parse(subSubCuenta_C_R.Text);
                        mc.cuenta_D_R = Int32.Parse(cuenta_D_R.Text);
                        mc.aplicaCentCost_D_R = aplicaCentCost_D_R.Checked;
                        mc.subCuenta_D_R = Int32.Parse(subCuenta_D_R.Text);
                        mc.subSubCuenta_D_R = Int32.Parse(subSubCuenta_D_R.Text);

                        Object item = s.guardarMaterial(m, mc);

                        System.Reflection.PropertyInfo msg = item.GetType().GetProperty("message");
                        System.Reflection.PropertyInfo c = item.GetType().GetProperty("code");
                        String message = (String)(msg.GetValue(item, null));
                        int code = (int)(c.GetValue(item, null));

                        if (code == 1)
                        {
                            s.crearImagen(editImagen.Text, "Material", idMaterial);

                            string urlN=s.crearCarpetaAdjunto("Material-"+idMaterial);
                            s.crearImagenes(editAdjunto.Text, "Material", idMaterial,urlN);

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
                    else
                    {
                        MessageBox.Show("Grupo o SubGrupo no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Se deben de llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                contT = 0;

            }
            else if (tipo.Equals('E'))
            {
                CheckControls(tabPage2);
                if (contT == 0)
                {
                    if (Int32.Parse(editGrupo.Text) != 0 && Int32.Parse(editSubGrupo.Text) != 0)
                    {
                        vaciarCamposBusq();
                        Materiales m = new Materiales();
                        MaterialesContable mc = new MaterialesContable();
                        m.idMaterial = materialA;
                        m.materialReferencia = idMaterialRef;
                        m.descripcion = editDesc.Text;
                        m.uMedida = editUnidadM.Text;
                        m.marca = editMarca.Text;
                        m.existencia = decimal.Parse(editExistencia.Text);
                        m.localizacion = editLocali.Text;
                        m.minimo = decimal.Parse(editMinimo.Text);
                        m.maximo = decimal.Parse(editMaximo.Text);
                        m.costoProm = decimal.Parse(editCostoP.Text);
                        m.costoPromAnt = decimal.Parse(editCostoPA.Text);
                        m.cantIni = decimal.Parse(editCantidadI.Text);
                        m.importeIni = decimal.Parse(editImporteI.Text);
                        m.importe = decimal.Parse(editImporte.Text);
                        m.fechaUltimoMov = editFechaU.DateTime;
                        m.puntoPedido = decimal.Parse(editPuntoP.Text);
                        m.pedidoEstandar = decimal.Parse(editPedidoE.Text);
                        m.herramienta = editHerramienta.Checked;
                        m.seguridadInd = editSeguridad.Checked;
                        m.adjunto = carpetaAdjunto + "Material-" + idMaterialRef;
                        string url = editImagen.Text.ToLower();

                        String ext = (url.EndsWith(".png")) ? ".png" : ".jpg";
                        m.imagen = "Material-" + idMaterialRef+ext;

                        mc.idMaterial = materialA;
                        mc.cuenta_F_Z = Int32.Parse(cuenta_F_Z.Text);
                        mc.aplicaCentCost_F_Z = aplicaCentCost_F_Z.Checked;
                        mc.subCuenta_F_Z = Int32.Parse(subCuenta_F_Z.Text);
                        mc.subSubCuenta_F_Z = Int32.Parse(subSubCuenta_F_Z.Text);
                        mc.cuenta_A_Z = Int32.Parse(cuenta_A_Z.Text);
                        mc.aplicaCentCost_A_Z = aplicaCentCost_A_Z.Checked;
                        mc.subCuenta_A_Z = Int32.Parse(subCuenta_A_Z.Text);
                        mc.subSubCuenta_A_Z = Int32.Parse(subSubCuenta_A_Z.Text);
                        mc.cuenta_C_Z = Int32.Parse(cuenta_C_Z.Text);
                        mc.aplicaCentCost_C_Z = aplicaCentCost_C_Z.Checked;
                        mc.subCuenta_C_Z = Int32.Parse(subCuenta_C_Z.Text);
                        mc.subSubCuenta_C_Z = Int32.Parse(subSubCuenta_C_Z.Text);
                        mc.cuenta_D_Z = Int32.Parse(cuenta_D_Z.Text);
                        mc.aplicaCentCost_D_Z = aplicaCentCost_D_Z.Checked;
                        mc.subCuenta_D_Z = Int32.Parse(subCuenta_D_Z.Text);
                        mc.subSubCuenta_D_Z = Int32.Parse(subSubCuenta_D_Z.Text);
                        mc.cuenta_F_R = Int32.Parse(cuenta_F_R.Text);
                        mc.aplicaCentCost_F_R = aplicaCentCost_F_R.Checked;
                        mc.subCuenta_F_R = Int32.Parse(subCuenta_F_R.Text);
                        mc.subSubCuenta_F_R = Int32.Parse(subSubCuenta_F_R.Text);
                        mc.cuenta_A_R = Int32.Parse(cuenta_A_R.Text);
                        mc.aplicaCentCost_A_R = aplicaCentCost_A_R.Checked;
                        mc.subCuenta_A_R = Int32.Parse(subCuenta_A_R.Text);
                        mc.subSubCuenta_A_R = Int32.Parse(subSubCuenta_A_R.Text);
                        mc.cuenta_C_R = Int32.Parse(cuenta_C_R.Text);
                        mc.aplicaCentCost_C_R = aplicaCentCost_C_R.Checked;
                        mc.subCuenta_C_R = Int32.Parse(subCuenta_C_R.Text);
                        mc.subSubCuenta_C_R = Int32.Parse(subSubCuenta_C_R.Text);
                        mc.cuenta_D_R = Int32.Parse(cuenta_D_R.Text);
                        mc.aplicaCentCost_D_R = aplicaCentCost_D_R.Checked;
                        mc.subCuenta_D_R = Int32.Parse(subCuenta_D_R.Text);
                        mc.subSubCuenta_D_R = Int32.Parse(subSubCuenta_D_R.Text);

                        Object item = s.editarMaterial(m, mc);

                        System.Reflection.PropertyInfo msg = item.GetType().GetProperty("message");
                        System.Reflection.PropertyInfo c = item.GetType().GetProperty("code");
                        String message = (String)(msg.GetValue(item, null));
                        int code = (int)(c.GetValue(item, null));

                        if (code == 1)
                        {
                            s.crearImagen(editImagen.Text, "Material", idMaterialRef);
                            string urlN = s.crearCarpetaAdjunto("Material-" + idMaterialRef);
                            s.crearImagenes(editAdjunto.Text, "Material", idMaterialRef, urlN);

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
                    else
                    {
                        MessageBox.Show("Grupo o SubGrupo no puede ser 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MessageBox.Show("Se deben de llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                contT = 0;
            }
            else if (tipo.Equals('s'))
            {

            }
        }
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            materialA = 0;
            idMaterialRef = "";
            ResetControls(tabPage2);
            tipo = 'E';
            int r = Tabla.GetSelectedRows()[0];

            idMaterialRef= Tabla.GetRowCellValue(r, "materialReferencia").ToString();
            string grupo = idMaterialRef[0].ToString() +idMaterialRef[1].ToString();
            string subGrupo = idMaterialRef[2].ToString()+idMaterialRef[3].ToString();

            editGrupo.Text = grupo;
            editSubGrupo.Text = subGrupo;
            materialA = Int32.Parse(Tabla.GetRowCellValue(r, "idMaterial").ToString());
            editDesc.Text = Tabla.GetRowCellValue(r, "descripcion").ToString();
            editUnidadM.Text = Tabla.GetRowCellValue(r, "uMedida").ToString();
            editMarca.Text = Tabla.GetRowCellValue(r, "marca").ToString();
            editExistencia.Text = Tabla.GetRowCellValue(r, "existencia").ToString();
            editLocali.Text = Tabla.GetRowCellValue(r, "localizacion").ToString();
            editMinimo.Text = Tabla.GetRowCellValue(r, "minimo").ToString();
            editMaximo.Text = Tabla.GetRowCellValue(r, "maximo").ToString();
            editCostoP.Text = Tabla.GetRowCellValue(r, "costoProm").ToString();
            editCostoPA.Text = Tabla.GetRowCellValue(r, "costoPromAnt").ToString();
            editCantidadI.Text = Tabla.GetRowCellValue(r, "cantIni").ToString();
            editImporte.Text = Tabla.GetRowCellValue(r, "importe").ToString();
            editImporteI.Text = Tabla.GetRowCellValue(r, "importeIni").ToString();
            editPedidoE.Text= Tabla.GetRowCellValue(r, "pedidoEstandar").ToString();
            editPuntoP.Text= Tabla.GetRowCellValue(r, "puntoPedido").ToString();
            editFechaU.Text= Tabla.GetRowCellValue(r, "fechaUltimoMov").ToString();
            editHerramienta.Checked = (Tabla.GetRowCellValue(r, "herramienta").ToString().Equals("True")) ? true : false;
            editSeguridad.Checked = (Tabla.GetRowCellValue(r, "seguridadInd").ToString().Equals("True")) ? true : false;
            editImagen.Text = carpetaImagen+ Tabla.GetRowCellValue(r, "imagen").ToString();

            var objM=s.GetMaterialContable(materialA);
            cuenta_A_Z.Text= objM.cuenta_A_Z.ToString();
            cuenta_C_Z.Text = objM.cuenta_C_Z.ToString();
            cuenta_D_Z.Text = objM.cuenta_D_Z.ToString();
            cuenta_F_Z.Text = objM.cuenta_F_Z.ToString();
            subCuenta_A_Z.Text = objM.subCuenta_A_Z.ToString();
            subCuenta_C_Z.Text = objM.subCuenta_C_Z.ToString();
            subCuenta_D_Z.Text = objM.subCuenta_D_Z.ToString();
            subCuenta_F_Z.Text = objM.subCuenta_F_Z.ToString();
            subSubCuenta_A_Z.Text = objM.subSubCuenta_A_Z.ToString();
            subSubCuenta_C_Z.Text = objM.subSubCuenta_C_Z.ToString();
            subSubCuenta_D_Z.Text = objM.subSubCuenta_D_Z.ToString();
            subSubCuenta_F_Z.Text = objM.subSubCuenta_F_Z.ToString();
            aplicaCentCost_A_Z.Checked = (objM.aplicaCentCost_A_Z == true) ?  true :  false;
            aplicaCentCost_C_Z.Checked = (objM.aplicaCentCost_C_Z == true) ? true : false;
            aplicaCentCost_D_Z.Checked = (objM.aplicaCentCost_D_Z == true) ? true : false;
            aplicaCentCost_F_Z.Checked = (objM.aplicaCentCost_F_Z == true) ? true : false;

            cuenta_A_R.Text = objM.cuenta_A_R.ToString();
            cuenta_C_R.Text = objM.cuenta_C_R.ToString();
            cuenta_D_R.Text = objM.cuenta_D_R.ToString();
            cuenta_F_R.Text = objM.cuenta_F_R.ToString();
            subCuenta_A_R.Text = objM.subCuenta_A_R.ToString();
            subCuenta_C_R.Text = objM.subCuenta_C_R.ToString();
            subCuenta_D_R.Text = objM.subCuenta_D_R.ToString();
            subCuenta_F_R.Text = objM.subCuenta_F_R.ToString();
            subSubCuenta_A_R.Text = objM.subSubCuenta_A_R.ToString();
            subSubCuenta_C_R.Text = objM.subSubCuenta_C_R.ToString();
            subSubCuenta_D_R.Text = objM.subSubCuenta_D_R.ToString();
            subSubCuenta_F_R.Text = objM.subSubCuenta_F_R.ToString();
            aplicaCentCost_A_R.Checked = (objM.aplicaCentCost_A_R == true) ? true : false;
            aplicaCentCost_C_R.Checked = (objM.aplicaCentCost_C_R == true) ? true : false;
            aplicaCentCost_D_R.Checked = (objM.aplicaCentCost_D_R == true) ? true : false;
            aplicaCentCost_F_R.Checked = (objM.aplicaCentCost_F_R == true) ? true : false;
            this.tabControl1.SelectTab(1);
            EnableControls(tabPage2);
            editGrupo.Enabled = false;
            editSubGrupo.Enabled = false;
        }
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            Cursor.Current = Cursors.WaitCursor;
            int r = Tabla.GetSelectedRows()[0];
            int idMaterial= Int32.Parse(Tabla.GetRowCellValue(r, "idMaterial").ToString());

            Object item = s.borrarMaterial(idMaterial);

            System.Reflection.PropertyInfo m = item.GetType().GetProperty("message");
            System.Reflection.PropertyInfo c = item.GetType().GetProperty("code");
            String message = (String)(m.GetValue(item, null));
            int code = (int)(c.GetValue(item, null));

            if (code == 1)
            {
                vaciarCamposBusq();
                s.eliminarImagen(Tabla.GetRowCellValue(r, "imagen").ToString());
                string d = (Tabla.GetRowCellValue(r, "adjunto") == null) ? "" : Tabla.GetRowCellValue(r, "adjunto").ToString();
                s.eliminarAdjuntos(d);
                Recargar();
                MessageBox.Show(message, "OK", MessageBoxButtons.OK, MessageBoxIcon.None);

            }
            else if (code == 2)
            {
                MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void editImagen_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenFileDialog abrirArchivo = new OpenFileDialog();
            abrirArchivo.Filter = "Archivos de imagen (*.JPG, *.PNG)|*.jpg;*.png";

            if (abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                editImagen.Text = abrirArchivo.FileName;
            } 
        }
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int r = Tabla.GetSelectedRows()[0];
            imgNombre=(Tabla.GetRowCellValue(r, "imagen")==null)?"unknown.png": Tabla.GetRowCellValue(r, "imagen").ToString();
            new DetalleMaterial().Show();

        }
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int r = Tabla.GetSelectedRows()[0];
            string dir = carpetaAdjunto + "Material-" + Tabla.GetRowCellValue(r, "materialReferencia").ToString();
            directorio = (dir==null || dir=="")?"":dir;
            
            try
            {
                new DetalleMaterialAdj().Show();
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
            
        }
        private void textEdit1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            OpenFileDialog abrirArchivo = new OpenFileDialog();
            abrirArchivo.Multiselect=true;
            abrirArchivo.Filter = "Archivos de imagen (*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|"
                                + "Todos los archivos (*.*)|*.*";
            if (abrirArchivo.ShowDialog() == DialogResult.OK)
            {
                string fileN = "";
                for (int i=0;i<abrirArchivo.FileNames.Length;i++)
                {
                    fileN+=abrirArchivo.FileNames[i]+",";
                }
                editAdjunto.Text =fileN;
            }
        }
        public void Red()
        {
            if (Controlador.Clases.ConexionServidor.verificarConexion())
            {
                tabControl1.Enabled = true;
                ribbonControl1.Enabled = true;
                textConexion.Caption= "Conectado";
                textConexion.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                tabControl1.Enabled = false;
                ribbonControl1.Enabled = false;
                textConexion.Caption = "No hay conexión";
                textConexion.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Red;
            }
        }
        public void vaciarCamposBusq()
        {
            editBusquedaDesc.Text = "";
            editBusquedaId.Text = "";
            editBusquedaMarca.Text = "";
        }
        private void editGrupo_Click(object sender, EventArgs e)
        {
            getGrupo();
        }
        private void sonidoEnter_Press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
            }
        }
        private void editSubGrupo_Click(object sender, EventArgs e)
        {
            getSubGrupo();
        }
        private void getGrupo()
        {
            new DetalleMaterialGrupo(this).Show();
        }

        private void getSubGrupo()
        {
            new DetalleMaterialSubGrupo(this).Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            buscarFiltro();
        }
    }
}