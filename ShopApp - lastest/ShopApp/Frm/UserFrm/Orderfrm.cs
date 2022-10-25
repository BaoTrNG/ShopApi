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
    public partial class Orderfrm : DevExpress.XtraEditors.XtraForm
    {
        public Orderfrm()
        {
            InitializeComponent();
            gridView1.OptionsBehavior.Editable = false;

            this.PhoneBox.Properties.Mask.EditMask = "[0-9]+\\d*";
            this.PhoneBox.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            NotiLabel.Text = "";
            PaymentBox.Enabled = false;

            Updatebtn.Visible = false;
            CancelOrderbtn.Visible = false;
            EditOrderbtn.Visible = false;


        }
        private string id;
        private bool IsPhoneValid;
        private string phone;
        private string address;
        private string status;
        private string payment;
        private double total;
        private string date;
        private bool IsUpdateValid;
        private void GetOrder()
        {
            try
            {
                string json = "{\"buyer\":\"" + Program.Username + "\"}";
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/findorder");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    var _Order = JsonSerializer.Deserialize<List<Order>>(result);

                    //   Console.WriteLine(result);
                    Program.tempOrder = _Order;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ReloadOrderFrm()
        {
            GetOrder();
            Program.tempOrder.OrderBy(p => p.status);
            gridControl1.DataSource = Program.tempOrder;

            gridView1.OptionsBehavior.Editable = false;
        }
        private void Order_Load(object sender, EventArgs e)
        {
            Program.tempOrder.OrderBy(p => p.status);
            gridControl1.DataSource = Program.tempOrder;

            gridView1.OptionsBehavior.Editable = false;
            //  gridView1.Columns["admins"].Visible = false;

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            id = gridView1.GetFocusedRowCellValue("id").ToString();
            Updatebtn.Visible = false;
            PaymentBox.Enabled = false;
            AddressBox.ReadOnly = true;
            PhoneBox.ReadOnly = true;

            //MessageBox.Show("Clicked");
            string ID = gridView1.GetFocusedRowCellValue("id").ToString();
            Statusbox.Text = gridView1.GetFocusedRowCellValue("status").ToString();
            PaymentBox.Text = gridView1.GetFocusedRowCellValue("payment").ToString();
            PhoneBox.Text = gridView1.GetFocusedRowCellValue("phone").ToString();
            AddressBox.Text = gridView1.GetFocusedRowCellValue("address").ToString();
            if (Statusbox.Text == "canceled" || Statusbox.Text == "delivering" || Statusbox.Text == "done")
            {


                CancelOrderbtn.Visible = false;
                Updatebtn.Visible = false;
                EditOrderbtn.Visible = false;
            }
            else
            {
                CancelOrderbtn.Visible = true;
                //Updatebtn.Visible = true;
                EditOrderbtn.Visible = true;
            }

            phone = PhoneBox.Text;
            address = AddressBox.Text;
            status = Statusbox.Text;
            payment = PaymentBox.Text;
            date = gridView1.GetFocusedRowCellValue("date").ToString();
            total = Convert.ToDouble(gridView1.GetFocusedRowCellValue("total").ToString());


        }

        private void PaymentBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            payment = PaymentBox.Text;
        }

        private void AddressBox_TextChanged(object sender, EventArgs e)
        {
            address = AddressBox.Text;
        }

        private void PhoneBox_EditValueChanged(object sender, EventArgs e)
        {
            if (PhoneBox.Text.Count() != 0)
            {

                if (PhoneBox.Text[0] != '0')
                {
                    NotiLabel.Text = "Sai Đầu Số Điện Thoại";
                    IsPhoneValid = false;
                }
                else if (PhoneBox.Text.Count() < 10)
                {
                    NotiLabel.Text = "Số Điện Thoại Không Hợp Lệ";
                    IsPhoneValid = false;
                }
                else
                {
                    IsPhoneValid = true;
                    phone = PhoneBox.Text;
                    NotiLabel.Text = "";
                }
            }
        }
        private void UpdateOrder()
        {
            try
            {
                Console.WriteLine("update");
                Order temp = new Order(Program.Username);
                temp.address = address;
                temp.phone = phone;
                temp.status = status;
                temp.payment = payment;
                temp.total = total;
                temp.date = date;
                temp.id = gridView1.GetFocusedRowCellValue("id").ToString();
                temp.items = Program.tempOrder.Where(p => p.id == temp.id).FirstOrDefault().items;
                temp.admins = Program.tempOrder.Where(p => p.id == temp.id).FirstOrDefault().admins;
                string json = JsonSerializer.Serialize(temp);
                Console.WriteLine(json);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/updateorder");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    //  Console.WriteLine(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                int b = (int)httpResponse.StatusCode;
                // MessageBox.Show("Đang Thực Hiện");
                if (b == 200)
                {
                    ReloadOrderFrm();
                    MessageBox.Show("Thành Công");

                }
                else
                {
                    MessageBox.Show("fail");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckOrderStatus()
        {
            try
            {
                string url = "https://shopapiptithcm.azurewebsites.net/api/getorderstatus/" + id;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                int b = (int)httpResponse.StatusCode;
                // MessageBox.Show("Đang Thực Hiện");
                if (b == 200)
                {
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        string result = streamReader.ReadToEnd();
                        if (result == "0")
                        {
                            IsUpdateValid = false;
                            MessageBox.Show("Đơn Hàng Đã Được Cập Nhật");
                            ReloadOrderFrm();
                        }
                        else
                        {
                            IsUpdateValid = true;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("fail");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (address == null)
            {
                MessageBox.Show("Vui Lòng Điền Địa Chỉ");
            }
            else if (phone == null)
            {
                MessageBox.Show("Vui Lòng Điền Số Điện Thoại");
            }
            else if (!IsPhoneValid)
            {
                MessageBox.Show("Số Điện Thoại Không Hợp Lệ");
            }
            else
            {
                CheckOrderStatus();
                if (IsUpdateValid)
                {
                    UpdateOrder();
                    ReloadOrderFrm();
                    Updatebtn.Visible = false;
                }
                else
                {
                    ReloadOrderFrm();
                }
            }
        }



        private void EditOrderbtn_Click(object sender, EventArgs e)
        {
            if (status == "canceled")
            {
                MessageBox.Show("Đơn Hàng Đã Bị Huỷ");

                /* PaymentBox.Enabled = false;
                 AddressBox.ReadOnly = true;
                 PhoneBox.ReadOnly = true; */
            }
            else if (status == "delivering")
            {
                MessageBox.Show("Đơn Hàng Đang Được Vận Chuyển");

                /* PaymentBox.Enabled = false;
                 AddressBox.ReadOnly = true;
                 PhoneBox.ReadOnly = true; */
            }
            else if (status == "done")
            {
                MessageBox.Show("Đơn Hàng Đã Hoàn Thành");

                /* PaymentBox.Enabled = false;
                 AddressBox.ReadOnly = true;
                 PhoneBox.ReadOnly = true; */
            }
            else
            {
                Updatebtn.Visible = true;
                PaymentBox.Enabled = true;
                AddressBox.ReadOnly = false;
                PhoneBox.ReadOnly = false;
            }
        }

        private void CancelOrderbtn_Click(object sender, EventArgs e)
        {
            status = "canceled";
            Statusbox.Text = status;
            EditOrderbtn.Visible = false;
            PhoneBox.ReadOnly = true;
            AddressBox.ReadOnly = true;
        }
    }
}