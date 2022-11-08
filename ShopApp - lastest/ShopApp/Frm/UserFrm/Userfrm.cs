using DevExpress.XtraEditors;
using ShopApp.Model_Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopApp.Frm.UserFrm
{
    public partial class Userfrm : DevExpress.XtraEditors.XtraForm
    {
        public Userfrm()
        {
            InitializeComponent();
            this.Phonebox.Properties.Mask.EditMask = "[0-9]+\\d*";
            this.Phonebox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
        }
        int code;
        string phone;
        string oldpass;
        string pass;
        string repass;
        bool ispass = false;
        bool isphone = false;
        void resetvalue()
        {
            OldPass.Visible = false;
            NewPass.Visible = false;
            ConfirmPass.Visible = false;
            Updatebtn.Visible = false;
            Phonebox.Visible = false;
            noti.Text = "";
        }
        void OrderFrm_Load(object sender, EventArgs e)
        {
            resetvalue();
            try
            {
                string Buyer = "{\"buyer\":\"" + Program.Username + "\"}";
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/userorders");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIUpdateUser);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = Buyer;
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Response res = JsonSerializer.Deserialize<Response>(result);

                    UserName.Text = "Tên Người Dùng " + Program.Username;
                    if (res.code != 0)
                    {
                        TotalOrder.Text = "Số Đơn Hàng Đã Giao Thành Công " + res.code.ToString();
                        string money = res.msg.Insert(2, ".");
                        TotalMoney.Text = "Số Tiền Đã Chi " + money + " VNĐ";
                    }
                    else
                    {
                        TotalOrder.Text = "Số Đơn Hàng Đã Giao Thành Công " + res.code.ToString();
                        TotalMoney.Text = "Số Tiền Đã Chi " + res.msg + " VNĐ";
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetvalue();
            Phonebox.Visible = true;
            Updatebtn.Visible = true;
            code = 1;
        }

        private void UpdatePhone()
        {
            try
            {
                string Buyer = "{\"id\":\"" + Program.Username + "\",\"phone\":\"" + phone + "\"}";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIUpdatePhone);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = Buyer;
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Response res = JsonSerializer.Deserialize<Response>(result);
                    if (res.code == 1)
                    {
                        MessageBox.Show("sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("sửa thất bại");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdatePass()
        {
            try
            {
                string Buyer = "{\"id\":\"" + Program.Username + "\",\"pass\":\"" + pass + "\"}";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIUpdatePass);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = Buyer;
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Response res = JsonSerializer.Deserialize<Response>(result);
                    if (res.code == 1)
                    {
                        MessageBox.Show("sửa thành công");
                    }
                    else
                    {
                        MessageBox.Show("sửa thất bại");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (code == 1)
            {
                UpdatePhone();
                resetvalue();
                Phonebox.Text = "";
            }
            else if (code == 0)
            {
                if (ispass && OldPass.Text.Count() != 0)
                {
                    //update
                    UpdatePass();
                    resetvalue();
                    OldPass.Text = "";
                    NewPass.Text = "";
                    ConfirmPass.Text = "";
                }
                else
                {
                    noti.Text = "Vui Lòng Điền Hết Thông Tin";
                }

            }
        }

        private void OldPass_TextChanged(object sender, EventArgs e)
        {
            oldpass = OldPass.Text;
        }

        private void NewPass_TextChanged(object sender, EventArgs e)
        {
            pass = NewPass.Text;
            if (pass != repass)
            {
                noti.Text = " Mật Khẩu Không Trùng";
            }
            else
            {
                noti.Text = "";
                ispass = true;
            }
        }

        private void ConfirmPass_TextChanged(object sender, EventArgs e)
        {
            repass = ConfirmPass.Text;
            if (pass != repass)
            {
                noti.Text = " Mật Khẩu Không Trùng";
            }
            else
            {
                noti.Text = "";
                ispass = true;
            }
        }

        private void Pass_Click(object sender, EventArgs e)
        {
            resetvalue();

            OldPass.Visible = true;
            NewPass.Visible = true;
            ConfirmPass.Visible = true;
            Updatebtn.Visible = true;
            code = 0;
        }

        private void Phonebox_EditValueChanged(object sender, EventArgs e)
        {
            if (Phonebox.Text.Count() != 0)
            {

                if (Phonebox.Text[0] != '0')
                {
                    noti.Text = "Sai Đầu Số Điện Thoại";
                }
                else if (Phonebox.Text.Count() < 10)
                {
                    noti.Text = "Số Điện Thoại Không Hợp Lệ";
                }
                else
                {
                    phone = Phonebox.Text;
                    noti.Text = "";
                }
            }
        }

        private void PassCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (PassCheck.Checked == true)
            {
                NewPass.UseSystemPasswordChar = false;
                ConfirmPass.UseSystemPasswordChar = false;
            }
            else
            {
                NewPass.UseSystemPasswordChar = false;
                ConfirmPass.UseSystemPasswordChar = false;
            }
        }

        private void OldPass_Click(object sender, EventArgs e)
        {
            OldPass.Text = "";
        }

        private void NewPass_Click(object sender, EventArgs e)
        {
            NewPass.Text = "";
        }

        private void ConfirmPass_Click(object sender, EventArgs e)
        {
            ConfirmPass.Text = "";
        }
    }
}