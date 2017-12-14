namespace AplicacionAlmacen
{
    partial class Principal
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
            DevExpress.XtraEditors.TileItemElement tileItemElement1 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement2 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement3 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement4 = new DevExpress.XtraEditors.TileItemElement();
            DevExpress.XtraEditors.TileItemElement tileItemElement5 = new DevExpress.XtraEditors.TileItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.panel = new DevExpress.XtraEditors.TileControl();
            this.tileGroup2 = new DevExpress.XtraEditors.TileGroup();
            this.tileItem1 = new DevExpress.XtraEditors.TileItem();
            this.tileItem4 = new DevExpress.XtraEditors.TileItem();
            this.tileItem2 = new DevExpress.XtraEditors.TileItem();
            this.tileItem5 = new DevExpress.XtraEditors.TileItem();
            this.tileItem6 = new DevExpress.XtraEditors.TileItem();
            this.SuspendLayout();
            // 
            // panel
            // 
            this.panel.AppearanceGroupText.BackColor = System.Drawing.Color.Black;
            this.panel.AppearanceGroupText.Options.UseBackColor = true;
            this.panel.AppearanceItem.Normal.BackColor = System.Drawing.Color.Transparent;
            this.panel.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.Transparent;
            this.panel.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.panel.AppearanceItem.Normal.Options.UseBackColor = true;
            this.panel.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Groups.Add(this.tileGroup2);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.MaxId = 9;
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(380, 321);
            this.panel.TabIndex = 0;
            this.panel.Text = "tileControl1";
            // 
            // tileGroup2
            // 
            this.tileGroup2.Items.Add(this.tileItem1);
            this.tileGroup2.Items.Add(this.tileItem4);
            this.tileGroup2.Items.Add(this.tileItem2);
            this.tileGroup2.Name = "tileGroup2";
            // 
            // tileItem1
            // 
            this.tileItem1.AppearanceItem.Hovered.BackColor = System.Drawing.Color.Transparent;
            this.tileItem1.AppearanceItem.Hovered.Options.UseBackColor = true;
            this.tileItem1.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
            this.tileItem1.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tileItem1.AppearanceItem.Normal.BorderColor = System.Drawing.Color.Transparent;
            this.tileItem1.AppearanceItem.Normal.Font = new System.Drawing.Font("Franklin Gothic Medium", 11F, System.Drawing.FontStyle.Bold);
            this.tileItem1.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
            this.tileItem1.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItem1.AppearanceItem.Normal.Options.UseBorderColor = true;
            this.tileItem1.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItem1.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement1.Image = global::AplicacionAlmacen.Properties.Resources.solicitud;
            tileItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement1.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement1.Text = "Solicitudes";
            this.tileItem1.Elements.Add(tileItemElement1);
            this.tileItem1.Id = 1;
            this.tileItem1.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem1.Name = "tileItem1";
            this.tileItem1.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem1_ItemClick);
            // 
            // tileItem4
            // 
            this.tileItem4.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
            this.tileItem4.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tileItem4.AppearanceItem.Normal.Font = new System.Drawing.Font("Franklin Gothic Medium", 11F, System.Drawing.FontStyle.Bold);
            this.tileItem4.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
            this.tileItem4.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItem4.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItem4.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement2.Image = global::AplicacionAlmacen.Properties.Resources.workTool;
            tileItemElement2.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement2.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement2.Text = "Materiales";
            tileItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileItem4.Elements.Add(tileItemElement2);
            this.tileItem4.Id = 4;
            this.tileItem4.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem4.Name = "tileItem4";
            this.tileItem4.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem4_ItemClick);
            // 
            // tileItem2
            // 
            this.tileItem2.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
            this.tileItem2.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tileItem2.AppearanceItem.Normal.Font = new System.Drawing.Font("Franklin Gothic Medium", 11F, System.Drawing.FontStyle.Bold);
            this.tileItem2.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
            this.tileItem2.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItem2.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItem2.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement3.Image = global::AplicacionAlmacen.Properties.Resources.diagram;
            tileItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement3.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement3.Text = "Grupos";
            this.tileItem2.Elements.Add(tileItemElement3);
            this.tileItem2.Id = 7;
            this.tileItem2.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem2.Name = "tileItem2";
            this.tileItem2.ItemClick += new DevExpress.XtraEditors.TileItemClickEventHandler(this.tileItem2_ItemClick);
            // 
            // tileItem5
            // 
            this.tileItem5.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
            this.tileItem5.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.Gainsboro;
            this.tileItem5.AppearanceItem.Normal.Font = new System.Drawing.Font("Franklin Gothic Medium", 11F, System.Drawing.FontStyle.Bold);
            this.tileItem5.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
            this.tileItem5.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItem5.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItem5.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement4.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement4.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement4.Text = "Materiales";
            tileItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileItem5.Elements.Add(tileItemElement4);
            this.tileItem5.Id = 2;
            this.tileItem5.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem5.Name = "tileItem5";
            // 
            // tileItem6
            // 
            this.tileItem6.AppearanceItem.Normal.BackColor = System.Drawing.Color.White;
            this.tileItem6.AppearanceItem.Normal.BackColor2 = System.Drawing.Color.Gainsboro;
            this.tileItem6.AppearanceItem.Normal.Font = new System.Drawing.Font("Franklin Gothic Medium", 11F, System.Drawing.FontStyle.Bold);
            this.tileItem6.AppearanceItem.Normal.ForeColor = System.Drawing.Color.Black;
            this.tileItem6.AppearanceItem.Normal.Options.UseBackColor = true;
            this.tileItem6.AppearanceItem.Normal.Options.UseFont = true;
            this.tileItem6.AppearanceItem.Normal.Options.UseForeColor = true;
            tileItemElement5.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            tileItemElement5.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileItemElement5.Text = "Materiales";
            tileItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            this.tileItem6.Elements.Add(tileItemElement5);
            this.tileItem6.Id = 2;
            this.tileItem6.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium;
            this.tileItem6.Name = "tileItem6";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 321);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "The Bezier";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TileControl panel;
        private DevExpress.XtraEditors.TileGroup tileGroup2;
        private DevExpress.XtraEditors.TileItem tileItem1;
        private DevExpress.XtraEditors.TileItem tileItem4;
        private DevExpress.XtraEditors.TileItem tileItem2;
        private DevExpress.XtraEditors.TileItem tileItem5;
        private DevExpress.XtraEditors.TileItem tileItem6;
    }
}