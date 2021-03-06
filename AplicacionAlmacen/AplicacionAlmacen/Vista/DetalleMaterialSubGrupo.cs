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

namespace AplicacionAlmacen.Vista
{
    public partial class DetalleMaterialSubGrupo : DevExpress.XtraEditors.XtraForm
    {
        static Controlador.SubGruposControlador sg = new Controlador.SubGruposControlador();
        CatalogoMateriales formLocal;
        public DetalleMaterialSubGrupo(CatalogoMateriales formExterno)
        {
            InitializeComponent();
            UserLookAndFeel.Default.SetSkinStyle("The Bezier");
            try
            {
                formLocal = formExterno;
                GridControl.DataSource = sg.GetAllSubGrupos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void GridControl_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int r = Tabla.GetSelectedRows()[0];
                string grupo = Tabla.GetRowCellValue(r, "grupo").ToString();
                string subGrupo = Tabla.GetRowCellValue(r, "subGrupo").ToString();
                formLocal.textSubGrupo = subGrupo;
                formLocal.textGrupo = grupo;
                formLocal.setTextSubGrupo();
                formLocal.setTextGrupo();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}