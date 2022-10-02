using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model_Class
{
    internal class CartItem
    {
        public string id { get; set; }
        public int amount { get; set; }
        public double price { get; set; }

        public CartItem(string id, int amount, double price)
        {
            this.id = id;
            this.amount = amount;
            this.price = price;
        }

    }
}
