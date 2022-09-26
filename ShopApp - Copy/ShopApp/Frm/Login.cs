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
using System.Text.RegularExpressions;

namespace ShopApp.Frm
{
    public partial class Login : Form
    {

        private string Email { get; set; }
        private string Password { get; set; }
        private string RePassword { get; set; }
        private bool IsLogin = true;
        private bool IsIdValid = false;
        private bool IsEmailValid = false;
        private bool IsEmailRegex = false;
        public Login()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Program.Username = textBox1.Text;
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if (IsLogin == false)
            {
                string CheckId = "{\"id\":\"" + Program.Username + "\"}";
                Console.WriteLine(CheckId);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/create/checkid");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = CheckId;

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                    if (result == "1")
                    {
                        NotiLabel.Text = "User đã tồn tại";

                    }
                    else
                    {
                        NotiLabel.Text = "";
                        IsIdValid = true;
                    }
                    Console.WriteLine("this is before " + IsIdValid);
                }
            }
        }
        private static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
        static Regex validate_emailaddress = email_validation();



        bool IsValidEmail(string eMail)
        {
            bool Result = false;

            try
            {
                var eMailValidator = new System.Net.Mail.MailAddress(eMail);

                Result = (eMail.LastIndexOf(".") > eMail.LastIndexOf("@"));
            }
            catch
            {
                Result = false;
            };

            return Result;
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            // Email = textBox3.Text;
            if (validate_emailaddress.IsMatch(textBox3.Text) != true)
            {
                NotiLabel.Text = "Invalid Email Address!";

            }
            else
            {
                Email = textBox3.Text;
                IsEmailRegex = true;
                NotiLabel.Text = "";

            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (IsLogin == false)
            {
                string CheckEmail = "{\"email\":\"" + Email + "\"}";
                Console.WriteLine(CheckEmail);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/create/checkemail");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = CheckEmail;

                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                    if (result == "1")
                    {
                        NotiLabel2.Text = "Email đã tồn tại";

                    }
                    else
                    {
                        NotiLabel2.Text = "";
                        IsEmailValid = true;
                    }
                    Console.WriteLine("this is before " + IsEmailValid);
                }
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
                    //    Console.WriteLine(Password);
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
                    // Console.WriteLine(Password);
                }
                else NotiLabel.Text = "";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (IsLogin == true)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    NotiLabel.Text = "Vui Lòng Điền Hết Thông Tin ";
                }
                else
                {
                    string Login = "{\"id\":\"" + Program.Username + "\",\"Pass\":\"" + Password + "\"}";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/login");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = Login;

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        if (result == "11")
                        {
                            NotiLabel.Text = "Login Succeed";
                        }

                        else
                        {
                            NotiLabel.Text = "No User Found";
                        }

                    }
                }
            }
            else if (IsLogin == false && IsEmailValid && IsIdValid && IsEmailRegex)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || CrmPass.Text == "" || textBox3.Text == "")
                    NotiLabel.Text = "Vui Lòng Điền Hết Thông Tin ";
                else
                {
                    Console.WriteLine("this is emaill " + IsEmailValid);
                    Console.WriteLine("this is id " + IsIdValid);
                    string Type = "USER";
                    string register = "{\"id\":\"" + Program.Username + "\",\"Pass\":\"" + Password + "\",\"Type\":\"" + Type + "\",\"Email\":\"" + Email + "\"}";
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/createUser");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        string json = register;

                        streamWriter.Write(json);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    Console.WriteLine(httpResponse.StatusCode);
                    if ((int)httpResponse.StatusCode == 200)
                    {
                        NotiLabel.Text = "Register Succeed";
                    }
                    else
                    {
                        NotiLabel.Text = "Register Failed";
                    }
                }
            }
            else if (!IsEmailRegex)
            {
                NotiLabel.Text = "Invalid Email Address!";
            }
            else NotiLabel.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            CrmPass.UseSystemPasswordChar = true;
            NotiLabel.Text = "";
            NotiLabel2.Text = "";

            //login mode disable register mode

            RePassLabel.Visible = false;
            CrmPass.Visible = false;
            textBox3.Visible = false;
            label4.Text = "";


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void SwitchBtn_Click(object sender, EventArgs e)
        {

            if (IsLogin == false)
            {
                IsLogin = true;

                RePassLabel.Visible = false;
                CrmPass.Visible = false;
                textBox3.Visible = false;
                SendBtn.Text = "Login";
                SwitchBtn.Text = "Register";
                NotiLabel.Text = "";

                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                CrmPass.Text = "";
                label4.Text = "";



            }
            else
            {
                IsLogin = false;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                CrmPass.Text = "";
                RePassLabel.Visible = true;
                CrmPass.Visible = true;
                textBox3.Visible = true;
                SendBtn.Text = "Register";
                SwitchBtn.Text = "Login";
                NotiLabel.Text = "";


                label4.Text = "Email";
            }
            Console.WriteLine(IsLogin);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else textBox2.UseSystemPasswordChar = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                CrmPass.UseSystemPasswordChar = false;
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                CrmPass.UseSystemPasswordChar = true;
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
