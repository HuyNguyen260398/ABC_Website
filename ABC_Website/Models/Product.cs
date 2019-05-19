using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC_Website.Models
{
    public class Product
    {
        public int product_id { get; set; }
        public string product_name { get; set; }
        public double product_price { get; set; }
        public string product_image { get; set; }
        public string product_detail { get; set; }
        public int product_category { get; set; }
        public string product_status { get; set; }
    }
}