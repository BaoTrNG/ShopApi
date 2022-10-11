namespace ShopApp.Frm.UserFrm
{
    partial class Cartfrm
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.itemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colamount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Delbtn = new DevExpress.XtraEditors.SimpleButton();
            this.e4 = new DevExpress.XtraEditors.SpinEdit();
            this.e5 = new DevExpress.XtraEditors.TextEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Updatebtn = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.e1 = new DevExpress.XtraEditors.TextEdit();
            this.Orderbtn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Addressedit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Totaltext = new DevExpress.XtraEditors.TextEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.e1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Totaltext.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.itemsBindingSource;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5);
            this.gridControl1.Location = new System.Drawing.Point(-2, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(5);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1337, 280);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // itemsBindingSource
            // 
            this.itemsBindingSource.DataSource = typeof(ShopApp.Model_Class.CartItem);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colamount,
            this.colprice});
            this.gridView1.DetailHeight = 546;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colid
            // 
            this.colid.FieldName = "id";
            this.colid.MinWidth = 39;
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            this.colid.Width = 146;
            // 
            // colamount
            // 
            this.colamount.FieldName = "amount";
            this.colamount.MinWidth = 39;
            this.colamount.Name = "colamount";
            this.colamount.Visible = true;
            this.colamount.VisibleIndex = 1;
            this.colamount.Width = 146;
            // 
            // colprice
            // 
            this.colprice.FieldName = "price";
            this.colprice.MinWidth = 39;
            this.colprice.Name = "colprice";
            this.colprice.Visible = true;
            this.colprice.VisibleIndex = 2;
            this.colprice.Width = 146;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.Delbtn);
            this.panelControl1.Controls.Add(this.e4);
            this.panelControl1.Controls.Add(this.e5);
            this.panelControl1.Controls.Add(this.label5);
            this.panelControl1.Controls.Add(this.label4);
            this.panelControl1.Controls.Add(this.Updatebtn);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.e1);
            this.panelControl1.Location = new System.Drawing.Point(-2, 279);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(513, 328);
            this.panelControl1.TabIndex = 1;
            // 
            // Delbtn
            // 
            this.Delbtn.Location = new System.Drawing.Point(247, 244);
            this.Delbtn.Margin = new System.Windows.Forms.Padding(5);
            this.Delbtn.Name = "Delbtn";
            this.Delbtn.Size = new System.Drawing.Size(140, 32);
            this.Delbtn.TabIndex = 13;
            this.Delbtn.Text = "Xoá Khỏi Giỏ Hàng";
            this.Delbtn.Click += new System.EventHandler(this.Delbtn_Click);
            // 
            // e4
            // 
            this.e4.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.e4.Location = new System.Drawing.Point(178, 120);
            this.e4.Margin = new System.Windows.Forms.Padding(5);
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
            this.e4.Size = new System.Drawing.Size(110, 24);
            this.e4.TabIndex = 12;
            this.e4.EditValueChanged += new System.EventHandler(this.e4_EditValueChanged);
            // 
            // e5
            // 
            this.e5.Location = new System.Drawing.Point(178, 202);
            this.e5.Margin = new System.Windows.Forms.Padding(5);
            this.e5.Name = "e5";
            this.e5.Properties.ReadOnly = true;
            this.e5.Size = new System.Drawing.Size(260, 22);
            this.e5.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 208);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Tổng tiển:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 132);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Số Lượng Mua:";
            // 
            // Updatebtn
            // 
            this.Updatebtn.Location = new System.Drawing.Point(73, 244);
            this.Updatebtn.Margin = new System.Windows.Forms.Padding(5);
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.Size = new System.Drawing.Size(135, 32);
            this.Updatebtn.TabIndex = 6;
            this.Updatebtn.Text = "Cập Nhật";
            this.Updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Tên Sản Phảm:";
            // 
            // e1
            // 
            this.e1.Location = new System.Drawing.Point(178, 31);
            this.e1.Margin = new System.Windows.Forms.Padding(5);
            this.e1.Name = "e1";
            this.e1.Properties.ReadOnly = true;
            this.e1.Size = new System.Drawing.Size(195, 22);
            this.e1.TabIndex = 0;
            // 
            // Orderbtn
            // 
            this.Orderbtn.Location = new System.Drawing.Point(246, 218);
            this.Orderbtn.Margin = new System.Windows.Forms.Padding(5);
            this.Orderbtn.Name = "Orderbtn";
            this.Orderbtn.Size = new System.Drawing.Size(160, 45);
            this.Orderbtn.TabIndex = 14;
            this.Orderbtn.Text = "Đặt Hàng";
            this.Orderbtn.Click += new System.EventHandler(this.Orderbtn_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.comboBox1);
            this.panelControl2.Controls.Add(this.Addressedit);
            this.panelControl2.Controls.Add(this.label6);
            this.panelControl2.Controls.Add(this.Totaltext);
            this.panelControl2.Controls.Add(this.label3);
            this.panelControl2.Controls.Add(this.label2);
            this.panelControl2.Controls.Add(this.Orderbtn);
            this.panelControl2.Location = new System.Drawing.Point(509, 279);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(5);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(826, 328);
            this.panelControl2.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "COD",
            "ATM"});
            this.comboBox1.Location = new System.Drawing.Point(299, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(254, 24);
            this.comboBox1.TabIndex = 22;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Addressedit
            // 
            this.Addressedit.Location = new System.Drawing.Point(108, 163);
            this.Addressedit.Name = "Addressedit";
            this.Addressedit.Size = new System.Drawing.Size(445, 23);
            this.Addressedit.TabIndex = 21;
            this.Addressedit.TextChanged += new System.EventHandler(this.Address_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "Địa Chỉ:";
            // 
            // Totaltext
            // 
            this.Totaltext.Location = new System.Drawing.Point(299, 33);
            this.Totaltext.Name = "Totaltext";
            this.Totaltext.Properties.ReadOnly = true;
            this.Totaltext.Size = new System.Drawing.Size(254, 22);
            this.Totaltext.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(161, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Phương Thức Thanh Toán:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tổng Tiền:";
            // 
            // Cartfrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.Silver;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 649);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Cartfrm";
            this.Text = "Cartfrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Cartfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.e4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.e1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Totaltext.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource itemsBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colamount;
        private DevExpress.XtraGrid.Columns.GridColumn colprice;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SpinEdit e4;
        private DevExpress.XtraEditors.TextEdit e5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.SimpleButton Updatebtn;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit e1;
        private DevExpress.XtraEditors.SimpleButton Delbtn;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton Orderbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit Totaltext;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Addressedit;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}