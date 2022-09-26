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

namespace ShopApp.Frm.UserFrm
{
    public partial class Shop : DevExpress.XtraEditors.XtraForm
    {
        public Shop()
        {
            InitializeComponent();
        }
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
            public event PropertyChangedEventHandler PropertyChanged;
            public PictureObject(string id, string brand, double price, int remain, string url)
            {
                this.id = id;
                this.brand = brand;
                this.price = price;
                this.remain = remain;
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

        private void gridControl1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Console.WriteLine("2");
            string ID = gridView1.GetFocusedRowCellValue("id").ToString();
            e1.Text = ID;

        }



        private void Shop_Load(object sender, EventArgs e)
        {
            /*      string sHTML = "<!DOCTYPE html>" +
        "<head>" +
        "</head>" +
        "<body>" +
         "<iframe width = \"650\" height = \"250\" src = \"https://www.youtube.com/embed/a9zGjl1YLh8\" ></iframe>" +
        "</body>" +
        "</html>";
                  await webView21.EnsureCoreWebView2Async();
                  webView21.NavigateToString(sHTML); */
            gridView1.RowHeight = 50;
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/getitems");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();

                var ItemsList = JsonSerializer.Deserialize<List<Items>>(result);
                /*  BindingSource binding = new BindingSource();
                  binding.DataSource = ItemsList;
                  gridControl1.DataSource = binding; */
                BindingList<PictureObject> list = new BindingList<PictureObject>();
                foreach (var item in ItemsList)
                {
                    list.Add(new PictureObject(item.id, item.brand, item.price, item.remain, item.image));

                }

                gridControl1.DataSource = list;
                gridView1.OptionsBehavior.Editable = false;
                e4.Value = 1;

            }


        }



        private async void gridControl1_Click(object sender, EventArgs e)
        {

            ID = gridView1.GetFocusedRowCellValue("id").ToString();
            string Brand = gridView1.GetFocusedRowCellValue("brand").ToString();

            money = Convert.ToDouble(gridView1.GetFocusedRowCellValue("price").ToString());
            //   string Price = money.ToString(@"#\.###\.###\.##0");
            string Price = string.Format("{0:#,##0.00}", money);

            Price += " vnđ";


            e1.Text = ID;
            e2.Text = Brand;
            e3.Text = Price;
            e5.Text = Price;
            string sHTML = "<!DOCTYPE html>" +
"<head>" +
"</head>" +
"<body>" +
"<iframe width = \"650\" height = \"250\" src = \"https://www.youtube.com/embed/a9zGjl1YLh8\" ></iframe>" +
"</body>" +
"</html>";
            await webView21.EnsureCoreWebView2Async();
            webView21.NavigateToString(sHTML);

        }



        private void e4_EditValueChanged(object sender, EventArgs e)
        {

        }


        private void e1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void e4_EditValueChanged_1(object sender, EventArgs e)
        {
            amount = Convert.ToInt32(e4.Value);
            e5.Text = (amount * money).ToString(@"#\.###\.###\.##0");
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(ID);
            Console.WriteLine(amount);
            Console.WriteLine(money);
        }
    }
}