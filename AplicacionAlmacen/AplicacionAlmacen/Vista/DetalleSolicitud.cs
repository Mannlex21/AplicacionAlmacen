﻿using System;
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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using System.Net.NetworkInformation;

namespace AplicacionAlmacen.Vista
{
    public partial class DetalleMaterialImg : DevExpress.XtraEditors.XtraForm
    {
        static Controlador.SolicitudesControlador s = new Controlador.SolicitudesControlador();
        public DetalleMaterialImg()
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            try
            {
                Solicitudes s2 = new Solicitudes();
                this.Text = "Detalle (PreRequisición: " + Solicitudes.preReq + " - Departamento: " + Solicitudes.dep + " - Ejercicio: " + Solicitudes.ejer + ")";
                GridControl.DataSource = s.GetSolicitudDet(Solicitudes.preReq, Solicitudes.dep, Solicitudes.ejer);
                NetworkChange.NetworkAvailabilityChanged += AvailabilityChanged;
                Tabla.RowCellStyle += (sender, e) =>
                {
                    GridView view = sender as GridView;
                    if (e.Column.FieldName == "cantidad")
                    {
                        double exis = Double.Parse(view.GetRowCellValue(e.RowHandle, "existencia").ToString());
                        double cant = Double.Parse(view.GetRowCellValue(e.RowHandle, "cantidad").ToString());
                        if (cant <= exis)
                        {
                            e.Appearance.BackColor = Color.Yellow;
                            e.Appearance.ForeColor = Color.Black;
                        }
                    }
                    if (e.Column.FieldName == "material")
                    {
                        int idMat = Int32.Parse(view.GetRowCellValue(e.RowHandle, "material").ToString());

                        if (!s.existeMaterial(idMat))
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.ForeColor = Color.White;
                        }
                        else
                        {
                            e.Appearance.BackColor = Color.LightGreen;
                            e.Appearance.ForeColor = Color.Black;
                        }

                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DetalleSolicitud_Load(object sender, EventArgs e)
        {
            Red();
        }
        private void AvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            Red();
        }
        public void Red()
        {
            Controlador.Clases.ConexionServidor conexion = new Controlador.Clases.ConexionServidor();
            if (conexion.verificarConexion())
            {
                GridControl.Enabled = true;
            }
            else
            {
                GridControl.Enabled = false;
            }
        }
    }
}