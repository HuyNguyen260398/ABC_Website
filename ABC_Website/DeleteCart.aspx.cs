using ABC_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABC_Website
{
    public partial class DeleteCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["shoppingcart"] != null && Request.QueryString["id"] != null)
            {
                int maSanPham;
                if (int.TryParse(Request.QueryString["id"].ToString(), out maSanPham))
                {
                    List<CartItem> shopppingCart = Session["shoppingcart"] as List<CartItem>;
                    CartItem cardItem = shopppingCart.Single(m => m.pro_id == maSanPham);
                    shopppingCart.Remove(cardItem);
                    Response.Redirect("ShopCart.aspx");
                }
            }
            Response.Redirect("ShopCart.aspx");
        }
    }
}