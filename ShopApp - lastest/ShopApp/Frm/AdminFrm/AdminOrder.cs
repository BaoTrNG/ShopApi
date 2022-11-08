using DevExpress.XtraEditors;
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
using ShopApp.Model_Class;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;


namespace ShopApp.Frm.AdminFrm
{
    public partial class AdminOrder : DevExpress.XtraEditors.XtraForm
    {
        public AdminOrder()
        {
            InitializeComponent();

            Updatebtn.Visible = false;
            Deletebtn.Visible = false;
            EditOrderbtn.Visible = false;
            PaymentBox.Enabled = false;


        }
        private string id;
        private string phone;
        private string address;
        private string status;
        private string payment;
        private double total;
        private string date;

        // private List<CartItem> items;
        private List<Order> orders;
        private List<Admin> Tempadmin;

        private int code;
        void gridControl1_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            GridView view = (GridView)e.View;
            //view.Columns["admins"].Visible = false;
            //view.Columns["items"].Visible = false;

        }
        private void GetOrder()
        {
            try
            {
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/getorder");
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIGetOrders);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    var _Order = JsonSerializer.Deserialize<List<Order>>(result);
                    orders = _Order;
                    gridControl1.DataSource = _Order;

                }
                gridView1.OptionsBehavior.Editable = false;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            Statusbox.Enabled = false;
            Updatebtn.Visible = false;
            id = gridView1.GetFocusedRowCellValue("id").ToString();


            string ID = gridView1.GetFocusedRowCellValue("id").ToString();
            string status = gridView1.GetFocusedRowCellValue("status").ToString();
            Statusbox.SelectedIndex = Statusbox.FindStringExact(status);
            // Console.WriteLine(gridView1.GetFocusedRowCellValue("status").ToString());
            PaymentBox.Text = gridView1.GetFocusedRowCellValue("payment").ToString();
            PhoneBox.Text = gridView1.GetFocusedRowCellValue("phone").ToString();
            AddressBox.Text = gridView1.GetFocusedRowCellValue("address").ToString();

            if (status == "done" || status == "delivering" || status == "canceled")
            {

                EditOrderbtn.Visible = false;
                Deletebtn.Visible = false;

            }
            else
            {

                EditOrderbtn.Visible = true;
                Deletebtn.Visible = true;

            }

            Deletebtn.Visible = false;
        }
        private void LoadPage()
        {
            GetOrder();

        }

        private void OrderLoad(object sender, EventArgs e)
        {
            LoadPage();
            //Console.WriteLine("load page");

        }


        private void DeleteOrder()
        {

            string json = "{ \"id\":\"" + id + "\"}";
            try
            {


                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/deleteorderadmin");
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
                        MessageBox.Show("Xoá Thành Công");
                    }
                    else if (response.code == 3)
                    {
                        MessageBox.Show("đơn hàng không tồn tại");
                    }
                    else if (response.code == 0)
                    {
                        MessageBox.Show("Xoá Thất Bại");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void UpdateOrder()
        {
            Order temp = orders.Find(x => x.id == id);
            temp.status = status;
            if (temp.admins != null)
            {
                Console.WriteLine("admin is not null");
                Console.WriteLine("this is program " + Program.Username);
                Console.WriteLine("exist more than 1");
                bool exist = false;
                foreach (var admin in temp.admins)
                {
                    Console.WriteLine(admin.id + "  " + Program.Username);

                    if (admin.id == Program.Username)
                    {
                        exist = true;
                        break;
                    }
                }
                if (!exist)
                {
                    Console.WriteLine("add 1 to the list");
                    Admin tempad = new Admin();
                    tempad.id = Program.Username;
                    tempad.phone = Program.phone;
                    temp.admins.Add(tempad);
                }
            }
            else
            {
                Console.WriteLine("only 1");
                Admin tempad = new Admin();
                tempad.id = Program.Username;
                tempad.phone = Program.phone;
                temp.admins = new List<Admin>();
                temp.admins.Add(tempad);
            }

            string json = JsonSerializer.Serialize(temp);
            Console.WriteLine(json);
            Console.WriteLine("this is json " + json);
            try
            {
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/updateorderadmin");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIUpdateOrderAdmin);
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
                        MessageBox.Show("thành công");
                    }
                    else if (response.code == 3)
                    {
                        MessageBox.Show("đơn hàng không tồn tại");
                    }
                    else if (response.code == 0)
                    {
                        MessageBox.Show("cập nhật thất bại");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void EditOrderbtn_Click(object sender, EventArgs e)
        {
            Statusbox.Enabled = true;
            Updatebtn.Visible = true;
            code = 1;
        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (code == 1)
            {
                UpdateOrder();
                LoadPage();
            }
            else if (code == 2)
            {
                Console.WriteLine("Hello");
                DeleteOrder();
                LoadPage();
            }
            Updatebtn.Visible = false;
            Deletebtn.Visible = false;
            EditOrderbtn.Visible = false;
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            Updatebtn.Visible = true;
            code = 2;
        }

        private void Statusbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            status = Statusbox.SelectedItem.ToString();
        }
    }
}