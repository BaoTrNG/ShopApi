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
    public partial class Cartfrm : DevExpress.XtraEditors.XtraForm
    {
        public Cartfrm()
        {
            InitializeComponent();
        }

        private void LoadPage()
        {
            Console.WriteLine("load");
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


        private void ReloadPage()
        {
            Console.WriteLine("reload");
            BindingSource bs = new BindingSource();
            bs.DataSource = Program.tempCart.items;
            gridControl1.DataSource = bs;
        }
        private void Cartfrm_Load(object sender, EventArgs e)
        {
            /* if (Program.isload == false)
                 ReloadPage();
             else
                 LoadPage(); */

            ReloadPage();
        }

    }
}
