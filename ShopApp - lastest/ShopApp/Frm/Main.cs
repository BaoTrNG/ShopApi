using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ShopApp.Model_Class;

using System.IO; //Stream writer, reader 
using System.Net; //WebClient
using System.Text.Json; //Json serializer

using ShopApp.Frm.UserFrm;
using ShopApp.Frm.AdminFrm;
namespace ShopApp.Frm
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {


        public void SwitchRoute()
        {
            if (Program.UserType == "user")
            {
                AdminPage.Visible = false;
                Shop f = new Shop();
                f.MdiParent = this;
                f.Show();

            }
            else if (Program.UserType == "admin")
            {
                Userpage.Visible = false;
                AdminShop f = new AdminShop();
                f.MdiParent = this;
                f.Show();
            }
        }

        public Main()
        {
            InitializeComponent();


        }

        private void Main_Closing(object sender, EventArgs e)
        {
            /*   Form frm = this.CheckExists(typeof(Login));
               if (frm != null) frm.Activate();
               else
               {
                   Login f = new Login();
                   f.Show();
               } */
            Login f = new Login();

            f.Show();
        }


        //  Shop Shopfrm = new Shop();
        //Cart Cartfrm = new Cart();
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }



        private void Main_Load(object sender, EventArgs e)
        {
            SwitchRoute();


        }


        private void Shopbtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(Shop));
            if (frm != null)
            {
                frm.Activate();
            }

            else
            {
                Shop f = new Shop();
                f.MdiParent = this;
                f.Show();

            }
            /*   Shop f = new Shop();
               f.MdiParent = this;
               f.Show(); */
        }

        private void Cartbtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.tempCart.items.Count != 0)
            {
                Cartfrm f = new Cartfrm();
                f.MdiParent = this;
                f.Show();
            }
            else MessageBox.Show("Giỏ Hàng Trống");

        }
        private void GetOrder()
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
        private void Orderbtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            GetOrder();
            if (Program.tempOrder.Count != 0)
            {
                Orderfrm f = new Orderfrm();
                f.MdiParent = this;
                f.Show();
            }
            else MessageBox.Show("Không có đơn hàng nào");
        }

        private void Userbtn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(Userfrm));
            if (frm != null)
            {
                frm.Activate();
            }

            else
            {
                Userfrm f = new Userfrm();
                f.MdiParent = this;
                f.Show();

            }
        }

        private void AdminItems_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminShop f = new AdminShop();
            f.MdiParent = this;
            f.Show();
        }

        private void AdminOrder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminOrder f = new AdminOrder();
            f.MdiParent = this;
            f.Show();
        }

        private void AdminUser_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AdminUser f = new AdminUser();
            f.MdiParent = this;
            f.Show();
        }
    }
}
