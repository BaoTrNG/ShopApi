﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO; //Stream writer, reader 
using System.Net; //WebClient
using System.Text.Json;
using System.Text.Json.Nodes;

using ShopApp.Model_Class;

using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;
using System.Text.RegularExpressions;


namespace ShopApp.Frm.UserFrm
{
    public partial class Cartfrm : DevExpress.XtraEditors.XtraForm
    {
        private Order order;


        public Cartfrm()
        {
            InitializeComponent();
            Updatebtn.Visible = false;
            Delbtn.Visible = false;
            gridView1.OptionsBehavior.Editable = false;
            order = new Order(Program.tempCart.id);
            this.PhoneEdit.Properties.Mask.EditMask = "[0-9]+\\d*";
            this.PhoneEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            NotiLabel.Text = "";

        }
        private string ID;
        private int amount;
        private double money;
        private double Oldmoney;
        private string address;
        private string phone;
        private string payment;
        private string temp;
        private void LoadPage()
        {
            Console.WriteLine("load page ");

            Totaltext.Text = Program.tempCart.total.ToString();
            try
            {
                //   gridView1.RowHeight = 50;
                string Buyer = "{\"id\":\"" + Program.Username + "\"}";
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/findcart");
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIFindCart);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = Buyer;
                    Console.WriteLine(json);
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    var Cart = JsonSerializer.Deserialize<TempCart>(result);
                    Program.tempCart = Cart;
                    if (Cart.id != "0")
                    {
                        Console.WriteLine("load cart");
                        BindingSource bs = new BindingSource();
                        bs.DataSource = Cart.items;
                        gridControl1.DataSource = bs;
                    }
                    Console.WriteLine("NO cart");
                }
                gridView1.OptionsBehavior.Editable = false;
                Program.isload = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            e4.Value = 0;
            Updatebtn.Visible = true;
            Delbtn.Visible = true;
            ID = gridView1.GetFocusedRowCellValue("id").ToString();
            money = Convert.ToDouble(gridView1.GetFocusedRowCellValue("price").ToString());
            //   string Price = money.ToString(@"#\.###\.###\.##0");
            string Price = string.Format("{0:#,##0.00}", money);

            Price += " vnđ";


            e1.Text = ID;
            int amount = Convert.ToInt32(gridView1.GetFocusedRowCellValue("amount").ToString());
            e4.Value = amount;
            e4.Properties.MaxValue = amount;
            //e4.Properties.MinValue = 1;
            e5.Text = Price;

        }

        private void ReloadPage()
        {
            Console.WriteLine("reload");
            comboBox1.SelectedIndex = 0;
            comboBox1.Text = "COD";

            BindingSource bs = new BindingSource();
            bs.DataSource = Program.tempCart.items;
            gridControl1.DataSource = bs;
            Totaltext.Text = Program.tempCart.total.ToString();


        }
        private void Cartfrm_Load(object sender, EventArgs e)
        {
            ReloadPage();
            //  else MessageBox.Show("chưa có sản phẩm");
        }

        private void e4_EditValueChanged(object sender, EventArgs e)
        {
            int Oldamount = Convert.ToInt32(gridView1.GetFocusedRowCellValue("amount").ToString());
            amount = Convert.ToInt32(e4.Value);
            Oldmoney = money / Oldamount;
            string temp = string.Format("{0:#,##0.00}", Oldmoney * amount) + " vnđ";
            e5.Text = temp;//(amount * money).ToString(@"#\.###\.###\.##0");
        }

        private void UpdateTotal()
        {
            Program.tempCart.total = 0; //prevent stack value
            foreach (var item in Program.tempCart.items)
            {
                // Console.WriteLine(item.price + "  " + item.amount);
                Program.tempCart.total += item.price;
            }
        }

        private void UpdateTempCart()
        {
            try
            {
                string json = JsonSerializer.Serialize(Program.tempCart);
                // var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/updatecart");
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIUpdateCart);
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
                    Console.WriteLine("this is check" + result);

                    if (response.code == 1)
                    {
                        MessageBox.Show("Sửa Thành Công");
                    }
                    else if (response.code == 0)
                    {
                        MessageBox.Show("Sửa Thất Bại");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("this is UpdateTempCart  " + e.Message);
            }
        }

        private void UpdateTempCartForBuybtn()
        {
            try
            {
                string json = JsonSerializer.Serialize(Program.tempCart);
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/updatecart");
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIUpdateCart);
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
                    Console.WriteLine("this is check" + result);

                    if (response.code == 1)
                    {
                        MessageBox.Show("Sửa Thành Công");
                    }
                    else if (response.code == 0)
                    {
                        MessageBox.Show("Sửa Thất Bại");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("this is UpdateTempCartForBuybtn " + e.Message);
            }
        }
        private void Updatebtn_Click(object sender, EventArgs e)
        {
            foreach (var item in Program.tempCart.items)
            {
                if (item.id == ID)
                {
                    item.amount = amount;
                    item.price = Oldmoney * amount;
                    break;
                }
            }
            UpdateTotal();
            UpdateTempCart();
            ReloadPage();
            foreach (var item in Program.tempCart.items)
            {
                Console.WriteLine(item.id + " " + item.amount);
            }
            Console.WriteLine("total: " + Program.tempCart.total);
        }

        private void Delbtn_Click(object sender, EventArgs e)
        {
            Program.tempCart.items.RemoveAll(x => x.id == ID);
            UpdateTotal();
            UpdateTempCart();
            ReloadPage();
            foreach (var item in Program.tempCart.items)
            {
                Console.WriteLine(item.id + " " + item.amount);
            }
            Console.WriteLine("total: " + Program.tempCart.total);
        }

