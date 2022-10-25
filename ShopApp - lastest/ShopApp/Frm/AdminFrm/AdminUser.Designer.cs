namespace ShopApp.Frm.AdminFrm
{
    partial class AdminUser
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.IDbox = new DevExpress.XtraEditors.TextEdit();
            this.PassBox = new DevExpress.XtraEditors.TextEdit();
            this.Updatebtn = new DevExpress.XtraEditors.SimpleButton();
            this.Deletebtn = new DevExpress.XtraEditors.SimpleButton();
            this.Editbtn = new DevExpress.XtraEditors.SimpleButton();
            this.NotiLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.StatusBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Emailbox = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IDbox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassBox.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emailbox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(5);
            this.gridControl1.Location = new System.Drawing.Point(1, 1);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(5);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1334, 424);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 546;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.Emailbox);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.StatusBox);
            this.panelControl1.Controls.Add(this.IDbox);
            this.panelControl1.Controls.Add(this.PassBox);
            this.panelControl1.Controls.Add(this.Updatebtn);
            this.panelControl1.Controls.Add(this.Deletebtn);
            this.panelControl1.Controls.Add(this.Editbtn);
            this.panelControl1.Controls.Add(this.NotiLabel);
            this.panelControl1.Controls.Add(this.label2);
            this.panelControl1.Controls.Add(this.label1);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Location = new System.Drawing.Point(1, 425);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(721, 212);
            this.panelControl1.TabIndex = 4;
            // 
            // IDbox
            // 
            this.IDbox.Location = new System.Drawing.Point(142, 17);
            this.IDbox.Name = "IDbox";
            this.IDbox.Properties.ReadOnly = true;
            this.IDbox.Size = new System.Drawing.Size(125, 22);
            this.IDbox.TabIndex = 21;
            // 
            // PassBox
            // 
            this.PassBox.Location = new System.Drawing.Point(142, 48);
            this.PassBox.Name = "PassBox";
            this.PassBox.Properties.ReadOnly = true;
            this.PassBox.Size = new System.Drawing.Size(125, 22);
            this.PassBox.TabIndex = 18;
            this.PassBox.EditValueChanged += new System.EventHandler(this.PassBox_EditValueChanged);
            // 
            // Updatebtn
            // 
            this.Updatebtn.Location = new System.Drawing.Point(187, 146);
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.Size = new System.Drawing.Size(127, 29);
            this.Updatebtn.TabIndex = 16;
            this.Updatebtn.Text = "Cập Nhật";
            this.Updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // Deletebtn
            // 
            this.Deletebtn.Location = new System.Drawing.Point(320, 146);
            this.Deletebtn.Name = "Deletebtn";
            this.Deletebtn.Size = new System.Drawing.Size(127, 29);
            this.Deletebtn.TabIndex = 15;
            this.Deletebtn.Text = "Khoá User";
            this.Deletebtn.Click += new System.EventHandler(this.Deletebtn_Click);
            // 
            // Editbtn
            // 
            this.Editbtn.Location = new System.Drawing.Point(29, 146);
            this.Editbtn.Name = "Editbtn";
            this.Editbtn.Size = new System.Drawing.Size(151, 29);
            this.Editbtn.TabIndex = 14;
            this.Editbtn.Text = "Edit Thông Tin User";
            this.Editbtn.Click += new System.EventHandler(this.Editbtn_Click);
            // 
            // NotiLabel
            // 
            this.NotiLabel.AutoSize = true;
            this.NotiLabel.Location = new System.Drawing.Point(139, 114);
            this.NotiLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NotiLabel.Name = "NotiLabel";
            this.NotiLabel.Size = new System.Drawing.Size(41, 16);
            this.NotiLabel.TabIndex = 12;
            this.NotiLabel.Text = "label4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Password:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(37, 20);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(43, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "UserID:";
            // 
            // StatusBox
            // 
            this.StatusBox.FormattingEnabled = true;
            this.StatusBox.Items.AddRange(new object[] {
            "ok",
            "banned"});
            this.StatusBox.Location = new System.Drawing.Point(142, 76);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(125, 24);
            this.StatusBox.TabIndex = 22;
            this.StatusBox.SelectedIndexChanged += new System.EventHandler(this.StatusBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 23;
            this.label3.Text = "email:";
            // 
            // Emailbox
            // 
            this.Emailbox.Location = new System.Drawing.Point(415, 13);
            this.Emailbox.Name = "Emailbox";
            this.Emailbox.Properties.ReadOnly = true;
            this.Emailbox.Size = new System.Drawing.Size(125, 22);
            this.Emailbox.TabIndex = 24;
            this.Emailbox.EditValueChanged += new System.EventHandler(this.Emailbox_EditValueChanged);
            // 
            // AdminUser
            // 
            this.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 685);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.gridControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AdminUser";
            this.Text = "AdminUser";
            this.Load += new System.EventHandler(this.AdminUserLoad);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IDbox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PassBox.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Emailbox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.TextEdit PassBox;
        private DevExpress.XtraEditors.SimpleButton Updatebtn;
        private DevExpress.XtraEditors.SimpleButton Deletebtn;
        private DevExpress.XtraEditors.SimpleButton Editbtn;
        private System.Windows.Forms.Label NotiLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit IDbox;
        private System.Windows.Forms.ComboBox StatusBox;
        private DevExpress.XtraEditors.TextEdit Emailbox;
        private System.Windows.Forms.Label label3;
    }
}