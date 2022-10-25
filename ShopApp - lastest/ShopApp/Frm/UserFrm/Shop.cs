using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO; //Stream writer, reader 
using System.Net; //WebClient
using System.Text.Json;
using ShopApp.Model_Class;

using System.Windows.Forms;

using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;


using DevExpress.XtraSplashScreen;

namespace ShopApp.Frm.UserFrm
{
    public partial class Shop : DevExpress.XtraEditors.XtraForm
    {
        public Shop()
        {
            InitializeComponent();


        }
        CartModel cart = new CartModel();

        private string ID;
        private int amount;
        private double money;
        public class PictureObject : INotifyPropertyChanged
        {
            public string id { get; set; }
            public string brand { get; set; }
            public double price { get; set; }
            public int remain { get; set; }
            public Image Image { get; set; }
            public string linkvid { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
            public PictureObject(string id, string brand, double price, int remain, string url, string linkvid)
            {
                this.id = id;
                this.brand = brand;
                this.price = price;
                this.remain = remain;
                this.linkvid = linkvid;
                //    Image = ResourceImageHelper.CreateImageFromResources("DevExpress.XtraEditors.Images.loading.gif", typeof(BackgroundImageLoader).Assembly);
                BackgroundImageLoader bg = new BackgroundImageLoader();
                bg.Load(url);
                bg.Loaded += (s, e) =>
                {
                    Image = bg.Result;
                    if (!(Image is Image)) Image = ResourceImageHelper.CreateImageFromResources("DevExpress.XtraEditors.Images.Error.png", typeof(BackgroundImageLoader).Assembly);
                    PropertyChanged(this, new PropertyChangedEventArgs("Image"));
                    bg.Dispose();
                };
            }
        }

        /*  private void gridControl1_CellClick(object sender, DataGridViewCellEventArgs e)
          {
              Console.WriteLine("2");
              string ID = gridView1.GetFocusedRowCellValue("id").ToString();
              e1.Text = ID;

          }*/

        private void LoadPage()
        {
            try
            {
                cart.buyer = Program.Username;
                cart.date = DateTime.Now.ToString("dd/MM/yyyy");
                cart.status = "pending";

                gridView1.RowHeight = 50;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/getitems");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    var ItemsList = JsonSerializer.Deserialize<List<Items>>(result);

                    BindingList<PictureObject> list = new BindingList<PictureObject>();
                    foreach (var item in ItemsList)
                    {
                        list.Add(new PictureObject(item.id, item.brand, item.price, item.remain, item.image, item.url));

                    }

                    gridControl1.DataSource = list;
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.Columns["linkvid"].Visible = false;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadCart()
        {
            try
            {
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
                    if (Cart.items != null)
                    {
                        Console.WriteLine("have cart");
                        Program.tempCart = Cart;

                    }
                    else
                    {
                        Console.WriteLine("no cart");
                        Program.isload = true;
                        Program.tempCart = new TempCart();
                        Program.tempCart.id = Program.Username;
                        Program.tempCart.items = new List<CartItem>();

                        Program.testCart = Program.tempCart;
                        //  CreateTempCart();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Shop_Load(object sender, EventArgs e)
        {

            LoadCart();
            LoadPage();
            Program.isdoneload = true;
        }


        private async void gridControl1_Click(object sender, EventArgs e)
        {

            e4.Value = 0;
            Buybtn.Visible = true;
            ID = gridView1.GetFocusedRowCellValue("id").ToString();
            string Brand = gridView1.GetFocusedRowCellValue("brand").ToString();
            string url = gridView1.GetFocusedRowCellValue("linkvid").ToString();
            money = Convert.ToDouble(gridView1.GetFocusedRowCellValue("price").ToString());
            //   string Price = money.ToString(@"#\.###\.###\.##0");
            string Price = string.Format("{0:#,##0.00}", money);

            Price += " vnđ";


            e1.Text = ID;
            e2.Text = Brand;
            e3.Text = Price;
            e5.Text = Price;

            string sHTML = "<!DOCTYPE html>" + "<head>" + "</head>" +
"<body>" +
"<iframe width = \"615\" height = \"245\" src =  " + url + "></iframe> " +
"</body>" +
"</html>";
            await webView21.EnsureCoreWebView2Async();
            webView21.NavigateToString(sHTML);






        }

        private void e4_EditValueChanged_1(object sender, EventArgs e)
        {
            amount = Convert.ToInt32(e4.Value);
            string temp = string.Format("{0:#,##0.00}", money * amount) + " vnđ";
            e5.Text = temp;//(amount * money).ToString(@"#\.###\.###\.##0");
        }


        private void AddItem(CartItem tempItem)
        {
            //check duplicate

            foreach (var item in Program.tempCart.items)
            {
                if (item.id == tempItem.id)
                {
                    //       Console.WriteLine("duplicate");
                    item.amount += tempItem.amount;
                    item.price += tempItem.amount * tempItem.price;
                    return;
                }

            }



            //Program.tempCart.buyer = Program.Username;
            //  Console.WriteLine("no dup");
            tempItem.price = tempItem.amount * tempItem.price;
            Program.tempCart.items.Add(tempItem);

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

        private string CheckRemain(string id, int remain)
        {
            try
            {
                // Console.WriteLine("test");
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/checkremain" + "/" + id + "/" + remain);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Console.WriteLine("this is check" + result);
                    return result;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return "3";
            }
        }


        private void UpdateTempCart()
        {
            try
            {
                string json = JsonSerializer.Serialize(Program.tempCart);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/updatecart");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                    Console.WriteLine(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    var response = JsonSerializer.Deserialize<Response>(result);
                    Console.WriteLine("this is check" + result);

                    if (response.code == 1)
                    {
                        MessageBox.Show("Thêm Thành Công");
                    }
                    else if (response.code == 0)
                    {
                        MessageBox.Show("Thêm Thất Bại");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }


        private void Buybtn_Click(object sender, EventArgs e)
        {
            if (e4.Value == 0)
            {

                MessageBox.Show("Số Lượng Phải Lớn Hơn 0");
            }
            else
            {
                string result = CheckRemain(ID, amount);
                if (result == "1")
                {

                    e4.Value = 0; //reset spinedit
                                  //   money = amount * money;
                    CartItem temp = new CartItem(ID, amount, money);

                    AddItem(temp);
                    UpdateTotal();
                    UpdateTempCart();
                    temp = null; //free memory
                    LoadPage();
                }
                else if (result == "2")
                {
                    MessageBox.Show("Sản Phẩm Không Đủ Hàng");
                    LoadPage();
                }
                else if (result == "0")
                {
                    MessageBox.Show("Sản Phẩm Không Tồn Tại");
                    LoadPage();
                }
                else if (result == "3")
                {
                    MessageBox.Show("Lỗi Ngoại Lệ");
                    LoadPage();
                }


            }

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
