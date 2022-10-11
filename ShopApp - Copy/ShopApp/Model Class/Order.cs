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
        public string status { get; set; }
        public string payment { get; set; }
        public string address { get; set; }

        public string date { get; set; }
        public double total { get; set; }
        public List<CartItem> items { get; set; }


        public Order(string buyer)
        {

            this.buyer = buyer;

            this.status = "pending";

        }

    }
}
