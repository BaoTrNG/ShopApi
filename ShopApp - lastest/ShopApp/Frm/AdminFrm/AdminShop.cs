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

namespace ShopApp.Frm.AdminFrm
{
    public partial class AdminShop : DevExpress.XtraEditors.XtraForm
    {
        public int code;
        public AdminShop()
        {
            InitializeComponent();

            Updatebtn.Visible = false;
            Editbtn.Visible = false;
            Deletebtn.Visible = false;
            Addbtn.Visible = false;
            e1.ReadOnly = true;

            e3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            e3.Properties.Mask.EditMask = "n2";
            e3.Properties.Mask.UseMaskAsDisplayFormat = true;

            e3.Properties.Mask.EditMask = "[1-9]+\\d*";
            e3.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;


            RemainTextEdit.Properties.Mask.EditMask = "[1-9]+\\d*";
            RemainTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;

        }
        CartModel cart = new CartModel();

        private string ID;
        private string NewBrand;
        private double money;
        private int remain;
        private string NewImage;
        private string NewVid;




        public class PictureObject : INotifyPropertyChanged
        {
            public string id { get; set; }
            public string brand { get; set; }
            public int remain { get; set; }
            public double price { get; set; }
            //   public int remain { get; set; }
            public string Imageurl { get; set; }
            public Image Image { get; set; }
            public string linkvid { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
            public PictureObject(string id, string brand, int remain, double price, string url, string linkvid)
            {
                this.id = id;
                this.brand = brand;
                this.remain = remain;
                this.price = price;
                this.linkvid = linkvid;
                this.Imageurl = url;
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
                // Console.WriteLine("load shop");
                cart.buyer = Program.Username;
                cart.date = DateTime.Now.ToString("dd/MM/yyyy");
                cart.status = "pending";

                gridView1.RowHeight = 50;
                //                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/getitems");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIGetItems);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Program.JwtToken);
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();

                    var ItemsList = JsonSerializer.Deserialize<List<Items>>(result);

                    BindingList<PictureObject> list = new BindingList<PictureObject>();
                    foreach (var item in ItemsList)
                    {
                        list.Add(new PictureObject(item.id, item.brand, item.remain, item.price, item.image, item.url));

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

        private void Shop_Load(object sender, EventArgs e)
        {
            LoadPage();
            //Console.WriteLine("load page");

            gridView1.Columns["Imageurl"].Visible = false;
        }


        private async void gridControl1_Click(object sender, EventArgs e)
        {
            Editbtn.Visible = true;
            Deletebtn.Visible = true;
            Addbtn.Visible = true;
            e1.Properties.ReadOnly = true;
            e2.Properties.ReadOnly = true;
            e3.Properties.ReadOnly = true;
            RemainTextEdit.Properties.ReadOnly = true;
            LinkImageTextedit.Properties.ReadOnly = true;
            LinkVidTextedit.Properties.ReadOnly = true;

            ID = gridView1.GetFocusedRowCellValue("id").ToString();
            string Brand = gridView1.GetFocusedRowCellValue("brand").ToString();
            string url = gridView1.GetFocusedRowCellValue("linkvid").ToString();
            money = Convert.ToDouble(gridView1.GetFocusedRowCellValue("price").ToString());
            remain = Convert.ToInt32(gridView1.GetFocusedRowCellValue("remain").ToString());
            RemainTextEdit.Text = gridView1.GetFocusedRowCellValue("remain").ToString();

            LinkImageTextedit.Text = gridView1.GetFocusedRowCellValue("Imageurl").ToString();
            NewImage = LinkImageTextedit.Text;
            LinkVidTextedit.Text = gridView1.GetFocusedRowCellValue("linkvid").ToString();
            NewVid = LinkVidTextedit.Text;
            //   string Price = money.ToString(@"#\.###\.###\.##0");
            string Price = string.Format("{0:#,##0.00}", money);

            Price += " vnđ";


            e1.Text = ID;
            e2.Text = Brand;
            e3.Text = money.ToString();


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


        }




        private bool CheckRemain(string id, int remain)
        {
            // Console.WriteLine("test");
            try
            {
                // var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/checkremain" + "/" + id + "/" + remain);
                string url = Program.APICheckRemain + "/" + id + "/" + remain;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    Console.WriteLine("this is check" + result);
                    if (result == "0")
                    {
                        return false;

                    }
                    else if (result == "2")
                    {
                        return false;

                    }
                    else
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void Addbtn_Click(object sender, EventArgs e)
        {
            e1.Text = "";
            e2.Text = "";
            e3.Text = "";
            RemainTextEdit.Text = "";
            LinkImageTextedit.Text = "";
            LinkVidTextedit.Text = "";


            Editbtn.Visible = false;
            Deletebtn.Visible = false;
            Addbtn.Visible = false;

            e1.Properties.ReadOnly = false;
            e2.Properties.ReadOnly = false;
            e3.Properties.ReadOnly = false;
            RemainTextEdit.Properties.ReadOnly = false;
            LinkImageTextedit.Properties.ReadOnly = false;
            LinkVidTextedit.Properties.ReadOnly = false;

            Updatebtn.Visible = true;
            code = 2;
        }

        private void Deletebtn_Click(object sender, EventArgs e)
        {
            Updatebtn.Visible = true;

            code = 3;
        }
        private void Editbtn_Click(object sender, EventArgs e)
        {
            Editbtn.Visible = false;
            Deletebtn.Visible = false;
            Addbtn.Visible = false;

            e2.Properties.ReadOnly = false;
            e3.Properties.ReadOnly = false;
            RemainTextEdit.Properties.ReadOnly = false;
            LinkImageTextedit.Properties.ReadOnly = false;
            LinkVidTextedit.Properties.ReadOnly = false;

            Updatebtn.Visible = true;
            code = 1;
        }


        private bool CheckItemId()
        {
            try
            {
                //string url = "https://shopapiptithcm.azurewebsites.net/api/checkitemid/" + ID;
                string url = Program.APICheckItemId + "/" + ID;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    if (result == "1")
                    {
                        return true;

                    }
                    else if (result == "0")
                    {
                        return false;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi Ngoại Lệ");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        private void AddItem()
        {
            Items temp = new Items();
            temp.id = ID;
            temp.brand = NewBrand;
            temp.price = money;
            temp.remain = remain;
            temp.image = NewImage;
            temp.url = NewVid;

            string json = JsonSerializer.Serialize(temp);
            Console.WriteLine(json);
            try
            {
                //                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/createitem");

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APICreateItem);
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
                    var response = JsonSerializer.Deserialize<Response>(result);
                    if (response.code == 1)
                    {
                        MessageBox.Show("Thêm Thành Công");
                    }
                    else
                    {

                        MessageBox.Show("Thêm Thất Bại" + "\n" + response.msg);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void DeleteItem()
        {
            try
            {
                //string url = "https://shopapiptithcm.azurewebsites.net/api/deleteitem/" + ID;
                string url = Program.APIDeleteItem + ID;
                Console.WriteLine(url);
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "DELETE";
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = streamReader.ReadToEnd();
                    var response = JsonSerializer.Deserialize<Response>(result);
                    if (response.code == 1)
                    {
                        MessageBox.Show("Xoá Thành Công");
                    }
                    else
                    {

                        MessageBox.Show("Xoá Thất Bại" + "\n" + response.msg);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void UpdateItem()
        {
            Items temp = new Items();
            temp.id = ID;
            temp.brand = NewBrand;
            temp.price = money;
            temp.remain = remain;
            temp.image = NewImage;
            temp.url = NewVid;

            string json = JsonSerializer.Serialize(temp);
            Console.WriteLine(json);
            try
            {
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/updateitem");
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(Program.APIUpdateItem);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var StreamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    string result = StreamReader.ReadToEnd();
                    var response = JsonSerializer.Deserialize<Response>(result);
                    if (response.code == 1)
                    {
                        MessageBox.Show("Cập Nhật Thành Công");
                    }
                    else
                    {
                        MessageBox.Show("Xoá Thất Bại" + "\n" + response.msg);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        void ResetReadOnlyAndValue()
        {
            Updatebtn.Visible = false;
            Editbtn.Visible = false;
            Deletebtn.Visible = false;
            Addbtn.Visible = false;

            e1.Properties.ReadOnly = true;
            e2.Properties.ReadOnly = true;
            e3.Properties.ReadOnly = true;
            RemainTextEdit.Properties.ReadOnly = true;
            LinkImageTextedit.Properties.ReadOnly = true;
            LinkVidTextedit.Properties.ReadOnly = true;

            //webView21.EnsureCoreWebView2Async();
            webView21.NavigateToString("");
            e1.Text = "";
            e2.Text = "";
            e3.Text = "";
            RemainTextEdit.Text = "";
            LinkImageTextedit.Text = "";
            LinkVidTextedit.Text = "";

        }

        private void Updatebtn_Click(object sender, EventArgs e)
        {
            if (code == 1)
            {
                if (e2.Text == "" || e3.Text == "" || RemainTextEdit.Text == "" || LinkImageTextedit.Text == "" || LinkVidTextedit.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                    UpdateItem();
                    LoadPage();
                }

            }
            else if (code == 2)
            {
                //AddItem();
                if (e1.Text == "" || e2.Text == "" || e3.Text == "" || RemainTextEdit.Text == "" || LinkImageTextedit.Text == "" || LinkVidTextedit.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin");
                }
                else
                {
                    // AddItem();
                    if (CheckItemId())
                    {
                        MessageBox.Show("ID đã tồn tại");
                    }
                    else
                    {
                        AddItem();
                    }
                }
            }
            else if (code == 3)
            {
                DeleteItem();
            }
            ResetReadOnlyAndValue();
        }

        private void e1_EditValueChanged(object sender, EventArgs e)
        {
            if (e1.Text != "")
            {
                ID = e1.Text;
            }
            // ID = e1.Text;
        }

        private void e2_EditValueChanged(object sender, EventArgs e)
        {
            if (e2.Text != "")
            {
                NewBrand = e2.Text;
            }
            //NewBrand = e2.Text;
        }

        private void e3_EditValueChanged(object sender, EventArgs e)
        {
            if (e3.Text != "")
            {
                money = Convert.ToDouble(e3.Text);
            }
            // money = Convert.ToDouble(e3.Text);
        }

        private void RemainTextEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (RemainTextEdit.Text != "")
            {
                Console.WriteLine(RemainTextEdit.Text);
                remain = Convert.ToInt16(RemainTextEdit.Text);
                // remain = RemainTextEdit.Text;
            }
            // remain = Convert.ToInt32(RemainTextEdit.Text);
        }

        private void LinkImageTextedit_EditValueChanged(object sender, EventArgs e)
        {
            if (LinkImageTextedit.Text != "")
            {
                NewImage = LinkImageTextedit.Text;
            }
            // NewImage = LinkImageTextedit.Text;
        }

        private void LinkVidTextedit_EditValueChanged(object sender, EventArgs e)
        {
            if (LinkVidTextedit.Text != "")
            {
                NewVid = LinkVidTextedit.Text;
            }
            //  NewVid = LinkImageTextedit.Text;
        }


    }
}
