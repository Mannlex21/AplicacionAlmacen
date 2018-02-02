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
using System.Net.NetworkInformation;

namespace AplicacionAlmacen.Vista
{
    public partial class CatalogoSubGrupos : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static Controlador.SubGruposControlador sg = new Controlador.SubGruposControlador();
        public string textGrupo;
        static int totalRecords = 1;
        static private int pageSize = 30;
        static List<SubGrupos> records = new List<SubGrupos>();
        int contT=0;
        //E=editar,N=nuevo,s=sin seleccionar
        Char tipo = 's';
        int grupoA=0, subGrupoA=0;
        public CatalogoSubGrupos(){
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            WindowState = FormWindowState.Maximized;
            try
            {
                bindingNavigator.BindingSource = bindingSource;
                bindingSource.CurrentChanged += new System.EventHandler(bindingSource_CurrentChanged);
                bindingSource.DataSource = new PageOffsetList();
                NetworkChange.NetworkAvailabilityChanged += AvailabilityChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        internal void setTextGrupo()
        {
            editGrupo.Text = textGrupo;
        }
        private void bindingSource_CurrentChanged(object sender, EventArgs e){
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        class PageOffsetList : System.ComponentModel.IListSource{
            public bool ContainsListCollection { get; protected set; }

            public System.Collections.IList GetList()
            {
                totalRecords = sg.numeroSubG();
                var pageOffsets = new List<int>();
                for (int offset = 0; offset < totalRecords; offset += pageSize)
                    pageOffsets.Add(offset);
                Console.WriteLine(pageOffsets.Count);
                return pageOffsets;
            }
        }
        private void Recargar(){
            try
            {
                bindingNavigator.BindingSource = bindingSource;
                bindingSource.CurrentChanged += new EventHandler(bindingSource_CurrentChanged);
                bindingSource.DataSource = new PageOffsetList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            Red();
        }
        private void btnActualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            try { 
                Cursor.Current = Cursors.WaitCursor;
                Recargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            try { 
                Cursor.Current = Cursors.WaitCursor;
                tipo = 'N';
                this.tabControl1.SelectTab(1);
                ResetControls(tabPage2);
                EnableControls(tabPage2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancelar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            try { 
                Cursor.Current = Cursors.WaitCursor;
                this.tabControl1.SelectTab(0);
                ResetControls(tabPage2);
                DisableControls(tabPage2);
                tipo = 's';
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnGuardar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            try { 
                Cursor.Current = Cursors.WaitCursor;
                if (tipo.Equals('N'))
                {
                    CheckControls(tabPage2);
                    if (contT == 0)
                    {
                        vaciarCamposBusq();
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
                            this.tabControl1.SelectTab(0);
                            MessageBox.Show(message, "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else if (code == 2)
                        {
                            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Se deben de llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    contT = 0;

                }
                else if(tipo.Equals('E')){
                    CheckControls(tabPage2);
                    if (contT == 0)
                    {
                        vaciarCamposBusq();
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
                            this.tabControl1.SelectTab(0);
                            MessageBox.Show(message, "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else if (code == 2)
                        {
                            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBorrar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                int r = TablaSub.GetSelectedRows()[0];
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
                    vaciarCamposBusq();
                    Recargar();
                    MessageBox.Show(message, "OK", MessageBoxButtons.OK, MessageBoxIcon.None);

                }
                else if (code == 2)
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e){
            try { 
                Cursor.Current = Cursors.WaitCursor;
                grupoA = 0;
                subGrupoA = 0;
                ResetControls(tabPage2);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CatalogoSubGrupos_Load(object sender, EventArgs e){
            DisableControls(tabPage2);
            Red();
        }
        private void DisableControls(Control con){
            foreach (Control c in con.Controls)
            {
                DisableControls(c);
            }
            con.Enabled = false;
        }
        private void EnableControls(Control con){
            if (con != null)
            {
                foreach (Control c in con.Controls)
                {
                    EnableControls(c);
                }
                con.Enabled = true;
            }
        }
        private void ResetControls(Control con){
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
        private void CheckControls(Control con){
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
        
        private void editBusquedaGpo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscarFiltro();
            }
        }
        private void editBusquedaSub_KeyUp(object sender, KeyEventArgs e)
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
        private void sonidoEnter_Press(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                e.Handled = true;
            }
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                editBusquedaDesc.Text = "";
                editBusquedaGpo.Text = "";
                editBusquedaSub.Text = "";
                Recargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buscarFiltro(){
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (editBusquedaDesc.Text != "" || editBusquedaGpo.Text != "" || editBusquedaSub.Text != "")
                {
                    //var e = int.TryParse(editBusquedaGpo.Text, out int n);
                    //var e2 = int.TryParse(editBusquedaSub.Text, out int y);
                    if (editBusquedaGpo.Text == "" && editBusquedaSub.Text == "")
                    {
                        var x = sg.GetSubGruposFiltros(editBusquedaGpo.Text.Equals("") ? -1 : Int32.Parse(editBusquedaGpo.Text), editBusquedaSub.Text.Equals("") ? -1 : Int32.Parse(editBusquedaSub.Text), editBusquedaDesc.Text);
                        bindingSource.DataSource = x.Count;
                        GridControlSub.DataSource = x;
                    }
                    else
                    {
                        var e = editBusquedaGpo.Text.Equals("") ? -1 : int.TryParse(editBusquedaGpo.Text, out int n) ? Int32.Parse(editBusquedaGpo.Text) : -2;
                        var e2 = editBusquedaSub.Text.Equals("") ? -1 : int.TryParse(editBusquedaSub.Text, out int y) ? Int32.Parse(editBusquedaSub.Text) : -2;
                        if (e2 == -2 || e == -2)
                        {
                            MessageBox.Show("Grupo y SubGrupo deben ser un numero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            var x = sg.GetSubGruposFiltros(editBusquedaGpo.Text.Equals("") ? -1 : Int32.Parse(editBusquedaGpo.Text), editBusquedaSub.Text.Equals("") ? -1 : Int32.Parse(editBusquedaSub.Text), editBusquedaDesc.Text);
                            bindingSource.DataSource = x.Count;
                            GridControlSub.DataSource = x;
                        }

                    }


                }
                else
                {
                    Recargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void vaciarCamposBusq()
        {
            editBusquedaDesc.Text = "";
            editBusquedaGpo.Text = "";
            editBusquedaSub.Text = "";
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            buscarFiltro();
        }
        private void editBusquedaGpo_Click(object sender, EventArgs e)
        {

        }

        private void editGrupo_Click(object sender, EventArgs e)
        {
            getGrupo();
        }
        private void getGrupo()
        {
            new DetalleSubGrupoGpo(this).Show();
        }
        public void Red()
        {
            Controlador.Clases.ConexionServidor conexion = new Controlador.Clases.ConexionServidor();
            if (conexion.verificarConexion())
            {
                ribbonControl1.Enabled = true;
                tabControl1.Enabled = true;
                textConexion.Caption = conexion.msgConectado;
                textConexion.ItemAppearance.Normal.ForeColor = conexion.colorConectado;
            }
            else
            {
                ribbonControl1.Enabled = false;
                tabControl1.Enabled = false;
                textConexion.Caption = conexion.msgConectado;
                textConexion.ItemAppearance.Normal.ForeColor = conexion.colorDesconectado;
            }
        }
    }
}
