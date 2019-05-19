using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC_Website.Models
{
    public class CartItem
    {
        public int pro_id { get; set; }
        public int pro_category { get; set; }
        public string pro_name { get; set; }
        public string pro_image { get; set; }
        public double pro_price { get; set; }
        public int quantity { get; set; }
        public double total
        {
            get
            {
                return quantity * pro_price;
            }
        }
    }
}