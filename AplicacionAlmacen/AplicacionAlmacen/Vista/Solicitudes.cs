﻿using System;
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
using DevExpress.LookAndFeel;
using DevExpress.XtraGrid.Views.Grid;
using System.Net.NetworkInformation;

namespace AplicacionAlmacen.Vista
{
    public partial class Solicitudes : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string carpetaAdjunto = Controlador.RutasGenerales.carpetaAdjuntoSoli;
        public static string directorio = "";
        public static int preReq;
        public static int dep;
        public static int ejer;
        static Controlador.SolicitudesControlador s = new Controlador.SolicitudesControlador();
        static Controlador.DepartamentosControlador d = new Controlador.DepartamentosControlador();
        static List<Solicitud_Requisiciones> records = new List<Solicitud_Requisiciones>();
        public Solicitudes()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            WindowState = FormWindowState.Maximized;
            try
            {
                GridControl.DataSource = s.GetSolicitudesAll(depaCombo.Text);
                NetworkChange.NetworkAvailabilityChanged += AvailabilityChanged;
                foreach (var t in d.GetDepartamentos())
                {
                    depaCombo.Items.Add(t.descripcion);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Recargar()
        {
            try
            {
                GridControl.DataSource = s.GetSolicitudesAll(depaCombo.Text);
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
        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            new CatalogoMateriales().Show();
        }
        private void barButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            new CatalogoGrupos().Show();
        }
        private void depaCombo_Click(object sender, EventArgs e){
            GridControl.DataSource = s.GetSolicitudesAll(depaCombo.Text);
        }
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e){
            try { 
                Cursor.Current = Cursors.WaitCursor;
                Recargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void barButtonItem13_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (Tabla.GetSelectedRows().Length == 0)
                {
                    MessageBox.Show("Se debe seleccionar al menos una solicitud", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    int contS = 0;
                    foreach (int i in Tabla.GetSelectedRows())
                    {
                        contS++;
                        int r = i;
                        preReq = Int32.Parse(Tabla.GetRowCellValue(r, "preRequisicion").ToString());
                        dep = Int32.Parse(Tabla.GetRowCellValue(r, "departamento").ToString());
                        ejer = Int32.Parse(Tabla.GetRowCellValue(r, "ejercicio").ToString());
                        new DetalleMaterialImg().Show();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (Tabla.GetSelectedRows().Length == 0)
                {
                    MessageBox.Show("Se debe seleccionar al menos una solicitud", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int contE = 0;
                    const string msg = "La requisición debe contener materiales existentes.";
                    const string caption = "Asignación";
                    var res = MessageBox.Show(msg, caption,
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Information);
                    if (res == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        int contS = 0;
                        foreach (int i in Tabla.GetSelectedRows())
                        {
                            contS++;
                            int r = i;
                            string ciclo = Tabla.GetRowCellValue(r, "ciclo").ToString();
                            string departamento = Tabla.GetRowCellValue(r, "departamento").ToString();
                            int ejercicio = Int32.Parse(Tabla.GetRowCellValue(r, "ejercicio").ToString());
                            int preRequisicion = Int32.Parse(Tabla.GetRowCellValue(r, "preRequisicion").ToString());

                            Object item = s.claveSolicitud(ciclo, departamento, ejercicio);

                            System.Reflection.PropertyInfo m = item.GetType().GetProperty("message");
                            System.Reflection.PropertyInfo c = item.GetType().GetProperty("code");
                            System.Reflection.PropertyInfo re = item.GetType().GetProperty("result");
                            String message = (String)(m.GetValue(item, null));
                            String result = (String)(re.GetValue(item, null));
                            int code = (int)(c.GetValue(item, null));

                            if (code == 1)
                            {
                                string clave = result;
                                Object item2 = s.asignarClave(clave, preRequisicion, ejercicio, Int32.Parse(departamento));
                                System.Reflection.PropertyInfo m2 = item2.GetType().GetProperty("message");
                                System.Reflection.PropertyInfo c2 = item2.GetType().GetProperty("code");
                                String message2 = (String)(m2.GetValue(item2, null));
                                int code2 = (int)(c2.GetValue(item2, null));
                                if (code2 != 1)
                                {
                                    contE++;
                                }
                            }
                            else
                            {
                                contE++;
                            }
                        }
                        if (contE == 0)
                        {
                            Recargar();
                            MessageBox.Show("Se asigno la clave a los elementos seleccionados", "OK", MessageBoxButtons.OK, MessageBoxIcon.None);
                        }
                        else
                        {
                            Recargar();
                            MessageBox.Show("No se asigno la clave a uno o mas elementos\n", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try { 
                depaCombo.SelectedItem = null;
                Recargar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Red()
        {
            Controlador.Clases.ConexionServidor conexion = new Controlador.Clases.ConexionServidor();
            if (conexion.verificarConexion())
            {
                tabControl1.Enabled = true;
                ribbon.Enabled = true;
                textConexion.Caption = conexion.msgConectado;
                textConexion.ItemAppearance.Normal.ForeColor = conexion.colorConectado;
            }
            else
            {
                tabControl1.Enabled = false;
                ribbon.Enabled = false;
                textConexion.Caption = conexion.msgDesconectado;
                textConexion.ItemAppearance.Normal.ForeColor = conexion.colorDesconectado;
            }
        }
        private void Solicitudes_Load(object sender, EventArgs e)
        {
            Red();
        }
        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                if (Tabla.GetSelectedRows().Length == 0)
                {
                    MessageBox.Show("Se debe seleccionar al menos una solicitud", "OK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Cursor.Current = Cursors.WaitCursor;
                    foreach (int i in Tabla.GetSelectedRows())
                    {
                        int r = i;
                        preReq = Int32.Parse(Tabla.GetRowCellValue(r, "preRequisicion").ToString());
                        dep = Int32.Parse(Tabla.GetRowCellValue(r, "departamento").ToString());
                        ejer = Int32.Parse(Tabla.GetRowCellValue(r, "ejercicio").ToString());
                        string dir = carpetaAdjunto + Tabla.GetRowCellValue(r, "anexo").ToString();
                        directorio = (dir == null || dir == "") ? "" : dir;
                        new DetalleSolicitudAdj().Show();
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("The process failed: {0}", ex.ToString());
            }
        }
    }
}



