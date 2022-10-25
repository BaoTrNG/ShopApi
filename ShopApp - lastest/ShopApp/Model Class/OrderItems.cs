using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model_Class
{
    internal class OrderItems
    {
        public string ID { get; set; }
        public int amount { get; set; }
        public double price { get; set; }

        public OrderItems(string id, int amount, double price)
        {
            this.ID = id;
            this.amount = amount;
            this.price = price;
        }
    }
}
