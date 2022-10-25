namespace ShopApp.Frm.UserFrm
{
    partial class Userfrm
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
            this.TotalMoney = new System.Windows.Forms.Label();
            this.TotalOrder = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.Updatebtn = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.Pass = new System.Windows.Forms.Button();
            this.PassCheck = new System.Windows.Forms.CheckBox();
            this.OldPass = new System.Windows.Forms.TextBox();
            this.NewPass = new System.Windows.Forms.TextBox();
            this.ConfirmPass = new System.Windows.Forms.TextBox();
            this.noti = new System.Windows.Forms.Label();
            this.Phonebox = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Phonebox.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.Phonebox);
            this.panelControl1.Controls.Add(this.noti);
            this.panelControl1.Controls.Add(this.ConfirmPass);
            this.panelControl1.Controls.Add(this.NewPass);
            this.panelControl1.Controls.Add(this.OldPass);
            this.panelControl1.Controls.Add(this.PassCheck);
            this.panelControl1.Controls.Add(this.TotalMoney);
            this.panelControl1.Controls.Add(this.TotalOrder);
            this.panelControl1.Controls.Add(this.UserName);
            this.panelControl1.Controls.Add(this.Updatebtn);
            this.panelControl1.Controls.Add(this.button2);
            this.panelControl1.Controls.Add(this.Pass);
            this.panelControl1.Location = new System.Drawing.Point(0, -1);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(480, 685);
            this.panelControl1.TabIndex = 0;
            // 
            // TotalMoney
            // 
            this.TotalMoney.AutoSize = true;
            this.TotalMoney.Location = new System.Drawing.Point(12, 185);
            this.TotalMoney.Name = "TotalMoney";
            this.TotalMoney.Size = new System.Drawing.Size(41, 16);
            this.TotalMoney.TabIndex = 6;
            this.TotalMoney.Text = "label2";
            // 
            // TotalOrder
            // 
            this.TotalOrder.AutoSize = true;
            this.TotalOrder.Location = new System.Drawing.Point(12, 139);
            this.TotalOrder.Name = "TotalOrder";
            this.TotalOrder.Size = new System.Drawing.Size(41, 16);
            this.TotalOrder.TabIndex = 5;
            this.TotalOrder.Text = "label1";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Location = new System.Drawing.Point(12, 99);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(41, 16);
            this.UserName.TabIndex = 4;
            this.UserName.Text = "label1";
            // 
            // Updatebtn
            // 
            this.Updatebtn.Location = new System.Drawing.Point(229, 397);
            this.Updatebtn.Name = "Updatebtn";
            this.Updatebtn.Size = new System.Drawing.Size(142, 23);
            this.Updatebtn.TabIndex = 2;
            this.Updatebtn.Text = "Cập Nhật";
            this.Updatebtn.UseVisualStyleBackColor = true;
            this.Updatebtn.Click += new System.EventHandler(this.Updatebtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 271);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(170, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Thêm Số Điện Thoại";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Pass
            // 
            this.Pass.Location = new System.Drawing.Point(15, 300);
            this.Pass.Name = "Pass";
            this.Pass.Size = new System.Drawing.Size(167, 23);
            this.Pass.TabIndex = 0;
            this.Pass.Text = "Đổi Pass";
            this.Pass.UseVisualStyleBackColor = true;
            this.Pass.Click += new System.EventHandler(this.Pass_Click);
            // 
            // PassCheck
            // 
            this.PassCheck.AutoSize = true;
            this.PassCheck.Location = new System.Drawing.Point(15, 489);
            this.PassCheck.Name = "PassCheck";
            this.PassCheck.Size = new System.Drawing.Size(120, 20);
            this.PassCheck.TabIndex = 11;
            this.PassCheck.Text = "Show Password";
            this.PassCheck.UseVisualStyleBackColor = true;
            this.PassCheck.CheckedChanged += new System.EventHandler(this.PassCheck_CheckedChanged);
            // 
            // OldPass
            // 
            this.OldPass.Location = new System.Drawing.Point(15, 350);
            this.OldPass.Name = "OldPass";
            this.OldPass.Size = new System.Drawing.Size(167, 23);
            this.OldPass.TabIndex = 12;
            this.OldPass.Text = "Mật Khẩu Cũ";
            this.OldPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OldPass.Click += new System.EventHandler(this.OldPass_Click);
            this.OldPass.TextChanged += new System.EventHandler(this.OldPass_TextChanged);
            // 
            // NewPass
            // 
            this.NewPass.Location = new System.Drawing.Point(15, 398);
            this.NewPass.Name = "NewPass";
            this.NewPass.Size = new System.Drawing.Size(167, 23);
            this.NewPass.TabIndex = 13;
            this.NewPass.Text = "Mật Khẩu Mới";
            this.NewPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NewPass.Click += new System.EventHandler(this.NewPass_Click);
            this.NewPass.TextChanged += new System.EventHandler(this.NewPass_TextChanged);
            // 
            // ConfirmPass
            // 
            this.ConfirmPass.Location = new System.Drawing.Point(12, 447);
            this.ConfirmPass.Name = "ConfirmPass";
            this.ConfirmPass.Size = new System.Drawing.Size(170, 23);
            this.ConfirmPass.TabIndex = 14;
            this.ConfirmPass.Text = "Nhập Lại Mật Khảu Mới";
            this.ConfirmPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ConfirmPass.Click += new System.EventHandler(this.ConfirmPass_Click);
            this.ConfirmPass.TextChanged += new System.EventHandler(this.ConfirmPass_TextChanged);
            // 
            // noti
            // 
            this.noti.AutoSize = true;
            this.noti.Location = new System.Drawing.Point(216, 353);
            this.noti.Name = "noti";
            this.noti.Size = new System.Drawing.Size(41, 16);
            this.noti.TabIndex = 16;
            this.noti.Text = "label1";
            // 
            // Phonebox
            // 
            this.Phonebox.Location = new System.Drawing.Point(229, 272);
            this.Phonebox.Name = "Phonebox";
            this.Phonebox.Properties.MaxLength = 10;
            this.Phonebox.Size = new System.Drawing.Size(188, 22);
            this.Phonebox.TabIndex = 17;
            this.Phonebox.EditValueChanged += new System.EventHandler(this.Phonebox_EditValueChanged);
            // 
            // Userfrm
            // 
            this.Appearance.BackColor = System.Drawing.Color.DarkGray;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1361, 685);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Userfrm";
            this.Text = "Userfrm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OrderFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Phonebox.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Button Updatebtn;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button Pass;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.Label TotalMoney;
        private System.Windows.Forms.Label TotalOrder;
        private System.Windows.Forms.CheckBox PassCheck;
        private System.Windows.Forms.TextBox ConfirmPass;
        private System.Windows.Forms.TextBox NewPass;
        private System.Windows.Forms.TextBox OldPass;
        private System.Windows.Forms.Label noti;
        private DevExpress.XtraEditors.TextEdit Phonebox;
    }
}