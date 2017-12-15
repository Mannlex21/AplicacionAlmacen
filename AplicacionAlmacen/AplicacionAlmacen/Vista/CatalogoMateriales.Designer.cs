namespace AplicacionAlmacen.Vista
{
    partial class CatalogoMateriales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatalogoMateriales));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.GridControl = new DevExpress.XtraGrid.GridControl();
            this.Tabla = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.idMaterial = new DevExpress.XtraGrid.Columns.GridColumn();
            this.descripcion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.uMedida = new DevExpress.XtraGrid.Columns.GridColumn();
            this.maximo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.minimo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.costoProm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.costoPromAnt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.importe = new DevExpress.XtraGrid.Columns.GridColumn();
            this.existencia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.localizacion = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cantIni = new DevExpress.XtraGrid.Columns.GridColumn();
            this.importeIni = new DevExpress.XtraGrid.Columns.GridColumn();
            this.fechaUltimoMov = new DevExpress.XtraGrid.Columns.GridColumn();
            this.puntoPedido = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pedidoEstandar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.marca = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).BeginInit();
            this.bindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.bindingNavigator);
            this.layoutControl1.Controls.Add(this.GridControl);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(275, 158, 650, 400);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(618, 419);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // bindingNavigator
            // 
            this.bindingNavigator.AddNewItem = null;
            this.bindingNavigator.AutoSize = false;
            this.bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator.DeleteItem = null;
            this.bindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2});
            this.bindingNavigator.Location = new System.Drawing.Point(12, 12);
            this.bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator.Name = "bindingNavigator";
            this.bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator.Size = new System.Drawing.Size(594, 30);
            this.bindingNavigator.TabIndex = 3;
            this.bindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(37, 27);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 30);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 27);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // GridControl
            // 
            this.GridControl.Location = new System.Drawing.Point(12, 46);
            this.GridControl.LookAndFeel.SkinName = "The Bezier";
            this.GridControl.LookAndFeel.UseDefaultLookAndFeel = false;
            this.GridControl.MainView = this.Tabla;
            this.GridControl.Name = "GridControl";
            this.GridControl.Size = new System.Drawing.Size(594, 361);
            this.GridControl.TabIndex = 0;
            this.GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Tabla,
            this.gridView1});
            // 
            // Tabla
            // 
            this.Tabla.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.idMaterial,
            this.descripcion,
            this.uMedida,
            this.maximo,
            this.minimo,
            this.costoProm,
            this.costoPromAnt,
            this.importe,
            this.existencia,
            this.localizacion,
            this.cantIni,
            this.importeIni,
            this.fechaUltimoMov,
            this.puntoPedido,
            this.pedidoEstandar,
            this.marca});
            this.Tabla.GridControl = this.GridControl;
            this.Tabla.Name = "Tabla";
            this.Tabla.OptionsBehavior.Editable = false;
            this.Tabla.OptionsBehavior.ReadOnly = true;
            this.Tabla.OptionsView.ColumnAutoWidth = false;
            this.Tabla.OptionsView.ShowGroupPanel = false;
            // 
            // idMaterial
            // 
            this.idMaterial.Caption = "IdMaterial";
            this.idMaterial.FieldName = "idMaterial";
            this.idMaterial.Name = "idMaterial";
            this.idMaterial.Visible = true;
            this.idMaterial.VisibleIndex = 1;
            this.idMaterial.Width = 84;
            // 
            // descripcion
            // 
            this.descripcion.Caption = "Descripcion";
            this.descripcion.FieldName = "descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.Visible = true;
            this.descripcion.VisibleIndex = 0;
            this.descripcion.Width = 90;
            // 
            // uMedida
            // 
            this.uMedida.Caption = "Unidad de Medida";
            this.uMedida.FieldName = "uMedida";
            this.uMedida.Name = "uMedida";
            this.uMedida.Visible = true;
            this.uMedida.VisibleIndex = 2;
            this.uMedida.Width = 121;
            // 
            // maximo
            // 
            this.maximo.Caption = "maximo";
            this.maximo.FieldName = "maximo";
            this.maximo.Name = "maximo";
            this.maximo.Visible = true;
            this.maximo.VisibleIndex = 3;
            this.maximo.Width = 72;
            // 
            // minimo
            // 
            this.minimo.Caption = "Minimo";
            this.minimo.FieldName = "minimo";
            this.minimo.Name = "minimo";
            this.minimo.Visible = true;
            this.minimo.VisibleIndex = 4;
            this.minimo.Width = 68;
            // 
            // costoProm
            // 
            this.costoProm.Caption = "Costo Promedio";
            this.costoProm.FieldName = "costoProm";
            this.costoProm.Name = "costoProm";
            this.costoProm.Visible = true;
            this.costoProm.VisibleIndex = 5;
            this.costoProm.Width = 111;
            // 
            // costoPromAnt
            // 
            this.costoPromAnt.Caption = "costoPromAnt";
            this.costoPromAnt.FieldName = "costoPromAnt";
            this.costoPromAnt.Name = "costoPromAnt";
            this.costoPromAnt.Visible = true;
            this.costoPromAnt.VisibleIndex = 6;
            this.costoPromAnt.Width = 103;
            // 
            // importe
            // 
            this.importe.Caption = "Importe";
            this.importe.FieldName = "importe";
            this.importe.Name = "importe";
            this.importe.Visible = true;
            this.importe.VisibleIndex = 7;
            this.importe.Width = 74;
            // 
            // existencia
            // 
            this.existencia.Caption = "Existencia";
            this.existencia.FieldName = "existencia";
            this.existencia.Name = "existencia";
            this.existencia.Visible = true;
            this.existencia.VisibleIndex = 8;
            this.existencia.Width = 84;
            // 
            // localizacion
            // 
            this.localizacion.Caption = "Localizacion";
            this.localizacion.FieldName = "localizacion";
            this.localizacion.Name = "localizacion";
            this.localizacion.Visible = true;
            this.localizacion.VisibleIndex = 9;
            this.localizacion.Width = 92;
            // 
            // cantIni
            // 
            this.cantIni.Caption = "Cantidad Inicial";
            this.cantIni.FieldName = "cantIni";
            this.cantIni.Name = "cantIni";
            this.cantIni.Visible = true;
            this.cantIni.VisibleIndex = 10;
            this.cantIni.Width = 109;
            // 
            // importeIni
            // 
            this.importeIni.Caption = "Importe inicial";
            this.importeIni.FieldName = "importeIni";
            this.importeIni.Name = "importeIni";
            this.importeIni.Visible = true;
            this.importeIni.VisibleIndex = 11;
            this.importeIni.Width = 102;
            // 
            // fechaUltimoMov
            // 
            this.fechaUltimoMov.Caption = "Fecha ultimo movimiento";
            this.fechaUltimoMov.FieldName = "fechaUltimoMov";
            this.fechaUltimoMov.Name = "fechaUltimoMov";
            this.fechaUltimoMov.Visible = true;
            this.fechaUltimoMov.VisibleIndex = 12;
            this.fechaUltimoMov.Width = 153;
            // 
            // puntoPedido
            // 
            this.puntoPedido.Caption = "Punto pedido";
            this.puntoPedido.FieldName = "puntoPedido";
            this.puntoPedido.Name = "puntoPedido";
            this.puntoPedido.Visible = true;
            this.puntoPedido.VisibleIndex = 13;
            this.puntoPedido.Width = 99;
            // 
            // pedidoEstandar
            // 
            this.pedidoEstandar.Caption = "Pedido estandar";
            this.pedidoEstandar.FieldName = "pedidoEstandar";
            this.pedidoEstandar.Name = "pedidoEstandar";
            this.pedidoEstandar.Visible = true;
            this.pedidoEstandar.VisibleIndex = 14;
            this.pedidoEstandar.Width = 114;
            // 
            // marca
            // 
            this.marca.Caption = "Marca";
            this.marca.FieldName = "marca";
            this.marca.Name = "marca";
            this.marca.Visible = true;
            this.marca.VisibleIndex = 15;
            this.marca.Width = 65;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.GridControl;
            this.gridView1.Name = "gridView1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2,
            this.layoutControlItem1});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(618, 419);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.bindingNavigator;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(598, 34);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.GridControl;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 34);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(598, 365);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // CatalogoMateriales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 419);
            this.Controls.Add(this.layoutControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "The Bezier";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "CatalogoMateriales";
            this.Text = "Materiales";
            this.Load += new System.EventHandler(this.CatalogoMateriales_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator)).EndInit();
            this.bindingNavigator.ResumeLayout(false);
            this.bindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Tabla)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl GridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView Tabla;
        private DevExpress.XtraGrid.Columns.GridColumn descripcion;
        private DevExpress.XtraGrid.Columns.GridColumn idMaterial;
        private DevExpress.XtraGrid.Columns.GridColumn uMedida;
        private DevExpress.XtraGrid.Columns.GridColumn maximo;
        private DevExpress.XtraGrid.Columns.GridColumn minimo;
        private DevExpress.XtraGrid.Columns.GridColumn costoProm;
        private DevExpress.XtraGrid.Columns.GridColumn costoPromAnt;
        private DevExpress.XtraGrid.Columns.GridColumn importe;
        private DevExpress.XtraGrid.Columns.GridColumn existencia;
        private DevExpress.XtraGrid.Columns.GridColumn localizacion;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.Columns.GridColumn cantIni;
        private DevExpress.XtraGrid.Columns.GridColumn importeIni;
        private DevExpress.XtraGrid.Columns.GridColumn fechaUltimoMov;
        private DevExpress.XtraGrid.Columns.GridColumn puntoPedido;
        private DevExpress.XtraGrid.Columns.GridColumn pedidoEstandar;
        private DevExpress.XtraGrid.Columns.GridColumn marca;
        private System.Windows.Forms.BindingNavigator bindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private System.Windows.Forms.BindingSource bindingSource;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
    }
}