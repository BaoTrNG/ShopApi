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
using ShopApp.Model_Class;
using System.Text.Json;

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
                // Console.WriteLine(CheckId);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APICheckid);
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
                    //  Console.WriteLine(result);
                    if (result == "1")
                    {
                        NotiLabel.Text = "User đã tồn tại";
                        IsIdValid = false;
                    }
                    else
                    {
                        NotiLabel.Text = "";
                        IsIdValid = true;
                    }
                    // Console.WriteLine("this is before " + IsIdValid);
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
            if (validate_emailaddress.IsMatch(textBox3.Text) != true && IsLogin == false)
            {
                NotiLabel.Text = "Invalid Email Address!";
                IsEmailRegex = false;
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
                // Console.WriteLine(CheckEmail);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APICheckMail);
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
                    // Console.WriteLine(result);
                    if (result == "1")
                    {
                        NotiLabel2.Text = "Email đã tồn tại";
                        IsEmailValid = false;
                    }
                    else
                    {
                        NotiLabel2.Text = "";
                        IsEmailValid = true;
                    }
                    // Console.WriteLine("this is before " + IsEmailValid);
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

        private void CreateTempCart(string user)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APICreateTempCart);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                //string json = JsonSerializer.Serialize(Program.tempCart);
                string json = "{\"id\":\"" + user + "\"}";
                //    Console.WriteLine("this is the " + json);
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var res = JsonSerializer.Deserialize<Response>(result);
                if (res.code == 1)
                {
                    MessageBox.Show("Tạo giỏ hàng tạm thành công");
                }
                else if (res.code == 0)
                {

                }
            }
        }
        private void GetPhone()
        {
            string json = "{\"id\":\"" + Program.Username + "\"}";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIGetAdminPhone);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                Program.phone = result;
            }
        }
        void validator()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (IsLogin == true)
            {
                NotiLabel.Text = "";
                NotiLabel2.Text = "";
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    NotiLabel.Text = "Vui Lòng Điền Hết Thông Tin ";
                }
                else
                {
                    try
                    {
                        NotiLabel.Text = "Đang Login";

                        string Login = "{\"id\":\"" + Program.Username + "\",\"Pass\":\"" + Password + "\"}";
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APILogin);
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
                            var response = JsonSerializer.Deserialize<Response>(result);
                            if (response.code == 11)
                            {
                                Program.Username = textBox1.Text;
                                Program.UserType = "user";
                                Program.JwtToken = response.msg;
                                NotiLabel.Text = "Login Succeed";
                                Form f = new Main();
                                f.Show();
                                this.ShowInTaskbar = false;
                                this.Visible = false;
                            }
                            else if (response.code == 12)
                            {
                                Program.Username = textBox1.Text;
                                Program.JwtToken = response.msg;
                                GetPhone();
                                Program.UserType = "admin";
                                NotiLabel.Text = "Login Succeed";
                                Form f = new Main();
                                f.Show();
                                this.ShowInTaskbar = false;
                                this.Visible = false;
                                Console.WriteLine(Program.phone);
                            }
                            else if (result == "13")
                            {
                                MessageBox.Show("Tài Khoản Đã Bị Khoá");
                            }

                            else
                            {
                                NotiLabel.Text = "No User Found";
                            }
                            NotiLabel.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (IsLogin == false && IsEmailValid && IsIdValid && IsEmailRegex)
            {

                if (textBox1.Text == "" || textBox2.Text == "" || CrmPass.Text == "" || textBox3.Text == "")
                    NotiLabel.Text = "Vui Lòng Điền Hết Thông Tin ";
                else
                {
                    try
                    {
                        //    Console.WriteLine("this is emaill " + IsEmailValid);
                        //    Console.WriteLine("this is id " + IsIdValid);
                        string Type = "USER";
                        string register = "{\"id\":\"" + Program.Username + "\",\"Pass\":\"" + Password + "\",\"Type\":\"" + Type + "\",\"Email\":\"" + Email + "\",  \"Phone\":\"" + "" + "\"}";

                        var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIRegister);
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            string json = register;
                            Console.WriteLine(json);
                            streamWriter.Write(json);
                        }
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            string result = streamReader.ReadToEnd();
                            var response = JsonSerializer.Deserialize<Response>(result);
                            if (response.code == 1)
                            {
                                MessageBox.Show("Tạo User Thành Công");

                            }
                            else if (response.code == 0)
                            {
                                MessageBox.Show(response.msg);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
            /*  else if (!IsEmailRegex && IsLogin == false)
              {
                  NotiLabel.Text = "Invalid Email Address!";
              } */
            else NotiLabel.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {

            Program.tempCart = new TempCart();
            Program.tempCart.items = new List<CartItem>();

            // Console.WriteLine("reloaddddddddddddddd");
            textBox2.UseSystemPasswordChar = true;
            CrmPass.UseSystemPasswordChar = true;
            NotiLabel.Text = "";
            NotiLabel2.Text = "";

            //login mode disable register mode

            RePassLabel.Visible = false;
            CrmPass.Visible = false;
            textBox3.Visible = false;
            label4.Text = "";

            textBox1.Text = "admin";
            textBox2.Text = "123";

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
                NotiLabel2.Text = "";
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
                //SendBtn.Visible = false;
                SwitchBtn.Text = "Login";
                NotiLabel.Text = "";
                NotiLabel2.Text = "";

                label4.Text = "Email";
            }
            //   Console.WriteLine(IsLogin);
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
