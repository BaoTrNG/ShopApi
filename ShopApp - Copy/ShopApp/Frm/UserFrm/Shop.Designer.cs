namespace ShopApp.Frm.UserFrm
{
    partial class Shop
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.e4 = new DevExpress.XtraEditors.SpinEdit();
            this.e5 = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.e3 = new DevExpress.XtraEditors.TextEdit();
            this.label4 = new System.Windows.Forms.Label();
            this.Buybtn = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.e2 = new DevExpress.XtraEditors.TextEdit();
            this.e1 = new DevExpress.XtraEditors.TextEdit();
            this.webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.e4);
            this.panelControl1.Controls.Add(this.e5);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.e3);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.Buybtn);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.e2);
            this.panelControl1.Controls.Add(this.e1);
            this.panelControl1.Location = new System.Drawing.Point(0, 339);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(454, 337);
            this.panelControl1.TabIndex = 0;
            // 
            // e4
            // 
            this.e4.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.e4.Location = new System.Drawing.Point(105, 182);
            this.e4.Name = "e4";
            this.e4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.e4.Properties.MaxLength = 1;
            this.e4.Properties.MaxValue = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.e4.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.e4.Properties.UseReadOnlyAppearance = false;
            this.e4.Size = new System.Drawing.Size(70, 24);
            this.e4.TabIndex = 12;
            this.e4.EditValueChanged += new System.EventHandler(this.e4_EditValueChanged_1);
            // 
            // e5
            // 
            this.e5.Location = new System.Drawing.Point(253, 184);
            this.e5.Name = "e5";
            this.e5.Properties.ReadOnly = true;
            this.e5.Size = new System.Drawing.Size(166, 22);
            this.e5.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 190);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tổng tiển:";
            // 
            // e3
            // 
            this.e3.Location = new System.Drawing.Point(114, 99);
            this.e3.Name = "e3";
            this.e3.Properties.ReadOnly = true;
            this.e3.Size = new System.Drawing.Size(125, 22);
            this.e3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số Lượng Mua:";
            // 
            // Buybtn
            // 
            this.Buybtn.Location = new System.Drawing.Point(110, 241);
            this.Buybtn.Name = "Buybtn";
            this.Buybtn.Size = new System.Drawing.Size(137, 29);
            this.Buybtn.TabIndex = 6;
            this.Buybtn.Text = "Thêm Vào Giỏ Hàng";
            this.Buybtn.Click += new System.EventHandler(this.Buybtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Giá Sản Phẩm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hãng Sản Xuất:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên Sản Phảm:";
            // 
            // e2
            // 
            this.e2.Location = new System.Drawing.Point(114, 58);
            this.e2.Name = "e2";
            this.e2.Properties.ReadOnly = true;
            this.e2.Size = new System.Drawing.Size(125, 22);
            this.e2.TabIndex = 1;
            // 
            // e1
            // 
            this.e1.Location = new System.Drawing.Point(114, 20);
            this.e1.Name = "e1";
            this.e1.Properties.ReadOnly = true;
            this.e1.Size = new System.Drawing.Size(125, 22);
            this.e1.TabIndex = 0;
            // 
            // webView21
            // 
            this.webView21.AllowExternalDrop = true;
            this.webView21.CreationProperties = null;
            this.webView21.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView21.Location = new System.Drawing.Point(450, 341);
            this.webView21.Name = "webView21";
            this.webView21.Size = new System.Drawing.Size(823, 352);
            this.webView21.TabIndex = 3;
            this.webView21.ZoomFactor = 1D;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(0, 1);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1273, 341);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // Shop
            // 
            this.Appearance.BackColor = System.Drawing.Color.Silver;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 705);
            this.Controls.Add(this.webView21);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Shop";
            this.Text = "XtraForm1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Shop_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.webView21)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private DevExpress.XtraEditors.TextEdit e2;
        private DevExpress.XtraEditors.TextEdit e1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit e3;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton Buybtn;
        private DevExpress.XtraEditors.TextEdit e5;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.SpinEdit e4;
    }
}