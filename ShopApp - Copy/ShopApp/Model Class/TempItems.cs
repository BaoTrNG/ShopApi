using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ShopApp.Model_Class
{
    internal class TempItems
    {

        public string id { get; set; }
        public int amount { get; set; }
        public double price { get; set; }

    }
}
