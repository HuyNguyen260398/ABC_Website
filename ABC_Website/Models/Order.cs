using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ABC_Website.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string Customer { get; set; }
        public DateTime Date { get; set; }
        public double Total_Payment { get; set; }
        public string Status { get; set; }
    }
}