using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model_Class
{
    internal class Order
    {
        public string id { get; set; }
        public string buyer { get; set; }
        public string phone { get; set; }
        public string status { get; set; }
        public string payment { get; set; }
        public string msg { get; set; }
        public string address { get; set; }

        public string date { get; set; }
        public double total { get; set; }
        public List<CartItem> items { get; set; }

        public List<Admin> admins { get; set; }
        public Order(string buyer)
        {

            this.buyer = buyer;
            this.status = "pending";
            this.admins = new List<Admin>();

        }

    }
}
