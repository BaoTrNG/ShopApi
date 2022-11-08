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

namespace ShopApp.Frm.AdminFrm
{
    public partial class AdminUser : DevExpress.XtraEditors.XtraForm
    {
        public AdminUser()
        {
            InitializeComponent();
            Updatebtn.Visible = false;
            Deletebtn.Visible = false;
            Editbtn.Visible = false;
            StatusBox.Enabled = false;
        }
        public string id;
        public string pass;
        public string type;
        public string status;
        public string email;
        public int code;
        private void LoadPage()
        {
            try
            {
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/getalluser");
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIGetUsers);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                    var _Users = JsonSerializer.Deserialize<List<User>>(result);

                    gridControl1.DataSource = _Users;

                }
                gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void AdminUserLoad(object sender, EventArgs e)
        {
            LoadPage();
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {
            id = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "id").ToString();
            pass = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "pass").ToString();
            type = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "type").ToString();
            status = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "status").ToString();
            email = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "email").ToString();

            IDbox.Text = id;
            PassBox.Text = pass;
            StatusBox.SelectedIndex = StatusBox.FindStringExact(status);
            Emailbox.Text = email;

            Deletebtn.Visible = true;
            Editbtn.Visible = true;
            Updatebtn.Visible = false;
            disablevalue();
        }
        void enablevalue()
        {
            PassBox.Properties.ReadOnly = false;
            StatusBox.Enabled = true;
            Emailbox.Properties.ReadOnly = false;
        }
        void disablevalue()
        {
            PassBox.Properties.ReadOnly = true;
            StatusBox.Enabled = false;
            Emailbox.Properties.ReadOnly = true;
        }
        private void Editbtn_Click(object sender, EventArgs e)
        {
            code = 1;
            Updatebtn.Visible = true;
            enablevalue();
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {

            if (status == "banned")
            {
                MessageBox.Show("user đã bị khoá");
            }
            else
            {
                code = 2;
                Updatebtn.Visible = true;
                status = "banned";
                StatusBox.SelectedIndex = StatusBox.FindStringExact(status);
            }
        }
        private void UpdateUser()
        {
            User user = new User();
            user.id = id;
            user.pass = pass;
            user.type = type;
            user.status = status;
            user.email = email;
            user.phone = null;
            string json = JsonSerializer.Serialize(user);
            Console.WriteLine(json);
            try
            {
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/updateuseradmin");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIUpdateUserAdmin);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    var response = JsonSerializer.Deserialize<Response>(result);
                    if (response.code == 1)
                    {
                        MessageBox.Show("Update Thành Công");
                    }

                    else if (response.code == 0)
                    {
                        MessageBox.Show("Update Thất Bại" + "\n" + response.msg);
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
                Console.WriteLine("edit");
                UpdateUser();
            }
            else if (code == 2)
            {
                Console.WriteLine("Delete");
                UpdateUser();
            }

            Updatebtn.Visible = false;
            Deletebtn.Visible = false;
            Editbtn.Visible = false;
            disablevalue();
            LoadPage();
        }

        private void StatusBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = StatusBox.SelectedItem.ToString();
        }

        private void PassBox_EditValueChanged(object sender, EventArgs e)
        {
            pass = PassBox.Text;
        }

        private void Emailbox_EditValueChanged(object sender, EventArgs e)
        {
            email = Emailbox.Text;
        }
    }
}