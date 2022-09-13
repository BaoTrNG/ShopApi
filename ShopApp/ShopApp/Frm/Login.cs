using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.IO;
namespace ShopApp.Frm
{
    public partial class Login : Form
    {

        public string Password { get; set; }
        public string RePassword { get; set; }
        public bool IsLogin = true;
        public Login()
        {
            InitializeComponent();

            NotiLabel.Text = "";

            //login mode disable register mode
            checkBox2.Visible = false;
            RePassLabel.Visible = false;
            CrmPass.Visible = false;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Program.Username = textBox1.Text;
            if (Program.Username == "")
            {
                SendBtn.Visible = false;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Password = textBox2.Text;
            if (IsLogin == false)
            {
                if (RePassword != Password && RePassword != "")
                {
                    NotiLabel.Text = "Password not match";
                    Console.WriteLine(Password);
                }
                else NotiLabel.Text = "";
            }

        }
        private void CrmPass_TextChanged(object sender, EventArgs e)
        {
            RePassword = CrmPass.Text;
            if (IsLogin == false)
            {
                if (RePassword != Password && Password != "")
                {
                    NotiLabel.Text = "Password not match";
                    Console.WriteLine(Password);
                }
                else NotiLabel.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" && CrmPass.Text == "")
            {
                NotiLabel.Text = "Vui Lòng Điền Hết Thông Tin ";
            }
            else if (IsLogin == true)
            {
                string Login = "{\"id\":\"" + Program.Username + "\",\"Pass\":\"" + Password + "\"}";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/login");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = Login;/* "{\"id\":\"test\"," +
                              "\"Pass\":\"123\"}"; */

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    if (result == "1")
                        NotiLabel.Text = "Login Succeed";
                    else NotiLabel.Text = "No User Found";
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void SwitchBtn_Click(object sender, EventArgs e)
        {
            if (IsLogin == true)
            {
                IsLogin = false;
                checkBox2.Visible = true;
                RePassLabel.Visible = true;
                CrmPass.Visible = true;
                SendBtn.Text = "Register";
                SwitchBtn.Text = "Login";
            }
            else
            {
                IsLogin = true;
                checkBox2.Visible = false;
                RePassLabel.Visible = false;
                CrmPass.Visible = false;
                SendBtn.Text = "Login";
                SwitchBtn.Text = "Register";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else textBox2.UseSystemPasswordChar = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                CrmPass.UseSystemPasswordChar = false;
            }
            else CrmPass.UseSystemPasswordChar = true;
        }
    }
}
