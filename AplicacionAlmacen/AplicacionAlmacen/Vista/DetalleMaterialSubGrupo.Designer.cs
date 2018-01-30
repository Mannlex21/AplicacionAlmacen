﻿namespace AplicacionAlmacen.Vista
{
    partial class DetalleMaterialSubGrupo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleMaterialSubGrupo));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.GridControl = new DevExpress.XtraGrid.GridControl();
            this.Tabla = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grupo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.subGrupo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.GridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(720, 430);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // GridControl
            // 
            this.GridControl.Location = new System.Drawing.Point(2, 2);
            this.GridControl.MainView = this.Tabla;
            this.GridControl.Name = "GridControl";
            this.GridControl.Size = new System.Drawing.Size(716, 426);
            this.GridControl.TabIndex = 4;
            this.GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Tabla});
            this.GridControl.DoubleClick += new System.EventHandler(this.GridControl_DoubleClick);
            // 
            // Tabla
            // 
            this.Tabla.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.grupo,
            this.subGrupo,
            this.descripcion});
            this.Tabla.GridControl = this.GridControl;
            this.Tabla.Name = "Tabla";
            this.Tabla.OptionsBehavior.Editable = false;
            this.Tabla.OptionsBehavior.ReadOnly = true;
            this.Tabla.OptionsView.ColumnAutoWidth = false;
            this.Tabla.OptionsView.ShowGroupPanel = false;
            // 
            // grupo
            // 
            this.grupo.Caption = "Grupo";
            this.grupo.FieldName = "grupo";
            this.grupo.Name = "grupo";
            this.grupo.Visible = true;
            this.grupo.VisibleIndex = 0;
            this.grupo.Width = 48;
            // 
            // subGrupo
            // 
            this.subGrupo.Caption = "Sub Grupo";
            this.subGrupo.FieldName = "subGrupo";
            this.subGrupo.Name = "subGrupo";
            this.subGrupo.Visible = true;
            this.subGrupo.VisibleIndex = 1;
            this.subGrupo.Width = 71;
            // 
            // descripcion
            // 
            this.descripcion.Caption = "Descripcion";
            this.descripcion.FieldName = "descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.Visible = true;
            this.descripcion.VisibleIndex = 2;
            this.descripcion.Width = 573;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.Size = new System.Drawing.Size(720, 430);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.GridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(720, 430);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // DetalleMaterialSubGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 430);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetalleMaterialSubGrupo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DetalleMaterialSubGrupo";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Tabla;
        private DevExpress.XtraGrid.Columns.GridColumn grupo;
        private DevExpress.XtraGrid.Columns.GridColumn subGrupo;
        private DevExpress.XtraGrid.Columns.GridColumn descripcion;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}