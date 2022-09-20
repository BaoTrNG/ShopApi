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

namespace ShopApp.Frm
{
    public partial class Main : Form
    {

        public Main()
        {

            InitializeComponent();

        }
        Shop Shopfrm = new Shop();
        private void Main_Load(object sender, EventArgs e)
        {

            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://shopapiptithcm.azurewebsites.net/api/getitems");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            /*    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                 {
                     string json = Login;

                     streamWriter.Write(json);
                 } */
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string result = streamReader.ReadToEnd();
                // Console.WriteLine(result);
                var ItemsList = JsonSerializer.Deserialize<List<Items>>(result);
                /*    BindingSource binding = new BindingSource();
                    binding.DataSource = ItemsList;
                    dataGridView1.DataSource = binding;
                    foreach (var items in ItemsList)
                    {
                        Console.WriteLine("Department Id is: {0}", items.id);
                        Console.WriteLine("Department Name is: {0}", items.price);
                        Console.WriteLine("Department Name is: {0}", items.remain);
                    } */

            }
            Shopfrm.ShowInTaskbar = false;
            Shopfrm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*   if (Application.OpenForms["Shop"] == null)
               {
                   Console.WriteLine("Shopfrm " + Shopfrm.Location);
                   Console.WriteLine("this " + this.Location);
                   //  Console.WriteLine(panel2.Location);

                   Shopfrm.Show();
               }
               else
               {
                   Console.WriteLine("Shopfrm " + Shopfrm.Location);
                   Console.WriteLine("this " + this.Location);
                   Console.WriteLine("ds");

               } */


        }
    }
}
