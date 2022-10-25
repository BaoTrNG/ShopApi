namespace ShopApp.Frm.AdminFrm
{
    partial class AdminOrder
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colphone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colstatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colpayment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coladdress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coldate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.coltotal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Statusbox = new System.Windows.Forms.ComboBox();
            this.Updatebtn = new DevExpress.XtraEditors.SimpleButton();
            this.Deletebtn = new DevExpress.XtraEditors.SimpleButton();
            this.EditOrderbtn = new DevExpress.XtraEditors.SimpleButton();
            this.NotiLabel = new System.Windows.Forms.Label();
            this.PhoneBox = new DevExpress.XtraEditors.TextEdit();
            this.AddressBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.PaymentBox = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentBox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1337, 336);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            this.gridControl1.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.gridControl1_ViewRegistered);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colphone,
            this.colstatus,
            this.colpayment,
            this.coladdress,
            this.coldate,
            this.coltotal});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colphone
            // 
            this.colphone.FieldName = "phone";
            this.colphone.MinWidth = 24;
            this.colphone.Name = "colphone";
            this.colphone.Visible = true;
            this.colphone.VisibleIndex = 0;
            this.colphone.Width = 94;
            // 
            // colstatus
            // 
            this.colstatus.FieldName = "status";
            this.colstatus.MinWidth = 24;
            this.colstatus.Name = "colstatus";
            this.colstatus.Visible = true;
            this.colstatus.VisibleIndex = 1;
            this.colstatus.Width = 94;
            // 
            // colpayment
            // 
            this.colpayment.FieldName = "payment";
            this.colpayment.MinWidth = 24;
            this.colpayment.Name = "colpayment";
            this.colpayment.Visible = true;
            this.colpayment.VisibleIndex = 2;
            this.colpayment.Width = 94;
            // 
            // coladdress
            // 
            this.coladdress.FieldName = "address";
            this.coladdress.MinWidth = 24;
            this.coladdress.Name = "coladdress";
            this.coladdress.Visible = true;
            this.coladdress.VisibleIndex = 3;
            this.coladdress.Width = 94;
            // 
            // coldate
            // 
            this.coldate.FieldName = "date";
            this.coldate.MinWidth = 24;
            this.coldate.Name = "coldate";
            this.coldate.Visible = true;
            this.coldate.VisibleIndex = 4;
            this.coldate.Width = 94;
            // 
            // coltotal
            // 
            this.coltotal.FieldName = "total";
            this.coltotal.MinWidth = 24;
            this.coltotal.Name = "coltotal";
            this.coltotal.Visible = true;
            this.coltotal.VisibleIndex = 5;
            this.coltotal.Width = 94;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.PaymentBox);
            this.panelControl1.Controls.Add(this.Statusbox);
            this.panelControl1.Controls.Add(this.Updatebtn);
            this.panelControl1.Controls.Add(this.Deletebtn);
            this.panelControl1.Controls.Add(this.EditOrderbtn);
            this.panelControl1.Controls.Add(this.NotiLabel);
            this.panelControl1.Controls.Add(this.PhoneBox);
            this.panelControl1.Controls.Add(this.AddressBox);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(0, 336);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(720, 275);
            this.panelControl1.TabIndex = 2;
            // 
            // Statusbox
            // 
            this.Statusbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Statusbox.FormattingEnabled = true;
            this.Statusbox.Items.AddRange(new object[] {
            "pending",
            "canceled",
            "packaging",
            "delivering",
            "done"});
            this.Statusbox.Location = new System.Drawing.Point(142, 12);
            this.Statusbox.Margin = new System.Windows.Forms.Padding(4);
            this.Statusbox.Name = "Statusbox";
            this.Statusbox.Size = new System.Drawing.Size(116, 24);
            this.Statusbox.TabIndex = 17;
            this.Statusbox.SelectedIndexChanged += new System.EventHandler(this.Statusbox_SelectedIndexChanged);
            // 
            // Updatebtn
            // 
            this.Updatebtn.Location = new System.Drawing.Point(187, 175);
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.Size = new System.Drawing.Size(127, 29);
            this.Updatebtn.TabIndex = 16;
            this.Updatebtn.Text = "Cập Nhật";
            this.Updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.Location = new System.Drawing.Point(320, 175);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(127, 29);
            this.Deletebtn.TabIndex = 15;
            this.Deletebtn.Text = "Xoá Đơn";
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // EditOrderbtn
            // 
            this.EditOrderbtn.Location = new System.Drawing.Point(29, 175);
            this.EditOrderbtn.Name = "EditOrderbtn";
            this.EditOrderbtn.Size = new System.Drawing.Size(151, 29);
            this.EditOrderbtn.TabIndex = 14;
            this.EditOrderbtn.Text = "Edit Thông Tin Đơn Hàng";
            this.EditOrderbtn.Click += new System.EventHandler(this.EditOrderbtn_Click);
            // 
            // NotiLabel
            // 
            this.NotiLabel.AutoSize = true;
            this.NotiLabel.Location = new System.Drawing.Point(139, 145);
            this.NotiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NotiLabel.Name = "NotiLabel";
            this.NotiLabel.Size = new System.Drawing.Size(41, 16);
            this.NotiLabel.TabIndex = 12;
            this.NotiLabel.Text = "label4";
            // 
            // PhoneBox
            // 
            this.PhoneBox.Location = new System.Drawing.Point(142, 109);
            this.PhoneBox.Margin = new System.Windows.Forms.Padding(4);
            this.PhoneBox.Name = "PhoneBox";
            this.PhoneBox.Properties.MaxLength = 10;
            this.PhoneBox.Properties.ReadOnly = true;
            this.PhoneBox.Size = new System.Drawing.Size(246, 22);
            this.PhoneBox.TabIndex = 11;
            // 
            // AddressBox
            // 
            this.AddressBox.Location = new System.Drawing.Point(142, 78);
            this.AddressBox.Margin = new System.Windows.Forms.Padding(4);
            this.AddressBox.Name = "AddressBox";
            this.AddressBox.ReadOnly = true;
            this.AddressBox.Size = new System.Drawing.Size(298, 23);
            this.AddressBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 115);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Số Điện Thoại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Payment:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(37, 20);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(41, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Status:";
            // 
            // PaymentBox
            // 
            this.PaymentBox.Location = new System.Drawing.Point(142, 51);
            this.PaymentBox.Name = "PaymentBox";
            this.PaymentBox.Properties.ReadOnly = true;
            this.PaymentBox.Size = new System.Drawing.Size(116, 22);
            this.PaymentBox.TabIndex = 18;
            // 
            // AdminOrder
            // 
            this.Appearance.BackColor = System.Drawing.Color.Gray;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1340, 612);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminOrder";
            this.Text = "AdminOrder";
            this.Load += new System.EventHandler(this.OrderLoad);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhoneBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PaymentBox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colphone;
        private DevExpress.XtraGrid.Columns.GridColumn colstatus;
        private DevExpress.XtraGrid.Columns.GridColumn colpayment;
        private DevExpress.XtraGrid.Columns.GridColumn coladdress;
        private DevExpress.XtraGrid.Columns.GridColumn coldate;
        private DevExpress.XtraGrid.Columns.GridColumn coltotal;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton Updatebtn;
        private DevExpress.XtraEditors.SimpleButton Deletebtn;
        private DevExpress.XtraEditors.SimpleButton EditOrderbtn;
        private System.Windows.Forms.Label NotiLabel;
        private DevExpress.XtraEditors.TextEdit PhoneBox;
        private System.Windows.Forms.TextBox AddressBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox Statusbox;
        private DevExpress.XtraEditors.TextEdit PaymentBox;
    }
}