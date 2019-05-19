using ABC_Website.BLL;
using ABC_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC_Website
{
    public partial class ShopCart : System.Web.UI.Page
    {
        OrderBLL order_bll = new OrderBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            Order o = new Order
            {
                Customer = txtName.Text,
                Date = DateTime.Now.Date,
                Total_Payment = Convert.ToDouble(Session["total_payment"]),
                Status = "Waiting"
            };
            order_bll.Add(o);

            lblMessage.Text = "Order successfully!";
        }
    }
}