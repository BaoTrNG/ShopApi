using DevExpress.XtraEditors;
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
        }
        private string ID;
        private int amount;
        private double money;
        private double Oldmoney;
        private string address;
        private string payment;
        private void LoadPage()
        {
            Console.WriteLine("load page ");

            Totaltext.Text = Program.tempCart.total.ToString();

            //   gridView1.RowHeight = 50;
            string Buyer = "{\"id\":\"" + Program.Username + "\"}";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/findcart");
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

        private async void UpdateTempCart()
        {

            string json = JsonSerializer.Serialize(Program.tempCart);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/updatecart");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                //  Console.WriteLine(json);
            }
            var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
            int b = (int)httpResponse.StatusCode;
            // MessageBox.Show("Đang Thực Hiện");
            if (b == 200)
            {
                //   Program.testCart = Program.tempCart;
                //   Program.testCart.id = "te";
                //  CreateTempCart();

                MessageBox.Show("Thành Công");
            }
            else
            {
                MessageBox.Show("fail");
            }
        }

        private async void UpdateTempCartForBuybtn()
        {

            string json = JsonSerializer.Serialize(Program.tempCart);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/updatecart");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
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
        private async void Order()
        {
            DateTime dateTime = DateTime.Now;
            order.date = dateTime.ToString("dd-MM-yyyy HH:mm:ss"); // for 24hr format
            order.payment = payment;
            order.address = address;
            order.items = Program.tempCart.items;
            order.total = Program.tempCart.total;
            var json = JsonSerializer.Serialize(order);
            Console.WriteLine(json);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/createp");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
            int b = (int)httpResponse.StatusCode;
            if (b == 200)
            {
                MessageBox.Show("Thành Công");
                Program.tempCart.items.Clear();
                Program.tempCart.total = 0;
                ReloadPage();

            }
            else
            {
                MessageBox.Show("fail");
            }
        }

        private async void CheckItemsAndOrder()
        {

            var json = JsonSerializer.Serialize(Program.tempCart.items);
            Console.WriteLine(json);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/checkitem");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
            }
            var httpResponse = (HttpWebResponse)await httpWebRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {

                string result = streamReader.ReadToEnd();
                Console.WriteLine("doing 1");

                var ItemsList = JsonSerializer.Deserialize<List<CartItem>>(result);
                Console.WriteLine("this is count" + ItemsList.Count);
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
                    ReloadPage();
                    UpdateTotal();
                    UpdateTempCartForBuybtn();
                    //  return false;
                }
            }

        }
        private void Orderbtn_Click(object sender, EventArgs e)
        {

            //  bool isValid = CheckItems().Result;

            if (payment == null)
            {
                MessageBox.Show("Vui Lòng Chọn Phương Thức Thanh Toán");
            }
            else if (address == null)
            {
                MessageBox.Show("Vui Lòng Điền Địa Chỉ");
            }
            else
            {
                CheckItemsAndOrder();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            payment = comboBox1.Text;
        }

        private void Address_TextChanged(object sender, EventArgs e)
        {
            address = Addressedit.Text;
        }
    }
}
