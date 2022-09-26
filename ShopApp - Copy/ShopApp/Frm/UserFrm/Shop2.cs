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
using ShopApp.Model_Class;

using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.Utils;


namespace ShopApp.Frm.UserFrm
{
    public partial class Shop2 : DevExpress.XtraEditors.XtraForm
    {
        public Shop2()
        {
            InitializeComponent();
        }
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

        private void Shop2_Load(object sender, EventArgs e)
        {
            //gridView1.OptionsView.RowAutoHeight = true;
            gridView1.RowHeight = 60;
            //  gridView1.Columns.hei
            //  gridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateAllContent;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/getitems");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                Console.WriteLine(result);
                var ItemsList = JsonSerializer.Deserialize<List<Items>>(result);
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(int));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Brand", typeof(string));
                dt.Columns.Add("Price", typeof(double));
                dt.Columns.Add("Remain", typeof(int));
                dt.Columns.Add("Image", typeof(string));
                BindingList<PictureObject> list = new BindingList<PictureObject>();
                foreach (var item in ItemsList)
                {
                    list.Add(new PictureObject(item.id, item.brand, item.price, item.remain, item.image));
                }

                gridControl1.DataSource = list;

                // BindingSource binding = new BindingSource();
                // binding.DataSource = ItemsList;
                //  gridControl1.DataSource = binding;

            }

        }

    }
}