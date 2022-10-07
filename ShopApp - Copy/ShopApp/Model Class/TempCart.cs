using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Model_Class
{
    internal class TempCart
    {
        public string id { get; set; }

        public List<CartItem> items { get; set; }
        public double total { get; set; }

    }
}
