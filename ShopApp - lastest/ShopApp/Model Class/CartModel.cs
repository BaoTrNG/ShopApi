using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopApp.Model_Class;
namespace ShopApp.Model_Class
{
    internal class CartModel
    {
        public string buyer { get; set; }
        public string date { get; set; }

        public string status { get; set; }
        public List<CartItem> items { get; set; }
        public double total { get; set; }
    }
}
