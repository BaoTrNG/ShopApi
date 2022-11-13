namespace ShopApp.Frm
{
    partial class Login
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
            this.SendBtn = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RePassLabel = new System.Windows.Forms.Label();
            this.CrmPass = new System.Windows.Forms.TextBox();
            this.NotiLabel = new System.Windows.Forms.Label();
            this.SwitchBtn = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.NotiLabel2 = new System.Windows.Forms.Label();
            this.Exitbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SendBtn
            // 
            this.SendBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(84)))), ((int)(((byte)(174)))));
            this.SendBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SendBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendBtn.ForeColor = System.Drawing.Color.White;
            this.SendBtn.Location = new System.Drawing.Point(51, 402);
            this.SendBtn.Margin = new System.Windows.Forms.Padding(4);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(113, 48);
            this.SendBtn.TabIndex = 0;
            this.SendBtn.Text = "Login";
            this.SendBtn.UseVisualStyleBackColor = false;
            this.SendBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 144);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(242, 30);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.Leave += new System.EventHandler(this.textBox1_Leave_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(51, 270);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(242, 30);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 117);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Nirmala UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label3.Location = new System.Drawing.Point(46, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 45);
            this.label3.TabIndex = 5;
            this.label3.Text = "Shop App";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // RePassLabel
            // 
            this.RePassLabel.AutoSize = true;
            this.RePassLabel.Location = new System.Drawing.Point(47, 304);
            this.RePassLabel.Name = "RePassLabel";
            this.RePassLabel.Size = new System.Drawing.Size(155, 23);
            this.RePassLabel.TabIndex = 6;
            this.RePassLabel.Text = "Confirm Password";
            // 
            // CrmPass
            // 
            this.CrmPass.Location = new System.Drawing.Point(51, 331);
            this.CrmPass.Margin = new System.Windows.Forms.Padding(4);
            this.CrmPass.Name = "CrmPass";
            this.CrmPass.Size = new System.Drawing.Size(242, 30);
            this.CrmPass.TabIndex = 7;
            this.CrmPass.TextChanged += new System.EventHandler(this.CrmPass_TextChanged);
            // 
            // NotiLabel
            // 
            this.NotiLabel.AutoSize = true;
            this.NotiLabel.BackColor = System.Drawing.Color.White;
            this.NotiLabel.Location = new System.Drawing.Point(50, 467);
            this.NotiLabel.Name = "NotiLabel";
            this.NotiLabel.Size = new System.Drawing.Size(53, 23);
            this.NotiLabel.TabIndex = 8;
            this.NotiLabel.Text = "temp";
            this.NotiLabel.Click += new System.EventHandler(this.label5_Click);
            // 
            // SwitchBtn
            // 
            this.SwitchBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(116)))), ((int)(((byte)(84)))), ((int)(((byte)(174)))));
            this.SwitchBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SwitchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SwitchBtn.ForeColor = System.Drawing.Color.White;
            this.SwitchBtn.Location = new System.Drawing.Point(188, 402);
            this.SwitchBtn.Name = "SwitchBtn";
            this.SwitchBtn.Size = new System.Drawing.Size(105, 48);
            this.SwitchBtn.TabIndex = 9;
            this.SwitchBtn.Text = "Register";
            this.SwitchBtn.UseVisualStyleBackColor = false;
            this.SwitchBtn.Click += new System.EventHandler(this.SwitchBtn_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(53, 368);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(155, 27);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Show Password";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Email";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(51, 204);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(242, 30);
            this.textBox3.TabIndex = 13;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // NotiLabel2
            // 
            this.NotiLabel2.AutoSize = true;
            this.NotiLabel2.BackColor = System.Drawing.Color.White;
            this.NotiLabel2.Location = new System.Drawing.Point(51, 503);
            this.NotiLabel2.Name = "NotiLabel2";
            this.NotiLabel2.Size = new System.Drawing.Size(53, 23);
            this.NotiLabel2.TabIndex = 14;
            this.NotiLabel2.Text = "temp";
            // 
            // Exitbtn
            // 
            this.Exitbtn.BackColor = System.Drawing.Color.Blue;
            this.Exitbtn.ForeColor = System.Drawing.Color.White;
            this.Exitbtn.Location = new System.Drawing.Point(248, -1);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(89, 45);
            this.Exitbtn.TabIndex = 15;
            this.Exitbtn.Text = "Exit";
            this.Exitbtn.UseVisualStyleBackColor = false;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(338, 544);
            this.Controls.Add(this.Exitbtn);
            this.Controls.Add(this.NotiLabel2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.SwitchBtn);
            this.Controls.Add(this.NotiLabel);
            this.Controls.Add(this.CrmPass);
            this.Controls.Add(this.RePassLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.SendBtn);
            this.Font = new System.Drawing.Font("Nirmala UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(165)))), ((int)(((byte)(169)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label RePassLabel;
        private System.Windows.Forms.TextBox CrmPass;
        private System.Windows.Forms.Label NotiLabel;
        private System.Windows.Forms.Button SwitchBtn;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label NotiLabel2;
        private System.Windows.Forms.Button Exitbtn;
    }
}