        private void UpdateCart()
        {

        }
        string notify;
        private void Order()
        {
            try
            {
                DateTime dateTime = DateTime.Now;
                order.date = dateTime.ToString("dd-MM-yyyy HH:mm:ss"); // for 24hr format
                order.payment = payment;
                order.address = address;
                order.phone = phone;
                order.items = Program.tempCart.items;
                order.total = Program.tempCart.total;
                var json = JsonSerializer.Serialize(order);
                Console.WriteLine(json);
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/createp")
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APICreateOrder);
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
                    Response res = JsonSerializer.Deserialize<Response>(result);
                    if (res.code == 1)
                    {
                        MessageBox.Show("Đặt Hàng Thành Công");
                        Program.tempCart.items = new List<CartItem>();
                        Program.tempCart.total = 0;
                        UpdateTempCart();
                    }
                    else if (res.code == 0)
                    {
                        string msg = " Đặt hàng thất bại";
                        MessageBox.Show(msg + "\n" + res.msg);
                    }

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CheckItemsAndOrder()
        {
            Console.WriteLine("3 " + address);
            try
            {
                var json = JsonSerializer.Serialize(Program.tempCart.items);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/checkitemv2");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    Console.WriteLine(json);
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {

                    string result = streamReader.ReadToEnd();


                    var ItemsList = JsonSerializer.Deserialize<List<CartItem>>(result);
                    //   Console.WriteLine("this is count" + ItemsList.Count);
                    if (ItemsList.Count == 0)
                    {
                        Order();
                    }
                    else //Loại bỏ các sản phẩm đã bị hết hàng khỏi giỏ hàng
                    {
                        foreach (var item in ItemsList)
                        {
                            Program.tempCart.items.RemoveAll(x => x.id == item.id);
                            notify += item.id + " ";
                        }
                        MessageBox.Show("Các sản phẩm đã hết hàng:  " + notify + "\nLoại Bỏ Các Sản Phẩm Hết Hàng Khỏi Giỏ");

                        UpdateTotal();
                        UpdateTempCartForBuybtn(); // update khi xoá item khỏi giỏ hàng                                               
                        ReloadPage();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("this is CheckItemsAndOrder " + e.Message);
            }

        }

        private void CheckItemsAndOrdertest()
        {
            try
            {
                var json = JsonSerializer.Serialize(Program.tempCart.items);
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/checkitemv2");
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APICheckItem);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    Console.WriteLine(json);
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {

                    string result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                    var res = JsonSerializer.Deserialize<ResponseItems>(result);

                    //var ItemsList = JsonSerializer.Deserialize<List<CartItem>>(result);
                    if (res.code == "ok")
                    {
                        Console.WriteLine("ok");
                        Order();
                        //     UpdateTotal();
                        //   UpdateTempCartForBuybtn();

                        ReloadPage();
                    }
                    else if (res.code == "error")
                    {
                        Console.WriteLine("error");
                        foreach (var id in res.id)
                        {
                            Program.tempCart.items.RemoveAll(x => x.id == id);
                            notify += id + " ";
                        }
                        MessageBox.Show("Các sản phẩm đã hết hàng:  " + notify + "\nLoại Bỏ Các Sản Phẩm Hết Hàng Khỏi Giỏ");

                        UpdateTotal();
                        UpdateTempCartForBuybtn(); // update khi xoá item khỏi giỏ hàng
                        ReloadPage();
                    }
                    else if (res.code == "null")
                    {
                        Console.WriteLine("null");
                        foreach (var id in res.id)
                        {
                            Program.tempCart.items.RemoveAll(x => x.id == id);
                            notify += id + " ";
                        }
                        MessageBox.Show("Các sản phẩm Không Tồn Tại:  " + notify + "\nLoại Bỏ Các Sản Phẩm Hết Hàng Khỏi Giỏ");

                        UpdateTotal();
                        UpdateTempCartForBuybtn(); // update khi xoá item khỏi giỏ hàng
                        ReloadPage();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("this is CheckItemsAndOrder " + e.Message);
            }

        }

        private void Orderbtn_Click(object sender, EventArgs e)
        {
            Console.WriteLine("1 " + address);
            //  bool isValid = CheckItems().Result;
            if (Program.tempCart.items.Count != 0)
            {
                if (payment == null)
                {
                    MessageBox.Show("Vui Lòng Chọn Phương Thức Thanh Toán");
                }
                else if (address == null)
                {
                    MessageBox.Show("Vui Lòng Điền Địa Chỉ");
                }
                else if (phone == null)
                {
                    MessageBox.Show("Vui Lòng Điền Số Điện Thoại");
                }
                else
                {
                    Console.WriteLine("2 " + address);
                    CheckItemsAndOrdertest();
                    PhoneEdit.Text = "";
                    Addressedit.Text = "";
                }
            }
            else MessageBox.Show("Giỏ Hàng Trống");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            payment = comboBox1.Text;
        }

        private void Addressedit_TextChanged(object sender, EventArgs e)
        {
            address = Addressedit.Text;
            temp = address;
            //Console.WriteLine(address);
        }





        private void PhoneEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (PhoneEdit.Text.Count() != 0)
            {

                if (PhoneEdit.Text[0] != '0')
                {
                    NotiLabel.Text = "Sai Đầu Số Điện Thoại";
                }
                else if (PhoneEdit.Text.Count() < 10)
                {
                    NotiLabel.Text = "Số Điện Thoại Không Hợp Lệ";
                }
                else
                {
                    phone = PhoneEdit.Text;
                    NotiLabel.Text = "";
                }
            }

        }


    }
}
