using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using System.Drawing;

namespace AplicacionAlmacen.Vista
{
    partial class DetalleMaterialImg
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetalleMaterialImg));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.GridControl = new DevExpress.XtraGrid.GridControl();
            this.Tabla = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.partida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.preRequisicion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.departamento = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Material = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cantidad = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.detalle = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ejercicio = new DevExpress.XtraGrid.Columns.GridColumn();
            this.existencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.costoU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.costoTotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fechaUltimaEntrada = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imagen = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.GridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.panel;
            this.layoutControl1.Size = new System.Drawing.Size(837, 348);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // GridControl
            // 
            this.GridControl.Location = new System.Drawing.Point(2, 2);
            this.GridControl.MainView = this.Tabla;
            this.GridControl.Name = "GridControl";
            this.GridControl.Size = new System.Drawing.Size(833, 344);
            this.GridControl.TabIndex = 4;
            this.GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Tabla});
            // 
            // Tabla
            // 
            this.Tabla.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.partida,
            this.preRequisicion,
            this.departamento,
            this.Material,
            this.cantidad,
            this.descripcion,
            this.detalle,
            this.ejercicio,
            this.existencia,
            this.costoU,
            this.costoTotal,
            this.imagen,
            this.fechaUltimaEntrada});
            this.Tabla.GridControl = this.GridControl;
            this.Tabla.Name = "Tabla";
            this.Tabla.OptionsBehavior.Editable = false;
            this.Tabla.OptionsBehavior.ReadOnly = true;
            this.Tabla.OptionsView.ShowGroupPanel = false;
            // 
            // partida
            // 
            this.partida.Caption = "Partida";
            this.partida.FieldName = "partida";
            this.partida.Name = "partida";
            this.partida.Visible = true;
            this.partida.VisibleIndex = 0;
            // 
            // preRequisicion
            // 
            this.preRequisicion.Caption = "PreRequisicion";
            this.preRequisicion.FieldName = "preRequisicion";
            this.preRequisicion.Name = "preRequisicion";
            this.preRequisicion.Visible = true;
            this.preRequisicion.VisibleIndex = 1;
            // 
            // departamento
            // 
            this.departamento.Caption = "Departamento";
            this.departamento.FieldName = "departamento";
            this.departamento.Name = "departamento";
            this.departamento.Visible = true;
            this.departamento.VisibleIndex = 2;
            // 
            // Material
            // 
            this.Material.Caption = "material";
            this.Material.FieldName = "material";
            this.Material.Name = "Material";
            this.Material.Visible = true;
            this.Material.VisibleIndex = 5;
            // 
            // cantidad
            // 
            this.cantidad.Caption = "Cantidad";
            this.cantidad.FieldName = "cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.Visible = true;
            this.cantidad.VisibleIndex = 6;
            // 
            // descripcion
            // 
            this.descripcion.Caption = "Descripcion";
            this.descripcion.FieldName = "descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.Visible = true;
            this.descripcion.VisibleIndex = 3;
            // 
            // detalle
            // 
            this.detalle.Caption = "Detalle";
            this.detalle.FieldName = "detalle";
            this.detalle.Name = "detalle";
            this.detalle.Visible = true;
            this.detalle.VisibleIndex = 4;
            // 
            // ejercicio
            // 
            this.ejercicio.Caption = "Ejercicio";
            this.ejercicio.FieldName = "ejercicio";
            this.ejercicio.Name = "ejercicio";
            this.ejercicio.Visible = true;
            this.ejercicio.VisibleIndex = 7;
            // 
            // existencia
            // 
            this.existencia.Caption = "Existencia";
            this.existencia.FieldName = "existencia";
            this.existencia.Name = "existencia";
            this.existencia.Visible = true;
            this.existencia.VisibleIndex = 8;
            // 
            // costoU
            // 
            this.costoU.Caption = "Costo unitario";
            this.costoU.FieldName = "costoU";
            this.costoU.Name = "costoU";
            this.costoU.Visible = true;
            this.costoU.VisibleIndex = 9;
            // 
            // costoTotal
            // 
            this.costoTotal.Caption = "Costo Total";
            this.costoTotal.FieldName = "costoTotal";
            this.costoTotal.Name = "costoTotal";
            this.costoTotal.Visible = true;
            this.costoTotal.VisibleIndex = 10;
            // 
            // fechaUltimaEntrada
            // 
            this.fechaUltimaEntrada.Caption = "Fecha ultima entrada";
            this.fechaUltimaEntrada.FieldName = "FechaUltimaEntrada";
            this.fechaUltimaEntrada.Name = "fechaUltimaEntrada";
            this.fechaUltimaEntrada.Visible = true;
            this.fechaUltimaEntrada.VisibleIndex = 12;
            // 
            // panel
            // 
            this.panel.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.panel.GroupBordersVisible = false;
            this.panel.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.panel.Name = "panel";
            this.panel.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.panel.Size = new System.Drawing.Size(837, 348);
            this.panel.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.GridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(837, 348);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // imagen
            // 
            this.imagen.Caption = "Imagen";
            this.imagen.FieldName = "imagen";
            this.imagen.Name = "imagen";
            this.imagen.Visible = true;
            this.imagen.VisibleIndex = 11;
            // 
            // DetalleSolicitud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 348);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetalleSolicitud";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle";
            this.Load += new System.EventHandler(this.DetalleSolicitud_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup panel;
        private DevExpress.XtraGrid.GridControl GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Tabla;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn preRequisicion;
        private DevExpress.XtraGrid.Columns.GridColumn partida;
        private DevExpress.XtraGrid.Columns.GridColumn departamento;
        private DevExpress.XtraGrid.Columns.GridColumn Material;
        private DevExpress.XtraGrid.Columns.GridColumn cantidad;
        private DevExpress.XtraGrid.Columns.GridColumn detalle;
        private DevExpress.XtraGrid.Columns.GridColumn ejercicio;
        private DevExpress.XtraGrid.Columns.GridColumn existencia;
        private DevExpress.XtraGrid.Columns.GridColumn costoU;
        private DevExpress.XtraGrid.Columns.GridColumn costoTotal;
        private DevExpress.XtraGrid.Columns.GridColumn fechaUltimaEntrada;
        private DevExpress.XtraGrid.Columns.GridColumn descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn imagen;
    }
}